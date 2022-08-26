using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TriggerArea1 : MonoBehaviour
{
  public PlayableDirector playableDirector;
  // Start is called before the first frame update
  private void OnTriggerEnter(Collider other)
  {
        if (other.CompareTag("Player") && playableDirector)
        {
            playableDirector.Play();
            Object.Destroy(this.gameObject);
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player") && playableDirector)
    //    {
    //        if (playableDirector.playableGraph.GetRootPlayable(0).GetSpeed() == 0d)
    //        {
    //            playableDirector.Play();
    //            Object.Destroy(this.gameObject);
    //            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
    //        }
    //    }
    //}
}
