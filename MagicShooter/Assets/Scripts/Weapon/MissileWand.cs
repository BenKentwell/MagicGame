using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class MissileWand : Weapon
{
    public override void Shoot(Transform _cameraTransform)
    {
        if (canShoot)
        {
            ShootParticleSystem.Play();
            canShoot = false;
            RaycastHit hit;
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.transform.forward, out hit))
            {
                EnemyBase enemy = hit.collider.gameObject.GetComponent<EnemyBase>();
                
                if (enemy)
                {
                    enemy.Damage(Damage);
                    GameObject blood = Instantiate(hitParticle, hit.transform.position, Quaternion.identity);
                }
            }
            
        }
    }
}