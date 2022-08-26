using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : StateMachineBehaviour
{
  Transform player;
  Transform monster;
  Transform sword;
  Rigidbody rb;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    monster = GameObject.FindGameObjectWithTag("Monster").transform;
    sword = GameObject.FindGameObjectWithTag("Monster_Sword").transform;
    rb = animator.GetComponent<Rigidbody>();
    monster.LookAt(player);
    
  }


  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (Monster.willDie)
    {
      animator.SetBool("WillDie", true);
    }
    else
    {
      animator.SetBool("WillAttack", false);
    }
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    Monster.DetectSlash();
    if (FirstPlayer.health <= 0)
    {
      animator.SetBool("End", true);
    }
    // Monster.DetectSlash(sword, player);
  }
}
