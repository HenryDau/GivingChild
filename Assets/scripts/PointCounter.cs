using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointCounter : MonoBehaviour {

    //This holds the points. 
    public int point = 0;
	public int trashMissed = 0;
    public Text pointText;

	public GUISkin skin;
	private bool showWinMenu = false;
	private bool showLoseMenu = false;
	private string winText = "Congratulations, you cleaned up this reef! You collected ";
	private string winText2 = " pieces of trash!";
	private string loseText = "You missed too many pieces of trash and could not protect the reef!";
    void Start(){
		//pointText.text = "Trash Missed: " + trashMissed.ToString () + "\nPoints: " + point.ToString();
		//pointText.text = "Points: " + point.ToString();
		pointText.text = "";
    }

    private void Update()
    {
		//pointText.text = "Trash Missed: " + trashMissed.ToString () + "\nPoints: " + point.ToString();
		//pointText.text = "Points: " + point.ToString();

		if (point >= 50) {
			showWinMenu = true;
			GlobalVariables.completeLevel ();
			GlobalVariables.Save ();
			GlobalVariables.difficulty = 0;
		}
		if (GlobalVariables.difficulty == 1 && trashMissed >= GlobalVariables.trashToMiss) {
			showLoseMenu = true;
		}
    }

	void OnGUI() {
		if (showWinMenu) {
			GUI.skin = skin;
			GUI.Window (1, new Rect (0, 0, Screen.width, Screen.height), ShowMenu, "");
		} else if (showLoseMenu) {
			GUI.skin = skin;
			GUI.Window (2, new Rect (0, 0, Screen.width, Screen.height), ShowMenu, "");
		}
	}

	void ShowMenu(int windowID) {
		if (windowID == 1) {
			GUI.Label(new Rect(20, Screen.height / 8, Screen.width - 40, (Screen.height / 2) - 60), winText + point + winText2);
		} else if (windowID == 2) {
			GUI.Label(new Rect(20, Screen.height / 8, Screen.width - 40, (Screen.height / 2) - 60), loseText);
		}


		if (GUI.Button (new Rect (20, (Screen.height / 4), (Screen.width / 2) - 30, (Screen.height / 2) - 20), "Main Menu")) {
			SceneManager.LoadScene ("bubble_menu");
			Time.timeScale = 1;
			GlobalVariables.isPaused = false;
		}
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height / 4), (Screen.width / 2) - 20, (Screen.height / 2) - 20), "Replay")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Time.timeScale = 1;
			GlobalVariables.isPaused = false;
		}

	}

}
