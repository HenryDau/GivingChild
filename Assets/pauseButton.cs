using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour {

	void OnMouseDown() {
		if (GlobalVariables.isPaused == true) {
			GlobalVariables.isPaused = false;
		} else if (GlobalVariables.isPaused == false) {
			GlobalVariables.isPaused = true;
		}

	}
}
