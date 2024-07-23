using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : StateMachineBehaviour
{
    private Character character;
    private EnemyBase thisEnemy;

    [SerializeField]
    private GameObject orbToShootGameObject;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject.GetComponent<EnemyBase>();
        character = thisEnemy.character;
        thisEnemy.gameObject.transform.LookAt(character.transform);

        GameObject.Instantiate(orbToShootGameObject, thisEnemy.gameObject.transform.position + new Vector3(0,0.5f,0), thisEnemy.gameObject.transform.rotation);

    }

}
