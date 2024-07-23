using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum eWeapon
{
    Missile = 0,
    Scatter,
    Beam,
    Error
}

[System.Serializable]
public class ManaWeaponPair
{
    public Weapon weapon;
    public float mana;


    public float maxVal = 100;
    public void Start()
    {
        weapon.parentPair = this;
    }

    public void Update()
    {
        if (mana <= 0)
        {
            mana = 0;
        }
        if (mana >= maxVal)
        {
            mana = maxVal;
        }
        else
        {
            mana += weapon.rechargeRate * Time.deltaTime;
        }
    }
}


public class WeaponManager : MonoBehaviour
{
    public ManaWeaponPair currentWeapon;

    public ManaWeaponPair[] weapons;

    public Camera playerCamera;

    public AudioManager audioMang;

    [SerializeField] private ManaDisplay manaDisplay;


    private void Start()
    {
            audioMang = FindObjectOfType<AudioManager>();

        if (!playerCamera)
            playerCamera = GetComponentInChildren<Camera>();

        if (currentWeapon != null)
        {
            currentWeapon = weapons[0];
        }

        manaDisplay = FindObjectOfType<ManaDisplay>();

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].Start();
            weapons[i].weapon.audioMang = audioMang;
        }
    }

    private void LateUpdate()
    {
        //Set TMP mana to getmana
       manaDisplay.UpdateManaCounter(GetMana());

       for (int i = 0; i < weapons.Length; i++)
       {
           weapons[i].Update();
       }
    }

    public int GetMana()
    {
        return (int)currentWeapon.mana;
    }

    public void SetWeapon(eWeapon _weaponToSet)
    {
        currentWeapon.weapon.gameObject.SetActive(false);
        currentWeapon = weapons[(int)_weaponToSet];
        currentWeapon.weapon.gameObject.SetActive(true);
        //Set new Mesh ? 
        //Go to new Anim subgraph
    }

    public void Shoot(InputAction.CallbackContext _context)
    {
        switch (currentWeapon.weapon.weaponType)
        {
            case eWeapon.Missile:
                if (_context.phase == InputActionPhase.Started)
                {
                    currentWeapon.weapon.Shoot(playerCamera.transform);
                    SetWeaponCanShoot();
                }
                break;

            case eWeapon.Scatter:
                if (_context.phase == InputActionPhase.Started)
                {
                    currentWeapon.weapon.Shoot(playerCamera.transform);
                    SetWeaponCanShoot();
                }
                break;

            case eWeapon.Beam:
                if (_context.phase == InputActionPhase.Started)
                {
                    BeamWand wand = (BeamWand)currentWeapon.weapon;
                    SetWeaponCanShoot();
                    wand.SetShooting(playerCamera.transform);
                }

                if (_context.phase == InputActionPhase.Canceled)
                {
                    {
                        BeamWand wand = (BeamWand)currentWeapon.weapon;
                        wand.SetNotShooting();
                    }
                }
                break;

            case eWeapon.Error:
                Debug.Log("WeaponTypeNotSet");
                break;
        }
    }

    public void SetWeaponCanShoot()
    {
        currentWeapon.weapon.SetShootCooldown();
    }

    public void SetWeaponOne()
    {
        SetWeapon(eWeapon.Missile);
    }
    public void SetWeaponTwo()
    {
        SetWeapon(eWeapon.Scatter);
    }
    public void SetWeaponThree()
    {
        SetWeapon(eWeapon.Beam);
    }

}

   
