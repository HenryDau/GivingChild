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
	private string winText = "Congratulations, you cleaned up this reef! You collected ";
	private string winText2 = " pieces of trash!";
    void Start(){
		//pointText.text = "Trash Missed: " + trashMissed.ToString () + "\nPoints: " + point.ToString();
		pointText.text = "Points: " + point.ToString();
    }

    private void Update()
    {
		//pointText.text = "Trash Missed: " + trashMissed.ToString () + "\nPoints: " + point.ToString();
		pointText.text = "Points: " + point.ToString();

		if (point >= 50) {
			showWinMenu = true;
		}
    }

	void OnGUI() {
		if (showWinMenu) {
			GUI.skin = skin;
			GUI.Window (1, new Rect (0, 0, Screen.width, Screen.height), ShowMenu, "");
		}
	}

	void ShowMenu(int windowID) {
		GUI.Label(new Rect(20, Screen.height / 8, Screen.width - 40, (Screen.height / 2) - 60), winText + point + winText2);

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
