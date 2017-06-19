using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {

	public Transform button2;
	public Transform button3;

	// Use this for initialization
	void Start () {
		GlobalVariables.Load ();

		if (!GlobalVariables.level_1_complete) {
			button2.GetComponent<UnityEngine.UI.Button>().interactable = false;
			button3.GetComponent<UnityEngine.UI.Button>().interactable = false;
		}
		if (!GlobalVariables.level_2_complete) {
			button3.GetComponent<UnityEngine.UI.Button>().interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
