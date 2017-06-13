using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparklescript : MonoBehaviour {
    public AudioClip sparkle;
    private AudioSource source;

   
    void Start () {
        source = GetComponent<AudioSource>();
    }

    public void play()
    {
        source.PlayOneShot(sparkle, 1f);
    }
}
