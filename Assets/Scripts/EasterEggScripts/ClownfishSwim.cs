using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownfishSwim : MonoBehaviour {

	public int lifetime = 240;
	private int count = 0;
	private float startX;

	// Use this for initialization
	void Start () {
		startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (count > lifetime)
			Destroy (gameObject);

		if (!GlobalVariables.isPaused){

			count++;

			transform.position = new Vector3 (
				startX + (float)(count * 4f / (float) lifetime),
				transform.position.y,
				transform.position.z
			);

			//transform.Rotate (Vector3.down, (float)lifetime / 5 / 360);
		}
	}
}
