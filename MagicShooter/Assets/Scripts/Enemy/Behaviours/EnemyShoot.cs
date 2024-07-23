using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : StateMachineBehaviour
{
    private Character character;
    private EnemyBase thisEnemy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject.GetComponent<EnemyBase>();
        character = thisEnemy.character;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy.gameObject.transform.LookAt(character.transform);
    }

}
