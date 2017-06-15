using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuestions : MonoBehaviour {

	public GameObject objectToSpawn; // the prefab for which to spawn
	public float maxY;
	public float minY;
	public float spawnChance;
	int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.difficulty >= 3 && !GlobalVariables.isPaused) {
			counter++;
			if (counter % spawnChance == 0) {
				Vector3 position = new Vector3 (200, Random.Range (minY, maxY), 18);
				Instantiate (objectToSpawn, position, Quaternion.identity);
			}
		}
	}
}
