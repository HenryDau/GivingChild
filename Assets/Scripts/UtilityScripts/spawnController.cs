﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{

    //place the spawner object that uses this script at the x location that you desire to spawn the object at

    public List<GameObject> objectToSpawn; // the prefab for which to spawn
    public float maxY = 50.0f; // value
    public float minY = -50.0f;
    public float spawnChance = 90f; //number of frames to spawn something
	int counter = 0;

    // Use this for initialization
    void Start()
    {
		spawnChance = 120f - (20 * GlobalVariables.difficulty);
		GlobalVariables.LoadCamera ();

    }

    // Update is called once per frame
    void Update()
    {
		counter++;
        //float random = Random.Range(0f, 100.0f);
		if (counter % spawnChance == 0 && !GlobalVariables.isPaused) {
			//if (random < (spawnChance) * Time.deltaTime) {
				//Vector3 position = new Vector3 (transform.position.x, Random.Range (minY, maxY), 18);
			Vector3 position = new Vector3 (-GlobalVariables.width / 2, Random.Range (GlobalVariables.height / 2, -GlobalVariables.height / 2), 18);
			var trash = Instantiate (objectToSpawn[Random.Range (0, objectToSpawn.Count)], position, Quaternion.identity);
			trash.transform.localScale *= GlobalVariables.SHRINK_FACTOR;
		}
    }

	void Despawn() {
		
	}



}