using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public CharacterController characterController;

    public Weapon currentWeapon;

    public int health = 100;
// Start is called before the first frame update
    void Start()
    {
        if (!characterController)
            characterController = GetComponent<CharacterController>();

    }

    public void DamagePlayer(int _amountToDamage)
    {
        health -= _amountToDamage;
    }

   
}