using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : StateMachineBehaviour
{
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (FirstPlayer.willAttack)
    {
      animator.SetBool("PlayerAttack", true);
    }
    else
    {
      animator.SetBool("PlayerAttack", false);
    }
  }
}
