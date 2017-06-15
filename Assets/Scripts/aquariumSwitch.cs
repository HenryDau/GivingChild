using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aquariumSwitch : MonoBehaviour {

    public string switchScene;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //SceneManager.LoadScene(switchScene.name);
        Application.LoadLevel(switchScene);
    }


}
