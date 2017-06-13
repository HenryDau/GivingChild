using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroutControl : MonoBehaviour {
	GameObject fish1;
	GameObject fish2;
	GameObject fish3;
	Vector3 position;

	public GameObject objectToSpawn;
	public float min_X;
	public float max_X;
	public float min_Y;
	public float max_Y;

	// Use this for initialization
	void Start () {
		position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 28);
		fish1 = Instantiate (objectToSpawn, position, Quaternion.identity);
		position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 28);
		fish2 = Instantiate (objectToSpawn, position, Quaternion.identity);
		position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 28);
		fish3 = Instantiate (objectToSpawn, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GlobalVariables.isPaused) {
			if (fish1.GetComponent<fishHP> ().isDead && fish2.GetComponent<fishHP> ().isDead && fish3.GetComponent<fishHP> ().isDead) {
				//print ("Fish are dead");
				GlobalVariables.pause();
			}
		}

	}
}
