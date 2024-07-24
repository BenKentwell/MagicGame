
using UnityEngine;

public class Enemyfollow : StateMachineBehaviour
{
    // Start is called before the first frame update

    private Character character;
    private EnemyBase thisEnemy;
    private Rigidbody thisEnemyRigidbody;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject.GetComponent<EnemyBase>();
        thisEnemyRigidbody = thisEnemy.GetComponent<Rigidbody>();
        character = thisEnemy.character;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy.gameObject.transform.LookAt(character.transform);


        thisEnemyRigidbody.velocity = thisEnemy.transform.forward * thisEnemy.speed;

    }
}
