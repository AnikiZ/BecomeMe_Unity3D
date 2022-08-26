using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  public static UIManager instance;

  public GameObject dialogueBox;

  public Text characterNameText;
  public Text dialogueLineText;
  public GameObject spacebar;//OPTIONAL public Text spaceBar;

  private void Awake()
  {
    if(instance == null)
    {
      instance = this;
    }
    else
    {
      if(instance != this)
      {
        Destroy(instance);
      }
    }

    // DontDestroyOnLoad(gameObject);
  }

  public void ToggleDialogueBox(bool _isActive)
  {
    dialogueBox.gameObject.SetActive(_isActive);
  }

  public void ToggleSpaceBar(bool _isActive)
  {
    spacebar.gameObject.SetActive(_isActive);
  }

  //OPTIONAL actually these two methods can be integrated into one method;
  // but will be imconvenient for external calling.
  //public void ToggleFoo(GameObject _foo, bool _isActive)
  //{
  //    _foo.gameObject.SetActive(_isActive);
  //}

  //OPTIONAL If check the best fit, then the third argument can be deleted.
  public void SetupDialogue(string _name, string _line, int _size)
  {
    characterNameText.text = _name;
    dialogueLineText.text = _line;
    dialogueLineText.fontSize = _size;

    ToggleDialogueBox(true);//赋值好每一句对话的台词、名字、字体大小后，记得开启对话框
  }

}
