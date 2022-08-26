using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRun : StateMachineBehaviour
{
  Transform player;
  Transform monster;
  Rigidbody rb;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    monster = GameObject.FindGameObjectWithTag("Monster").transform;
    rb = animator.GetComponent<Rigidbody>();
  }


  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (Monster.willDie)
    {
      animator.SetBool("WillDie", true);
    }
    monster.LookAt(player);
    if (Monster.DetectAttackRange())
    {
      animator.SetBool("WillAttack", true);
    }
    else
    {
      animator.SetBool("WillAttack", false);
      Vector3 targetPosition = new Vector3(player.position.x, monster.position.y, player.position.z);
      Vector3 newPosition = Vector3.MoveTowards(monster.position, targetPosition, Monster.speed * Time.fixedDeltaTime);
      monster.position = newPosition;
    }
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    Debug.Log("run exit!");
  }

  // OnStateMove is called right after Animator.OnAnimatorMove()
  //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    // Implement code that processes and affects root motion
  //}

  // OnStateIK is called right after Animator.OnAnimatorIK()
  //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    // Implement code that sets up animation IK (inverse kinematics)
  //}
}
