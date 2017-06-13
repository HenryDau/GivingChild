using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour {

	public void loadScene(string scene)
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
}
