using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGet : MonoBehaviour {
  
    public void play()
    {
     GameObject play = GameObject.Find("PlayBubble");
    BubblePop sound = play.GetComponent<BubblePop>();
    sound.play();
        }
}
