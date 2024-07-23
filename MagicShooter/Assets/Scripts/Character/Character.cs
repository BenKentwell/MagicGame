using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController characterController;

    public AudioManager audioMang;

    public Weapon currentWeapon;

    public int health = 100;

    private HealthDisplay healthDisplay;

    void Start()
    {
        audioMang = FindObjectOfType<AudioManager>();

        if (!characterController)
            characterController = GetComponent<CharacterController>();

        healthDisplay = FindObjectOfType<HealthDisplay>();

        healthDisplay.UpdateHealthCounter(health);
    }

    public void DamagePlayer(int _amountToDamage)
    {
        audioMang.PlayDamagePlayer();
        health -= _amountToDamage;
        healthDisplay.UpdateHealthCounter(health);
    }
}