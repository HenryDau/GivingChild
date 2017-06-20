using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizeFix : MonoBehaviour {
    public bool textFix = false;

	// Use this for initialization
	void Start () {
        Debug.Log("called");
        if (true)
        {
            //Debug.Log("Width: "+Screen.width);
            //Debug.Log("Height: " + Screen.height);
            double xratio = 1 / ((double)Screen.width / 2000);
            double yratio = 1 / ((double)Screen.height / 1000);
            //Debug.Log("x: " + xratio);
            //Debug.Log("y: " + yratio);
            transform.localScale = new Vector3(transform.localScale.x * (float)xratio, transform.localScale.y * (float)yratio, transform.localScale.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
