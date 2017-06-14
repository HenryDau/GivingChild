using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables {

	public static bool isPaused = false;
	public static int difficulty = 0; // 0 for toddler, 1-3 for levels 1-3
	public static void pause() {
		if (isPaused) {
			isPaused = false;
			Time.timeScale = 1;
		} else {
			isPaused = true;
			Time.timeScale = 0;
		}
	}

}
