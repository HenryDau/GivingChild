using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePop : MonoBehaviour {

    public AudioClip clip;
    private AudioSource source;

    private void Awake()
    {
      DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

        public void play()
    {
        source.PlayOneShot(clip, 1f);
       // Destroy();
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this. gameObject);
    }
}
