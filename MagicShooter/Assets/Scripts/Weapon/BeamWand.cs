using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWand : Weapon
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
