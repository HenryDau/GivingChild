using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour {
	private bool showPauseMenu = false;
	public GUISkin skin;

	void OnMouseDown() {
		showPauseMenu = true;
		if (GlobalVariables.isPaused == true) {
			GlobalVariables.isPaused = false;
		} else if (GlobalVariables.isPaused == false) {
			GlobalVariables.isPaused = true;
		}
	}

	void OnGUI() {
		if (showPauseMenu) {
			GUI.skin = skin;
			GUI.Window (1, new Rect (0, 0, Screen.width, Screen.height), ShowMenu, "");
		}
	}

	void ShowMenu(int windowID) {
		
		if (GUI.Button (new Rect (20, (Screen.height / 4), (Screen.width / 2) - 30, (Screen.height / 2) - 20), "Quit")) {
			GlobalVariables.isPaused = false;
			GlobalVariables.resetDifficulty ();
			LoadLevels.loadMenu ("bubble_menu");

			}
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height / 4), (Screen.width / 2) - 20, (Screen.height / 2) - 20), "Resume")) {
				
			GlobalVariables.isPaused = false;
			showPauseMenu = false;
				
			}
		
	}
}
