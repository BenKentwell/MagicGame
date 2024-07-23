using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [DoNotSerialize]
    public static int PlayerSeenTrigger = Animator.StringToHash("PlayerSeen");

    [DoNotSerialize]
    public static int ShootTrigger = Animator.StringToHash("Shoot");
    [DoNotSerialize]
    public static int ActivateTrigger = Animator.StringToHash("Activate");

    public bool doesThisEnemyShoot;
    public float timeToShoot;

    public float speed = 1;
    public float Health;

    [DoNotSerialize]
    public Character character;

    public Animator controller;

    private float shootTimer;

    public float alertDistance = 5;

    [DoNotSerialize]
    public bool roomActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        if (!controller)
            controller = GetComponent<Animator>();

#if UNITY_EDITOR
        if (!controller)
            Debug.Log("Animator of enemy " + this.name + " is not set");
#endif

        shootTimer = Random.Range(0.016f, timeToShoot);
    }

    // Update is called once per frame
    void Update()
    {
        //Does this enemyShoot
        if (roomActivated && doesThisEnemyShoot)
        {
            //ShootBehaviour
            if (shootTimer > timeToShoot)
            {
                //SetTriggerShoot
                controller.SetTrigger(ShootTrigger);
                shootTimer = 0;
            }
            else
            {
                shootTimer += Time.deltaTime;
            }
        }

        if (CheckIfDead())
            Die();
    }

   public void Damage(float _damageRecieved)
    {
        Health -= _damageRecieved;
        
    }

    bool CheckIfDead()
    {
        if (Health <= 0)
            return true;
        return false;
    }

    void Die()
    {
        GameObject.DestroyImmediate(this.gameObject);
    }

    public void ActivateEnemy(Character _character)
    {
        character = _character;
        roomActivated = true;
        controller.SetTrigger(EnemyBase.ActivateTrigger);
    }
}
