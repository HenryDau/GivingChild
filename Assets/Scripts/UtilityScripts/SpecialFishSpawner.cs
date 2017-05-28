﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFishSpawner : MonoBehaviour {

	public List<GameObject> objectToSpawn; // the prefab for which to spawn
	public float maxY = 50.0f; // value
	public float minY = -50.0f;
	public float spawnChance = 1f; //percent chance per second to spawn
	int counter = 500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!GlobalVariables.isPaused) {
			counter++;
			float random = Random.Range (0f, 100.0f);
			if (counter % spawnChance == 0) {
				//if (random < (spawnChance) * Time.deltaTime) {
				//Vector3 position = new Vector3 (transform.position.x, Random.Range (minY, maxY), 18);
				Vector3 position = new Vector3 (-200, Random.Range (minY, maxY), 28);
				Instantiate (objectToSpawn [Random.Range (0, objectToSpawn.Count)], position, Quaternion.identity);
				//}
			}
		}
	}
}
