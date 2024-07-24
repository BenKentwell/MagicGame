
using UnityEngine;

public class EnemyRoomManager : MonoBehaviour
{
    [SerializeField, Tooltip("reference to the character")]
    private Character character;

    [SerializeField, Tooltip("The list of enemies owned by the manager"), ContextMenuItem("Set all children enemies", "ResetEnemies")]
    private EnemyBase[] enemies;

    // Start is called before the first frame update
    void Start()
    {
     if(character == null)
         Debug.Log("Player in " + this.name +" is null");
    }

    private void OnTriggerEnter(Collider _other)
    {
        Character temp;
        temp = _other.GetComponent<Character>();
        if (temp)
        {
            character = temp;

            SetAllEnemyCharacter();
        }
            
    }

    private void ResetEnemies()
    {
        enemies = GetComponentsInChildren<EnemyBase>();
    } 

    private void SetAllEnemyCharacter()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].ActivateEnemy(character);
        }
    }
}
