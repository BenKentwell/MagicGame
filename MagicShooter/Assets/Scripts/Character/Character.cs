using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public CharacterController characterController;

    public Weapon currentWeapon;

// Start is called before the first frame update
    void Start()
    {
        if (!characterController)
            characterController = GetComponent<CharacterController>();

    }

   
}