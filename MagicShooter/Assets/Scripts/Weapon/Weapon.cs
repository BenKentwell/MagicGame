using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public abstract class Weapon : MonoBehaviour
{
    //Fast and loose
    public float CostToShoot = 1;
    public float Damage = 1;

    public float rechargeRate = 1;

    public GameObject hitParticle;
    public ParticleSystem ShootParticleSystem;
    public bool canShoot = true;

    public eWeapon weaponType = eWeapon.Error;
    public ManaWeaponPair parentPair;

    public AudioManager audioMang;


    //Override for damage to enemies

    public abstract void Shoot(Transform _cameraTransform);

    protected void DecreaseMana()
    {
        parentPair.mana -= CostToShoot;
    }

    public void SetShootCooldown()
    {
        canShoot = true;
    }
}
