using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterWand : Weapon
{
    public int amountOfPellets;

    public float maximumDistance;

    public override void Shoot(Transform _cameraTransform)
    {
        if (canShoot && CostToShoot < parentPair.mana)
        {
            DecreaseMana();
            audioMang.PlayScatterPlayer();
            ShootParticleSystem.Play();
            canShoot = false;
            RaycastHit[] hits = new RaycastHit[amountOfPellets];
           // Ray[] rays = new Ray[amountOfPellets];

            
            //Guarenteed scatter hit centre
            Ray[] rays =
            {
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward+ new Vector3(0, 0.0f, 0)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, 0.2f, 0)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, -0.2f, 0)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, 0f, 0.2f)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, 0f, -0.2f)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, 0.2f, 0.2f)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, 0.2f, -0.2f)),
                new Ray(_cameraTransform.position, _cameraTransform.transform.forward + new Vector3(0, -0.2f, 0.2f))
            };
            
            //amountOfpellets raycast
            for (int i = 0; i < amountOfPellets; i++)
            {
                if (Physics.Raycast(rays[i], out hits[i], maximumDistance))
                {
                    EnemyBase enemy = hits[i].collider.gameObject.GetComponent<EnemyBase>();
                    if (enemy)
                    {
                        enemy.Damage(Damage);
                        enemy.controller.SetTrigger(EnemyBase.PlayerSeenTrigger);
                        GameObject blood = Instantiate(hitParticle, hits[i].transform.position, Quaternion.identity);
                        return;
                    }

                    CrystalBase crystal = hits[i].collider.gameObject.GetComponent<CrystalBase>();
                    if (crystal)
                    {
                        crystal.TakeDamage((int)Damage);
                        GameObject blood = Instantiate(hitParticle, hits[i].transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
