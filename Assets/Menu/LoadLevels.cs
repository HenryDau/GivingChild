using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour {

	public void loadScene(string scene)
	{
		Application.LoadLevel (scene);
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
		if (level == 1) {
			GlobalVariables.trashToCollect = 100;
		} else if (level == 2) {
			GlobalVariables.trashToCollect = 500;
		} else if (level == 3) {
			GlobalVariables.trashToCollect = 1000;
		}
	}
}
