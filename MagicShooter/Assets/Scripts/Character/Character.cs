using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController characterController;

    public Weapon currentWeapon;

    public int health = 100;

    private HealthDisplay healthDisplay;

    void Start()
    {
        if (!characterController)
            characterController = GetComponent<CharacterController>();

        healthDisplay = FindObjectOfType<HealthDisplay>();

        healthDisplay.UpdateHealthCounter(health);
    }

    public void DamagePlayer(int _amountToDamage)
    {
        health -= _amountToDamage;
        healthDisplay.UpdateHealthCounter(health);
    }
}