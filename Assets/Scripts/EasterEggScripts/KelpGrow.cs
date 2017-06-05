using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpGrow : MonoBehaviour {

	public GameObject objectToSpawn; // the prefab for which to spawn

	public int MAX_SIZE = 8;
	public int MIN_SIZE = 4;
	public float GROWTH_RATE = .3f;

	public int MIN_X = -150;
	public int MIN_Y = -75;
	public int MAX_X = 150;
	public int MAX_Y = -30;

	private int size;
	private int lastPoint;
	PointCounter points;

	// Use this for initialization
	void Start () {
		
		size = Random.Range (MIN_SIZE, MAX_SIZE);
		transform.localScale = new Vector3 (1, 1, 0);

		GameObject PointCounter = GameObject.Find ("Points");
		points = PointCounter.GetComponent<PointCounter> ();
		lastPoint = points.point;
	}

	// Update is called once per frame
	void Update () {
		if (points.point != lastPoint) {
			lastPoint = points.point;
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
		
		// Spawn new Kelp
		Vector3 position = new Vector3 (Random.Range(MIN_X, MAX_X), Random.Range (MIN_Y, MAX_Y), 45);
		Instantiate (objectToSpawn, position, Quaternion.identity);

	}
}
