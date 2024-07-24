
using System.Collections.Generic;
using UnityEngine;

public class CrystalBase : MonoBehaviour
{
    public float health = 1000;

    [SerializeField] private List<GameObject> doorsToOpen = new();

    [SerializeField] private List<GameObject> childrenCrystalComponents;


    public bool isActivated = false;
    public void SetActivation()
    {
        isActivated = true;

       foreach (GameObject go in childrenCrystalComponents)
       {
            go.SetActive(true);
       }
    }

    public void TakeDamage(float damage)
    {
        if(isActivated)
            health -= damage;
    }
    private void Update()
    {
        if (isActivated && CheckIfBroken())
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


        FindObjectOfType<Character>().health = 100;
        FindObjectOfType<HealthDisplay>().display.text = "Health: 100";

        foreach (GameObject go in childrenCrystalComponents)
        {
            go.SetActive(false);
        }

        //Break Crystal
        Destroy(this.gameObject);
    }
    
}
