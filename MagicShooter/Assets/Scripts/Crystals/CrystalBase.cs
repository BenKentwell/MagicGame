using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBase : MonoBehaviour
{
    public float health = 1000;

    [SerializeField] private List<GameObject> doorsToOpen = new();

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if (CheckIfBroken())
        {
            //Crystal is broken
            Broke();
        }
    }

    public bool CheckIfBroken()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    }

    public void Broke()
    {
        //PlayBreakSound

        //Trigger door open event
        foreach (GameObject o in doorsToOpen)
        {
            o.SetActive(false);
        }

        //Break Crystal
        Destroy(this.gameObject);
    }
    
}
