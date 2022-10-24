using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : StateMachineBehaviour
{
  Transform player;
  Transform monster;
  Transform sword;
  Rigidbody rb;
  bool audioPlayed = false;
  int frame = 0;
  int attackMotion = 0;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    monster = GameObject.FindGameObjectWithTag("Monster").transform;
    sword = GameObject.FindGameObjectWithTag("Monster_Sword").transform;
    rb = animator.GetComponent<Rigidbody>();
    monster.LookAt(player);
    frame = 0;
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
    if (frame++ > 27 && !audioPlayed)
    {
      attackMotion = attackMotion % 3;
      attackMotion += 1;
      AudioPlayer.PlayMonsterAudio($"MonsterAttack{attackMotion}Audio");
      audioPlayed = true;
      Monster.DetectSlash();
      if (FirstPlayer.health <= 0)
      {
        animator.SetBool("End", true);
      }
    }
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    audioPlayed = false;
    // Monster.DetectSlash(sword, player);
  }
}
