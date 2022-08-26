using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BattleGameManager : MonoBehaviour
{
  public static BattleGameManager instance;

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
    Application.targetFrameRate = 30;//OPTIONAL
  }

  public void FinishedCG( )
  {
    SceneManager.LoadScene(1);
    SceneManager.UnloadScene(0);
  }

  public void ReloadBattle ()
  {
    SceneManager.LoadScene(1);
  }

}
