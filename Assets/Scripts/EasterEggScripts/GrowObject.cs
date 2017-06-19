using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowObject : MonoBehaviour {

	public GameObject objectToSpawn; // the prefab for which to spawn

	public float MAX_SIZE = 15f;
	public float MIN_SIZE = 20f;
	public float GROWTH_RATE = 1f;

	public float MIN_X = -150;
	public float MIN_Y = -75;
	public float MAX_X = 150;
	public float MAX_Y = -30;
	public float MIN_Z = 0;
	public float MAX_Z = 0;

	public bool randomizeRotation = false;
	public bool growOnPoint = true;
	public bool growOnMiss = false;
	public bool changeSizeDynamically = true;

	private float size;
	private int lastPoint;
	private int lastMissed;
	PointCounter points;

	// Use this for initialization
	void Start () {

		GlobalVariables.LoadCamera ();

		if (growOnPoint) {
			MIN_X = -GlobalVariables.width / 2;
			MAX_Y = -GlobalVariables.height / 3;
			MAX_X = GlobalVariables.width / 2;
			MIN_Y = -GlobalVariables.height / 2;

		} else {
			MIN_X = -GlobalVariables.width / 2;
			MIN_Y = -GlobalVariables.height / 2;
			MAX_X = GlobalVariables.width / 2;
			MAX_Y = GlobalVariables.height / 2;
		}
			

		if (randomizeRotation){
			transform.rotation = Quaternion.AngleAxis (Random.Range(0,360), Vector3.forward);
		}

		// Come up with position variables
		float newY = Random.Range (MIN_Y, MAX_Y);
		float newZ = (float)MAX_Z - (float)newY / (float)MIN_Y * ((float)MAX_Z - (float)MIN_Z)+10;

		if (changeSizeDynamically) {
			
			transform.position = new Vector3 (Random.Range(MIN_X, MAX_X), newY, newZ);
			size = (float)Random.Range (MIN_SIZE, MAX_SIZE) * 
				(((float)MAX_Z - (float)transform.position.z) / ((float)MAX_Z - (float)MIN_Z))+21;
		
		} else {
			
			transform.position = new Vector3 (Random.Range(MIN_X, MAX_X), newY, Random.Range(MIN_Z, MAX_Z));
			size = (float)Random.Range (MIN_SIZE, MAX_SIZE);
		}

		transform.localScale = new Vector3 (0, 0, 0);

		if (growOnPoint) {
			GameObject PointCounter = GameObject.Find ("Points");
			points = PointCounter.GetComponent<PointCounter> ();
			lastPoint = points.point;
		} 

		if (growOnMiss) {
			GameObject PointCounter = GameObject.Find ("Points");
			points = PointCounter.GetComponent<PointCounter> ();
			lastMissed = points.trashMissed;
		}
	}

	// Update is called once per frame
	void Update () {
		if (points.point != lastPoint && growOnPoint) {
			lastPoint = points.point;
			grow ();
		}

		if (points.trashMissed != lastMissed && growOnMiss) {
			lastMissed = points.trashMissed;
			grow ();
		}

	}

	void grow(){

		if (transform.localScale.x < size) {

			// Grow
			transform.localScale += new Vector3 (GROWTH_RATE, GROWTH_RATE, 0);

			if (transform.localScale.x >= size) {
				spawn ();
			}
		}
	}

	void spawn(){

		// Spawn new Object
		Vector3 position = new Vector3 (Random.Range(MIN_X, MAX_X), Random.Range (MIN_Y, MAX_Y), 0);
		var newObject = Instantiate (objectToSpawn, position, Quaternion.identity);
		newObject.transform.parent = gameObject.transform.parent;

	}
}

