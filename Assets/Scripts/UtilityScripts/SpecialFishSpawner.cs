using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFishSpawner : MonoBehaviour {

	public List<GameObject> commonFish;
	public List<GameObject> rareFish;
	public List<GameObject> epicFish;
	public List<GameObject> legendaryFish;

	public float maxY = 50.0f; // value
	public float minY = -50.0f;
	public float spawnChance = 1f; //percent chance per second to spawn
	int counter = 500;

	// Rarities for fish spawning
	const int LEGENDARY = 50;
	const int EPIC = 150;
	const int RARE = 300;
	const int COMMON = 500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!GlobalVariables.isPaused) {
			counter++;
			//float random = Random.Range (0f, 100.0f);
			if (counter % spawnChance == 0) {
				//if (random < (spawnChance) * Time.deltaTime) {
				//Vector3 position = new Vector3 (transform.position.x, Random.Range (minY, maxY), 18);
				Vector3 position = new Vector3 (-200, Random.Range (minY, maxY), 28);

				int i = Random.Range (0, 1000);
				GameObject fish;

				if (i < COMMON) {
					//Spawn Common
					fish = commonFish[Random.Range(0, commonFish.Count)];

				} else if (i < COMMON + RARE) { 
					// Spawn Rare
					fish = rareFish[Random.Range(0, rareFish.Count)];

				} else if (i < COMMON + RARE + EPIC) {
					// Spawn Epic
					fish = epicFish[Random.Range(0, epicFish.Count)];

				} else {
					// Spawn Legendary
					fish = legendaryFish[Random.Range(0, legendaryFish.Count)];
				}

				Instantiate (fish, position, Quaternion.identity);
			}
		}
	}
}
