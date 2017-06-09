using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Hi boys, just a harmless comment swimming thru a seamless 
//git commit, hopefully :)
public class FishMovement : MonoBehaviour {
	public int MIN_X = -10;
	public int MIN_Y = -6;
	public int MAX_X = 11;
	public int MAX_Y = 5;
	public float MIN_SPEED = 1;
	public float MAX_SPEED = 2;
	private Rigidbody2D rb2d;
	private Vector2 goalPoint;

    private Transform[] children;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		selectNewPoint();
    }
	
	// Update is called once per frame
	void Update () {
		if (pointReached()) {
			selectNewPoint ();
		}
	}

	private void selectNewPoint()
	{
        Transform child = transform.GetChild(0);
        transform.DetachChildren(); //detach children

        goalPoint.x = Random.Range ((float)MIN_X, (float)MAX_X);
		goalPoint.y = Random.Range ((float)MIN_Y, (float)MAX_Y);
		rb2d.velocity = (goalPoint - rb2d.position).normalized * Random.Range (MIN_SPEED, MAX_SPEED);
		Vector2 dir = rb2d.velocity;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		Vector3 copyscale = transform.localScale;
		if (rb2d.velocity.magnitude > (MAX_SPEED + MIN_SPEED) / 2.0) {
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			copyscale = transform.localScale;
			copyscale.y = Mathf.Abs (copyscale.y);
			copyscale.x = Mathf.Abs (copyscale.x);
			if (angle < -90 || angle > 90)
				copyscale.y *= -1;
			transform.localScale = copyscale;
		} else {
			transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
			copyscale.x = Mathf.Abs (copyscale.x);
			copyscale.y = Mathf.Abs (copyscale.y);
			if (angle < -90 || angle > 90)
				copyscale.x *= -1;
			transform.localScale = copyscale;
		}

        child.parent = transform; //reatach children
    }
	private bool pointReached(){
		return (goalPoint - rb2d.position).magnitude < 1;
	}

}
