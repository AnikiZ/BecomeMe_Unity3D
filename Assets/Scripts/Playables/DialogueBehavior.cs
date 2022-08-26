using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class DialogueBehavior : PlayableBehaviour
{
    private PlayableDirector playableDirector;// in charge of timeline play, pasue

    public string characterName;
    [TextArea(8,1)] public string dialogueLine;
    public int dialogueSize;

    private bool isClipPlayed;//whether the clip is already played
    public bool requirePause;//user config: whether needs SpaceBar to continue dialogue
    private bool pauseScheduled;

    public override void OnPlayableCreate(Playable playable)
    {
        playableDirector = playable.GetGraph().GetResolver() as PlayableDirector;
    }

    //like Update in MonoBehavior, called in every frame
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(isClipPlayed == false && info.weight > 0 && UIManager.instance)
        {
            UIManager.instance.SetupDialogue(characterName, dialogueLine, dialogueSize);

            if (requirePause)
                pauseScheduled = true;

            isClipPlayed = true;
        }
    }

    // called when clip is paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        isClipPlayed = false;
        Debug.Log("Clip is Stooooop");

        if(pauseScheduled)
        {
          if (GameManager.instance)
          {
            pauseScheduled = false;
            //MARKER Pause TIMELINE
            GameManager.instance.PauseTimeline(playableDirector);
          }
        }
        else
        {
          if (UIManager.instance)
          {
            UIManager.instance.ToggleDialogueBox(false);
          }
        }
    }

}
