using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	private bool showLoseMenu = false;
	public GUISkin skin;
	private string loseText = "You lost. You collected ";
	private string loseText2 = " pieces of trash.";

	// Use this for initialization
	void Start () {

		min_X = -GlobalVariables.width / 2;
		max_X = GlobalVariables.width / 2;
		min_Y = -GlobalVariables.height / 2;
		max_Y = GlobalVariables.height / 2;

		if (GlobalVariables.difficulty >= 2) {
			position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), -2);
			fish1 = Instantiate (objectToSpawn, position, Quaternion.identity);
			fish1.transform.localScale *= GlobalVariables.SHRINK_FACTOR;
			fish1.transform.parent = gameObject.transform.parent;

			position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), -2);
			fish2 = Instantiate (objectToSpawn, position, Quaternion.identity);
			fish2.transform.localScale *= GlobalVariables.SHRINK_FACTOR;
			fish2.transform.parent = gameObject.transform.parent;

			position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), -2);
			fish3 = Instantiate (objectToSpawn, position, Quaternion.identity);
			fish3.transform.localScale *= GlobalVariables.SHRINK_FACTOR;
			fish3.transform.parent = gameObject.transform.parent;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.difficulty >= 2 && !GlobalVariables.isPaused) {
			if (fish1.GetComponent<fishHP> ().isDead && fish2.GetComponent<fishHP> ().isDead && fish3.GetComponent<fishHP> ().isDead) {
				//print ("Fish are dead");
				showLoseMenu = true;
				//GlobalVariables.resetDifficulty ();
			}
		}

	}
		
	void OnGUI() {
		if (showLoseMenu) {
			GUI.skin = skin;
			GUI.Window (1, new Rect (0, 0, Screen.width, Screen.height), ShowMenu, "");
		}
	}

	void ShowMenu(int windowID) {
		GameObject PointCounter = GameObject.Find ("Points");
		PointCounter Points = PointCounter.GetComponent<PointCounter> ();
		GUI.Label(new Rect(20, Screen.height / 8, Screen.width - 40, (Screen.height / 2) - 60), loseText + (Points.point) + loseText2);

		if (GUI.Button (new Rect (20, (Screen.height / 4), (Screen.width / 2) - 30, (Screen.height / 2) - 20), "Main Menu")) {
			GlobalVariables.pause ();
			showLoseMenu = false;
			LoadLevels.loadMenu ("bubble_menu");
			Time.timeScale = 1;
			GlobalVariables.isPaused = false;
		}
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height / 4), (Screen.width / 2) - 20, (Screen.height / 2) - 20), "Try Again")) {

			//LoadLevels.loadMenu ("OceanGame");
			//GlobalVariables.pause();
			//Application.LoadLevel(Application.loadedLevel);
			//Time.timeScale = 1;
			//GlobalVariables.isPaused = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Time.timeScale = 1;
			GlobalVariables.isPaused = false;
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
