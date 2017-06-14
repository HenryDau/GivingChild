using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbottlescript : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    public void play()
    {
        source.PlayOneShot(sound, 1f);
    }
}

    //Plays a sound for a destroyed object.
