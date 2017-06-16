using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour {

	public void loadScene(string scene)
	{
		GlobalVariables.Load ();
		if (GlobalVariables.difficulty == 2) {
			if (GlobalVariables.level_1_complete) {
				Application.LoadLevel (scene);
			}
		} else if (GlobalVariables.difficulty == 3) {
			if (GlobalVariables.level_2_complete) {
				Application.LoadLevel (scene);
			}
		} else {
			Application.LoadLevel (scene);
		}
	}

    public void overloadScene(string scene)
    {
        Application.LoadLevel(scene);
    }
		

    public void openUrl(string url)
    {
        Application.OpenURL(url);
    }

	public static void loadMenu(string scene)
	{
		Application.LoadLevel(scene);
	}

	public void setDifficulty(int level) {
		GlobalVariables.difficulty = level;
	}
}
