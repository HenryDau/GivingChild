using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renameControlerScript : MonoBehaviour {

    public GameObject fishToRename;
    public InputField inputField;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = fishToRename.transform.localPosition;
	}

    public void renameFish(string newName)
    {
        ((aquaruimFishLogic)fishToRename.GetComponent("aquaruimFishLogic")).fishName = newName;
        
        ((aquaruimFishLogic)fishToRename.GetComponent("aquaruimFishLogic")).updateName();
    }
}
