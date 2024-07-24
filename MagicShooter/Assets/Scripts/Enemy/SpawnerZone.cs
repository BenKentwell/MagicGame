using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerZone : MonoBehaviour
{

    [SerializeField]
    private Vector2 spawnerRange;

    [SerializeField]
    private float spawnOnSeconds;

    [SerializeField]
    private GameObject gargoyle;

    private float timer;

    private bool startSpawner = false;

    private Character charcter;

    private void Update()
    {
        if (startSpawner)
        {
            timer += Time.deltaTime;
            if(timer > spawnOnSeconds)
            {
                timer = 0;
                Vector2 pos = new Vector2(Random.Range(-spawnerRange.x, spawnerRange.x), Random.Range(-spawnerRange.y, spawnerRange.y));
               GameObject ob = Instantiate(gargoyle, transform.position + new Vector3(pos.x, 0, pos.y), Quaternion.identity);
                ob.GetComponent<EnemyBase>().ActivateEnemy(charcter);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Character>())
        {
            charcter = other.GetComponent<Character>();
            startSpawner = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnerRange.x, 1, spawnerRange.y));
    }
}
