using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public abstract class Weapon : MonoBehaviour
{
    //Fast and loose
    public float Mana = 100;
    public float CostToShoot = 1;
    public float Damage = 1;


    public GameObject hitParticle;
    public ParticleSystem ShootParticleSystem;
    public bool canShoot = true;

    public eWeapon weaponType = eWeapon.Error;

    

    //Override for damage to enemies

    public abstract void Shoot(Transform _cameraTransform);

    public void SetShootCooldown()
    {
        canShoot = true;
    }

}
