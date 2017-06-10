using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    //This holds the points. 
    public int point = 0;
	public int trashMissed = 0;
    public Text pointText;

    void Start(){
		//pointText.text = "Trash Missed: " + trashMissed.ToString () + "\nPoints: " + point.ToString();
		pointText.text = "Points: " + point.ToString();
    }

    private void Update()
    {
		//pointText.text = "Trash Missed: " + trashMissed.ToString () + "\nPoints: " + point.ToString();
		pointText.text = "Points: " + point.ToString();
    }

}
