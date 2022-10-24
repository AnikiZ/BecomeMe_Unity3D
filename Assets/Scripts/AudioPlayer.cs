using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  public static void PlayAudio (string name)
  {
    GameObject AudioObject = GameObject.Find(name);
    if (AudioObject)
    {
      AudioSource audioData = AudioObject.GetComponent<AudioSource>();
      if (audioData) audioData.Play(0);
    }
  }

  public static void PlayMonsterAudio (string name)
  {
    GameObject AudioObject = GameObject.Find(name);
    Transform MonsterTransform = GameObject.FindGameObjectWithTag("Monster").transform;
    Vector3 MonsterPosition = MonsterTransform.position;
    AudioObject.transform.position = new Vector3(MonsterPosition.x, MonsterPosition.y, MonsterPosition.z);
    if (AudioObject)
    {
      AudioSource audioData = AudioObject.GetComponent<AudioSource>();
      if (audioData) audioData.Play(0);
    }
  }
}
