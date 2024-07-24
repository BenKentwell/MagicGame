
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class EnemyIdle : StateMachineBehaviour
{
    public GameObject character;

    private float optimiseTimer;

    private float optimiseTimerMax = 1;

   

    private EnemyBase thisEnemy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject.GetComponent<EnemyBase>();
        character = thisEnemy.character.gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (optimiseTimer > optimiseTimerMax)
        {
            //Check If player in range
            float dist = Vector3.Distance(thisEnemy.gameObject.transform.position, character.transform.position);
            if (dist < thisEnemy.alertDistance)
            {
                animator.SetTrigger(EnemyBase.PlayerSeenTrigger);
            }
        }
        else
        {
            optimiseTimer += Time.deltaTime;
        }
    }
}

