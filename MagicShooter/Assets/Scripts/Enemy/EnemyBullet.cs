
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int damageToPlayer = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
            rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        Destroy(this.gameObject, 10);


    }

    private void OnTriggerEnter(Collider _other)
    {
        Character player = _other.gameObject.GetComponent<Character>();
        EnemyBase enemy = _other.gameObject.GetComponent<EnemyBase>();
        CrystalBase crystal = _other.gameObject.GetComponent<CrystalBase>();
        EnemyRoomManager enemyRM = _other.gameObject.GetComponent<EnemyRoomManager>();
        CrystalEncounterTrigger encounterTrigger = _other.gameObject.GetComponent<CrystalEncounterTrigger>();
        if (player)
        {
            player.DamagePlayer(damageToPlayer);
            Debug.Log("Player damaged  by" + damageToPlayer);
            Destroy(this.gameObject);
        }

        if (!enemyRM && !enemy && !crystal && !encounterTrigger)
            Destroy(this.gameObject);
    }

}
