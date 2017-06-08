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
    private int speed;
    public bool keepSwimming = true;
    public float xdirection;
    public float ydirection;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
		goalPoint = rb.position;
        speed = 1;
        goalPoint.x = Random.Range((float)MIN_X, (float)MAX_X);
        goalPoint.y = Random.Range((float)MIN_Y, (float)MAX_Y);
        xdirection = goalPoint.x;
        ydirection = goalPoint.y;
        rb.velocity = (goalPoint - rb.position).normalized * Random.Range(MIN_SPEED, MAX_SPEED);
        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector3 copyscale = transform.localScale;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalVariables.isPaused)
        {
            stayInBounds();
           
        }
    }

	void OnMouseDown() {
		
		goalPoint.x = Random.Range ((float)MIN_X, (float)MAX_X);
		goalPoint.y = Random.Range ((float)MIN_Y, (float)MAX_Y);
        xdirection = goalPoint.x;
        ydirection = goalPoint.y;
		rb.velocity = (goalPoint - rb.position).normalized * Random.Range (MIN_SPEED, MAX_SPEED);
		Vector2 dir = rb.velocity;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		Vector3 copyscale = transform.localScale;

		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

    void stayInBounds()
    {

        // Turn around if at the end of the map
        if ((rb.velocity.x > 0 && transform.position.x > MAX_X)
            || (rb.velocity.x < 0 && transform.position.x < -MAX_X))
        {
            goalPoint.x = Random.Range((float)MIN_X, (float)MAX_X);
            goalPoint.y = Random.Range((float)MIN_Y, (float)MAX_Y);
            xdirection = goalPoint.x;
            ydirection = goalPoint.y;
            rb.velocity = (goalPoint - rb.position).normalized * Random.Range(MIN_SPEED, MAX_SPEED);
            Vector2 dir = rb.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector3 copyscale = transform.localScale;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Keep in the y bounds
        if ((transform.position.y > MAX_Y && rb.velocity.y > 0) || (transform.position.y < -MAX_Y && rb.velocity.y < 0))
        {
            goalPoint.x = Random.Range((float)MIN_X, (float)MAX_X);
            goalPoint.y = Random.Range((float)MIN_Y, (float)MAX_Y);
            xdirection = goalPoint.x;
            ydirection = goalPoint.y;
            rb.velocity = (goalPoint - rb.position).normalized * Random.Range(MIN_SPEED, MAX_SPEED);
            Vector2 dir = rb.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector3 copyscale = transform.localScale;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        // Make sure it stays in the same plane
        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}