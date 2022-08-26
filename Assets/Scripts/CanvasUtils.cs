using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CanvasUtils
{
  public static void SetLeft(this RectTransform rt, float left)
  {
    rt.offsetMin = new Vector2(left, rt.offsetMin.y);
  }

  public static void SetRight(this RectTransform rt, float right)
  {
    rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
  }

  public static void SetTop(this RectTransform rt, float top)
  {
    rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
  }

  public static void SetBottom(this RectTransform rt, float bottom)
  {
    rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
  }

  public static void ReducePlayerRight(this RectTransform rt, float ratio)
  {
    GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
    RectTransform CanvasRC = Canvas.GetComponent<RectTransform>();
    rt.offsetMax = new Vector2(rt.offsetMax.x - ratio * (0.3f * CanvasRC.rect.width - 50f), rt.offsetMax.y);
  }

  public static void ReduceMonsterRight(this RectTransform rt, float ratio)
  {
    GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
    RectTransform CanvasRC = Canvas.GetComponent<RectTransform>();
    rt.offsetMax = new Vector2(rt.offsetMax.x - ratio * (0.6f * CanvasRC.rect.width - 50f), rt.offsetMax.y);
  }
}
