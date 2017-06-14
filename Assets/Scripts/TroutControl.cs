using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroutControl : MonoBehaviour {
	static GameObject fish1;
	static GameObject fish2;
	static GameObject fish3;
	Vector3 position;

	public GameObject objectToSpawn;
	public float min_X;
	public float max_X;
	public float min_Y;
	public float max_Y;

	// Use this for initialization
	void Start () {
		position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 28);
		fish1 = Instantiate (objectToSpawn, position, Quaternion.identity);
		position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 28);
		fish2 = Instantiate (objectToSpawn, position, Quaternion.identity);
		position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 28);
		fish3 = Instantiate (objectToSpawn, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GlobalVariables.isPaused) {
			if (fish1.GetComponent<fishHP> ().isDead && fish2.GetComponent<fishHP> ().isDead && fish3.GetComponent<fishHP> ().isDead) {
				//print ("Fish are dead");
				GlobalVariables.pause();
			}
		}

	}

	public static void healFish() {
		if (!fish1.GetComponent<fishHP> ().isDead) {
			fish1.GetComponent<fishHP> ().curr_HP = 100;
			fish1.GetComponent<fishHP> ().setHpBar ();
		}
		if (!fish2.GetComponent<fishHP> ().isDead) {
			fish2.GetComponent<fishHP> ().curr_HP = 100;
			fish2.GetComponent<fishHP> ().setHpBar ();
		}
		if (!fish3.GetComponent<fishHP> ().isDead) {
			fish3.GetComponent<fishHP> ().curr_HP = 100;
			fish3.GetComponent<fishHP> ().setHpBar ();
		}
		GameObject HealPlay = GameObject.Find ("Playheal");
		PlayHealingScript heal = HealPlay.GetComponent<PlayHealingScript> ();
		heal.play ();
		
	}
}
