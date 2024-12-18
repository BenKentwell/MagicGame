
using UnityEngine;


public class MissileWand : Weapon
{
    public override void Shoot(Transform _cameraTransform)
    {
        if (canShoot && CostToShoot < parentPair.mana)
        {
            DecreaseMana();
            audioMang.PlaySinglePlayer();
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
                    return;
                }
                
                CrystalBase crystal = hit.collider.gameObject.GetComponent<CrystalBase>();
                if (crystal)
                {
                    crystal.TakeDamage(Damage);
                    GameObject blood = Instantiate(hitParticle, hit.transform.position, Quaternion.identity);
                    return;
                }

                BossDeath boss = hit.collider.gameObject.GetComponent<BossDeath>();
                if (boss)
                {
                    boss.StartCinematic();
                    GameObject blood = Instantiate(hitParticle, hit.transform.position, Quaternion.identity);
                }


            }
            
        }
    }
}
