using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
    RectTransform CanvasRC = Canvas.GetComponent<RectTransform>();
    GameObject MonsterHP = GameObject.FindGameObjectWithTag("MonsterHP");
    RectTransform MonsterHPRC = MonsterHP.GetComponent<RectTransform>();
    CanvasUtils.SetLeft(MonsterHPRC, 50f);
    CanvasUtils.SetRight(MonsterHPRC, 0.4f * CanvasRC.rect.width);
    CanvasUtils.SetTop(MonsterHPRC, 30f);
    CanvasUtils.SetBottom(MonsterHPRC, CanvasRC.rect.height - 60f);
    GameObject MyHP = GameObject.FindGameObjectWithTag("MyHP");
    RectTransform MyHPRC = MyHP.GetComponent<RectTransform>();
    CanvasUtils.SetLeft(MyHPRC, 50f);
    CanvasUtils.SetRight(MyHPRC, 0.7f * CanvasRC.rect.width);
    CanvasUtils.SetTop(MyHPRC, CanvasRC.rect.height - 50f);
    CanvasUtils.SetBottom(MyHPRC, 35f);
    // GameObject MyHPText = GameObject.FindGameObjectWithTag("MyHPText");
    // RectTransform MyHPTextRC = MyHPText.GetComponent<RectTransform>();
    // CanvasUtils.SetLeft(MyHPTextRC, 10f);
    // CanvasUtils.SetRight(MyHPTextRC, CanvasRC.rect.width - 50f);
    // CanvasUtils.SetTop(MyHPTextRC, CanvasRC.rect.height - 60f);
    // CanvasUtils.SetBottom(MyHPTextRC, 30f);
  }

  // Update is called once per frame
  void Update()
  {
      
  }
}
