using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childTransformScript : MonoBehaviour {

    public GameObject textParent;
    

	void OnEnable () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = textParent.transform.localPosition;
    }
}
