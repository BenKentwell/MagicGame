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

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;

    public Weapon[] weapons;

    public Camera playerCamera;


    private void Start()
    {
        if (!playerCamera)
            playerCamera = GetComponentInChildren<Camera>();

        if (!currentWeapon)
        {
            currentWeapon = weapons[0];
        }
    }

    public void SetWeapon(eWeapon _weaponToSet)
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[(int)_weaponToSet];
        currentWeapon.gameObject.SetActive(true);
        //Set new Mesh ? 
        //Go to new Anim subgraph
    }

    public void Shoot(InputAction.CallbackContext _context)
    {
        switch (_context.phase)
        {
            case InputActionPhase.Started:
            {
                currentWeapon.Shoot(playerCamera.transform);
                SetWeaponCanShoot();
            }
                break;
        }
        
    }

    public void SetWeaponCanShoot()
    {
        currentWeapon.SetShootCooldown();
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

   
