using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHealingScript : MonoBehaviour {

	public AudioClip healing;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();

	}

	public void play()
	{
		source.PlayOneShot(healing, 1f);
	}

	//Plays a sound for healed fish.
}
