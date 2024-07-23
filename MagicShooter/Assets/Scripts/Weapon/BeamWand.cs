using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWand : Weapon
{
    [SerializeField, Tooltip("Damage over held time")] private AnimationCurve damageCurve;

    private float currentDamage = 0;
    private GameObject cam;
    private float timer;

    private bool isShooting;


    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            //Find last key on cruve and set damage
            //if(timer > lastkeytime)

            Damage = damageCurve.Evaluate(timer);

            timer += Time.deltaTime;
            Shoot(cam.transform);
        }
    }

    public void SetShooting(Transform _cameraTransform)
    {
        cam = _cameraTransform.gameObject;
        isShooting = true;
        timer = 0;

    }

    public void SetNotShooting()
    {
        timer = 0;
        isShooting = false;
    }


    public override void Shoot(Transform _cameraTransform)
    {
        if (canShoot)
        {
            DecreaseMana();
            ShootParticleSystem.Play();
            canShoot = false;
            RaycastHit hit;
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.transform.forward, out hit))
            {
                EnemyBase enemy = hit.collider.gameObject.GetComponent<EnemyBase>();

                if (enemy)
                {
                    enemy.Damage(Damage);
                    enemy.controller.SetTrigger(EnemyBase.PlayerSeenTrigger);
                    GameObject blood = Instantiate(hitParticle, hit.transform.position, Quaternion.identity);
                }
            }

        }
    }
}
