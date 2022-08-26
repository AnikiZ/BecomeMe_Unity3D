using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public enum GameMode
  {
      Normal,
      GamePlay,
      DialogueMoment
  }
  public GameMode gameMode;
  private PlayableDirector currentPlayableDirector;

  private void Awake ()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      if (instance != this)
      {
        Destroy(instance);
      }
    }

    // DontDestroyOnLoad(gameObject);

    gameMode = GameMode.Normal;
    Application.targetFrameRate = 30;//OPTIONAL
  }

  //continue timeline only by pressing SpaceBar
  private void Update ()
  {
    if (gameMode == GameMode.DialogueMoment)
    {
      if (Input.GetKeyDown(KeyCode.Return))
      {
        ResumeTimeline();
      }
    }
  }

  public void PauseTimeline (PlayableDirector _playableDirector)
  {
    currentPlayableDirector = _playableDirector;
    if (!currentPlayableDirector) return;
    gameMode = GameMode.DialogueMoment;
    currentPlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);

    UIManager.instance.ToggleSpaceBar(true);
  }

  public void Pause (PlayableDirector _playableDirector)
  {
    currentPlayableDirector = _playableDirector;
    if (!currentPlayableDirector) return;
    // gameMode = GameMode.DialogueMoment;
    currentPlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);

    // UIManager.instance.ToggleSpaceBar(true);
  }

  public void Continue()
  {
    // gameMode = GameMode.GamePlay;
    if (!currentPlayableDirector) return;
    currentPlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);

    // UIManager.instance.ToggleSpaceBar(false);
    // UIManager.instance.ToggleDialogueBox(true);
  }
  

  public void ResumeTimeline ()
  {
    gameMode = GameMode.GamePlay;
    currentPlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);

    UIManager.instance.ToggleSpaceBar(false);
    UIManager.instance.ToggleDialogueBox(true);
  }

  public void FinishedCG( )
  {
    gameMode = GameMode.Normal;
    //SceneManager.UnloadScene(0);
    SceneManager.LoadScene(1);
    
  }

  public void ReloadBattle ()
  {
        //SceneManager.UnloadScene(1);
        SceneManager.LoadScene(1);
  }

}
