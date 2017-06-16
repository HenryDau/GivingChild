using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Swim : MonoBehaviour {

	private float speed;
	public bool keepSwimming = true;
	public bool clickable = false;
	public float MIN_SPEED = .5f;
	public float MAX_SPEED = .15f;
    public int maxFishInAquarium = 1;
    public string fishID;
	private float X_BOUND;
	private float Y_BOUND;

	// Use this for initialization
	void Start () {
		speed = Random.Range (MIN_SPEED, MAX_SPEED);

		X_BOUND = GlobalVariables.width / 2f;
		Y_BOUND = GlobalVariables.height / 2f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!GlobalVariables.isPaused) {
			
			Vector3 pos = transform.localPosition;
			if ((speed > 0 && pos.x > X_BOUND) || (speed < 0 && pos.x < -X_BOUND)) {
				if (keepSwimming) {
					speed *= -1;
					transform.Rotate (Vector3.up, 180);
					pos.y = (float)(.5 - Random.value) * Y_BOUND;
				} else {
					Destroy (gameObject);
				}
			}

			transform.localPosition = new Vector3 (
				pos.x + (float)speed / 10,
				pos.y,
				pos.z
			);
		}
	}

	void OnMouseDown(){
		if (clickable && !GlobalVariables.isPaused) {
            GameObject source = GameObject.Find("Playsparkle");
            Sparklescript sparkle = source.GetComponent<Sparklescript>();
            sparkle.play();

            //Debug.Log ("Add to aquarium");
            int counter = 1;
            while (counter <= maxFishInAquarium)
            {
                if (File.Exists(Application.persistentDataPath + "/" + fishID + counter + ".dat"))
                {
                    //read from file
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + "/" + fishID + counter + ".dat", FileMode.Open);
                    FishData data = (FishData)bf.Deserialize(file);
                    file.Close();
                    //checks data from the FishData Class
                    if (data.unlocked == false)
                    {
                        Debug.Log("Editing created file to unlock fish");
                        createNewSave(counter);
                        break;
                    }
                }
                else
                {
                    createNewSave(counter);
                    break;
                }
                counter++;
            }
			Destroy (gameObject);
		}
	}

    private void createNewSave(int number)
    {
        //create a new file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + fishID + number + ".dat");
        FishData data = new FishData();

        //enter data to the class
        data.name = "";
        data.unlocked = true;

        //serialise the class to the file
        bf.Serialize(file, data);
        file.Close();
    }
}
