using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMove : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 goalPoint;

	public float MIN_X = -150;
	public float MIN_Y = -50;
	public float MAX_X = 150;
	public float MAX_Y = 50;
	private float MIN_SPEED = 9;
	private float MAX_SPEED = 12;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
		goalPoint = rb.position;

		GlobalVariables.LoadCamera ();

		MIN_X = -GlobalVariables.width / 2f;
		MAX_X = GlobalVariables.width / 2f;
		MIN_Y = -GlobalVariables.height / 2f;
		MAX_Y = GlobalVariables.height / 2f;

    }

    // Update is called once per frame
    void Update(){
		
    }

	void OnMouseDown() {

		if (!GlobalVariables.isPaused) {
			
			goalPoint.x = Random.Range (MIN_X, MAX_X);
			goalPoint.y = Random.Range (MIN_Y, MAX_Y);

			Debug.Log (goalPoint);

			rb.velocity = (goalPoint - rb.position).normalized * Random.Range (MIN_SPEED, MAX_SPEED);
			Vector2 dir = rb.velocity;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			Vector3 copyscale = transform.localScale;

			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
	}
}