using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShoot : MonoBehaviour
{
    [SerializeField]
    private float timeToShoot;

    private float timer;

    [SerializeField]
    private GameObject bulletToShoot;

    private void Awake()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToShoot)
        {
            timer = 0;
            //Shoot
            Instantiate(bulletToShoot, transform.position, transform.rotation);
        }
    }
}
