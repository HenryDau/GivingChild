using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class aquaruimFishLogic : MonoBehaviour {

    public string fishID;
    public string fishName = "Terry";
    public bool fishOwned = true;
    private TextMesh textComponent;

	// Use this for initialization
	void Start () {
        textComponent = GetComponentInChildren<TextMesh>();
    }

	// Update is called once per frame
	void Update () {
        transform.localScale = transform.localScale;
	}

    private void OnEnable()
    {
        textComponent = GetComponentInChildren<TextMesh>();
        Debug.Log(Application.persistentDataPath);
        load();
        if (fishOwned == false)
        {
            enabled = false;
        }
        updateName();
    }

    private void OnDisable()
    {
        save();
    }

    private void OnMouseDown()
    {
        //changes the object being renamed to the one clicked
        GameObject controler = GameObject.Find("RenameControler");
        ((renameControlerScript)(controler.GetComponent("renameControlerScript"))).fishToRename = gameObject;
    }

    private void load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + fishID + ".dat"))
        {
            //read from file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + fishID + ".dat", FileMode.Open);
            FishData data = (FishData)bf.Deserialize(file);
            file.Close();

            //load data from the FishData Class
            fishName = data.name;
            fishOwned = data.unlocked;
        }
        else // create a new save file (this should happen the first time this script is loaded to initializs the save file)
        {
            save();
        }
    }

    void save() // saves the information to a file
    {
        //create a new file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + fishID + ".dat");
        FishData data = new FishData();

        //enter data to the class
        data.name = fishName;
        data.unlocked = fishOwned;

        //serialise the class to the file
        bf.Serialize(file, data);
        file.Close();
    }

    //updates the text field
    public void updateName()
    {
        textComponent.text = fishName;
    }
}

[Serializable]
class FishData // a class that holds all the data that each aquarium fish should have (add additional elements as needed)
{
    public string name;
    public bool unlocked;
}
