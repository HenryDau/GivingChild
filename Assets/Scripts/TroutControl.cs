using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TroutControl : MonoBehaviour {
	GameObject fish1;
	GameObject fish2;
	GameObject fish3;
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
				showLoseMenu = true;
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
}
