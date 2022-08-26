using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{
  Transform player;
  Transform monster;
  int frame = 0;
  bool removed = false;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    monster = GameObject.FindGameObjectWithTag("Monster").transform;
    monster = GameObject.FindGameObjectWithTag("Monster").transform;
  }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (frame++ > 20 && !removed)
    {
      if (FirstPlayer.DetectSlash())
      {
        removed = true;
        Monster.RemoveHealth(FirstPlayer.damage);
      }
    }
    animator.SetBool("PlayerAttack", false);
  }

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  { 
    removed = false;
    frame = 0;
    FirstPlayer.willAttack = false;
    // Monster.DetectSlash(sword, player);
  }
}
