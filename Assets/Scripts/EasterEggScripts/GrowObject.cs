using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowObject : MonoBehaviour {

	public GameObject objectToSpawn; // the prefab for which to spawn

	public int MAX_SIZE = 8;
	public int MIN_SIZE = 4;
	public float GROWTH_RATE = .3f;

	public int MIN_X = -150;
	public int MIN_Y = -75;
	public int MAX_X = 150;
	public int MAX_Y = -30;
	public int Z_SPAWN = 49;

	public bool randomizeRotation = false;
	public bool growOnPoint = true;
	public bool growOnMiss = false;

	private int size;
	private int lastPoint;
	private int lastMissed;
	PointCounter points;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3 (Random.Range(MIN_X, MAX_X), Random.Range (MIN_Y, MAX_Y), Z_SPAWN);

		if (randomizeRotation){
			transform.rotation = Quaternion.AngleAxis (Random.Range(0,360), Vector3.forward);
		}

		size = Random.Range (MIN_SIZE, MAX_SIZE);
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
		Vector3 position = new Vector3 (Random.Range(MIN_X, MAX_X), Random.Range (MIN_Y, MAX_Y), 49);
		Instantiate (objectToSpawn, position, Quaternion.identity);

	}
}

