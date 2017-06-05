using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownfishSpawner : MonoBehaviour {

	public GameObject objectToSpawn; // the prefab for which to spawn
	public float maxY = 10.0f; // value
	public float minY = -10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (!GlobalVariables.isPaused) {
			Vector3 position = new Vector3 (
			                   transform.position.x - 20,
							   transform.position.y + Random.Range (minY, maxY),
			                   transform.position.z - 1
			                   );
			Instantiate (objectToSpawn, position, Quaternion.identity);
		}
	}
}
