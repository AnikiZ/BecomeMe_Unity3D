using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : StateMachineBehaviour
{
  int frame = 0;
  bool triggered = false;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    AudioPlayer.PlayMonsterAudio($"MonsterDieAudio");
  }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  { 
    if (frame++ > 30 && !triggered)
    {
      triggered = true;
      GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
      GameObject YouDie = GameObject.FindGameObjectWithTag("YouDie");
      GameObject YouWon = GameObject.FindGameObjectWithTag("YouWon");
      Canvas.GetComponent<CanvasGroup>().alpha = 0f;
      YouDie.GetComponent<CanvasGroup>().alpha = 0f;
      YouWon.GetComponent<CanvasGroup>().alpha = 1f;
    }
    
  }
}
