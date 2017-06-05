using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMove : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 goalPoint;

	public int MIN_X = -150;
	public int MIN_Y = -50;
	public int MAX_X = 150;
	public int MAX_Y = 50;
	public float MIN_SPEED = 90;
	public float MAX_SPEED = 120;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		goalPoint = rb.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		
		goalPoint.x = Random.Range ((float)MIN_X, (float)MAX_X);
		goalPoint.y = Random.Range ((float)MIN_Y, (float)MAX_Y);
		rb.velocity = (goalPoint - rb.position).normalized * Random.Range (MIN_SPEED, MAX_SPEED);
		Vector2 dir = rb.velocity;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		Vector3 copyscale = transform.localScale;

		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

}