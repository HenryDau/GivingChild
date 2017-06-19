using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFloatDraggable : MonoBehaviour {

	public float X_BOUND = GlobalVariables.width / 2f;
	public float Y_BOUND = GlobalVariables.height / 2f;
	public float MAX_SPEED = 1.5f;

	private Rigidbody2D rb;
	private bool pressed = false;
	private bool released = false;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 oldPosition;
	private Vector3 secondOldPosition;


	// Use this for initialization
	void Start () {

		X_BOUND = GlobalVariables.width / 2f;
		Y_BOUND = GlobalVariables.height / 2f;

		float speed = Random.Range (5, 8 + (2 * GlobalVariables.difficulty)) * GlobalVariables.SHRINK_FACTOR;
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, -(float)speed / 10, 0);
		//rb.velocity = new Vector3 (15 / 10, 0, 0);
		transform.position = new Vector3 (
			Random.Range (-X_BOUND, X_BOUND),
			Y_BOUND,
			0
		);

		oldPosition = transform.position;

		X_BOUND = GlobalVariables.width / 2f;
		Y_BOUND = GlobalVariables.height / 2f;
	}

	void OnMouseDown(){

		if (!GlobalVariables.isPaused) {

			pressed = true;

			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	
		}
	}

	void OnMouseDrag(){
		
		if (!GlobalVariables.isPaused) {

			secondOldPosition = oldPosition;

			oldPosition = transform.position;

			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint); //&#43; offset;

			transform.position = curPosition + offset;
		}

	}

	void OnMouseUp(){
		if (!GlobalVariables.isPaused) {
			pressed = false;
			released = true;

			rb.velocity = (transform.position - secondOldPosition) * Time.deltaTime * 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!GlobalVariables.isPaused) {

			limitSpeed ();

			if (!pressed && !released) {

				// Rotate the trash
				transform.Rotate (Vector3.back * Time.deltaTime * Random.Range (3, 10));

				stayInBounds ();

				// Move the object
				transform.position = new Vector3 (
					transform.position.x + rb.velocity.x,
					transform.position.y + rb.velocity.y,
					transform.position.z
				);
			}

			if (released) {

				stayInBounds ();
			
				transform.position = new Vector3 (
					transform.position.x + rb.velocity.x,
					transform.position.y + rb.velocity.y,
					transform.position.z
				);
			
			}
		}
	}

	void stayInBounds(){
		
		// Turn around if at the end of the map
		if ((rb.velocity.x > 0 && transform.position.x > X_BOUND) 
			|| (rb.velocity.x < 0 && transform.position.x < -X_BOUND)){

			//Finds Points and increments public variable
			GameObject PointCounter = GameObject.Find ("Points");
			PointCounter Points = PointCounter.GetComponent<PointCounter> ();
			Points.point += 1;

            GameObject playsound = GameObject.Find("Playbottle");
            playbottlescript sound = playsound.GetComponent<playbottlescript>();
            sound.play();

            Destroy (gameObject);

			//rb.velocity = new Vector2 (rb.velocity.x * -1, rb.velocity.y);
		}

		// Keep in the y bounds
		if ((transform.position.y > Y_BOUND && rb.velocity.y > 0) || (transform.position.y < (-Y_BOUND) && rb.velocity.y < 0))
			rb.velocity = new Vector2 (rb.velocity.x / 5, 0);//rb.velocity.y * -1);

		// Make sure it stays in the same plane
		if (transform.position.z != 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}
	}

	void limitSpeed(){
		if (rb.velocity.magnitude > MAX_SPEED) {
			rb.velocity = rb.velocity.normalized * MAX_SPEED;
		}
	}
}
