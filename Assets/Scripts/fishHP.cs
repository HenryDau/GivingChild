using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishHP : MonoBehaviour {

	public float max_HP = 100f;
	public float curr_HP = 0f;
	public GameObject hpBar;
	public bool isDead = false;
	private SpriteRenderer sr;
	public Material normal;
	public Material hit;
	private int hit_timer = 10;


	public int min_X;
	public int max_X;
	public int min_Y;
	public int max_Y;
	public float min_speed;
	public float max_speed;

	private float speed;
	private Vector3 goal;

	void Start() {
		curr_HP = max_HP;
		sr = GetComponent<SpriteRenderer> ();
		selectNewPoint ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Trash") {
			decreaseHP ();
		}
	}

	void decreaseHP() {
		if (!GlobalVariables.isPaused) {
			curr_HP -= 10;
			setHpBar (curr_HP);
			if (curr_HP <= 0) {
				floatUp ();
			}
		}
	}

	void setHpBar(float myHP) {
		//print (14 * (myHP / max_HP));
		RectTransform rt = hpBar.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2 (14 * (myHP / max_HP), 2);
		sr.material = hit;
		hit_timer = 0;
	}

	void Update() {
		if (!GlobalVariables.isPaused) {
			hit_timer++;
			if (hit_timer == 10) {
				sr.material = normal;
			}

			if (!isDead) {
				if (goal == transform.position) {
					selectNewPoint ();
				}
			}

			transform.position = Vector3.MoveTowards (transform.position, goal, speed * Time.deltaTime);
		}
	}

	void selectNewPoint() {
		goal = new Vector3 (Random.Range (min_X, max_X), Random.Range (min_Y, max_Y), transform.position.z);
		speed = Random.Range (min_speed, max_speed);

		if (goal.x > transform.position.x) {
			sr.flipX = false;
		} else if (goal.x < transform.position.x) {
			sr.flipX = true;
		}

	}

	void floatUp() {
		isDead = true;
		sr.flipY = true;
		goal = new Vector3 (transform.position.x, 100, transform.position.z);
		speed = Random.Range (min_speed, max_speed);
	}

	void OnMouseDown() {
		decreaseHP ();
	}
}
