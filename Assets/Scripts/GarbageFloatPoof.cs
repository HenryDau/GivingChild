﻿//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFloatPoof : MonoBehaviour {

	public int X_BOUND = 175;
	public int Y_BOUND = 75;
	public float MAX_SPEED = 1.5f;

	private Rigidbody2D rb;
 

    // Use this for initialization
    void Start () {
		int value = UnityEngine.Random.Range (0, 100);
		int speed = UnityEngine.Random.Range (5, 13);
		rb = GetComponent<Rigidbody2D> ();
		if (value < 50) {
			rb.velocity = new Vector2 (-(float)speed / 10, 0);

			transform.position = new Vector3 (
				transform.position.x * -1,
				transform.position.y,
				transform.position.z
			);
		} else {
			rb.velocity = new Vector2 ((float)speed / 10, 0);
		}
    }

	void OnMouseDown(){

        GameObject Dropplay = GameObject.Find("Playdrop");
        Playdropscript drop = Dropplay.GetComponent<Playdropscript>();
        drop.play();
        //This plays a sound from another game objects audio source using another script. 
        //You need to do this if your object is being destroyed or else the sound won't play, even if you have it before the destroy.
        //If it's not being destroyed you can use the objects own audio source and files e.g.
        //AudioSource source = GetComponent<AudioSource>();
        //source.PlayOneShot(WaterDrop, 1f);

        

        //Finds Points and increments public variable
        GameObject PointCounter = GameObject.Find("Points");
        PointCounter Points = PointCounter.GetComponent<PointCounter>();
        Points.point += 1;

		Destroy (gameObject);
       
	}

 
    // Update is called once per frame
    void Update () {
       
        // Rotate the trash
		transform.Rotate (Vector3.back * Time.deltaTime * UnityEngine.Random.Range(3,10));

		// Get the position
		Vector3 pos = transform.position;

		// Turn around if at the end of the map
		if ((rb.velocity.x > 0 && pos.x > X_BOUND) || (rb.velocity.x < 0 && pos.x < -X_BOUND))
			Destroy (gameObject);
			//rb.velocity = new Vector3( rb.velocity.x * -1, rb.velocity.y, rb.velocity.z);
		

		// Keep in the y bounds
		if (pos.y > Y_BOUND && rb.velocity.y > 0 || (pos.y < -Y_BOUND && rb.velocity.y < 0))
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y * -1);
		

		// Make sure it stays in the same plane
		if (pos.z != 0) {
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);
			transform.position = new Vector3 (pos.x, pos.y, 0);
		}

		limitSpeed ();

		// Move the object
		transform.position = new Vector3 (
			transform.position.x + rb.velocity.x,
			transform.position.y + rb.velocity.y,
			transform.position.z
		);
	}

	void limitSpeed(){
		if (rb.velocity.magnitude > MAX_SPEED) {
			rb.velocity = rb.velocity.normalized * MAX_SPEED;
		}
	}
}
