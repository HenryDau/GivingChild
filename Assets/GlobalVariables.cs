using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class GlobalVariables {

	public static bool isPaused = false;
	public static int difficulty = 0; // 0 for toddler, 1-3 for levels 1-3
	public static int trashToMiss = 10;
	public static bool level_1_complete = false;
	public static bool level_2_complete = false;

	private static Camera cam;
	public static float height;
	public static float width;
	public static float SHRINK_FACTOR = .05f;


	static void Start() {
		Load ();
		LoadCamera ();
	}

	public static void LoadCamera(){
		cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;

		Debug.Log (height + " : " + width);
	}

	public static void pause() {
		if (isPaused) {
			isPaused = false;
			Time.timeScale = 1;
		} else {
			isPaused = true;
			Time.timeScale = 0;
		}
	}

	public static void completeLevel() {
		if (difficulty == 1) {
			level_1_complete = true;
		} else if (difficulty == 2) {
			level_2_complete = true;
		}
	}

	public static void Load() {
		if (File.Exists (Application.persistentDataPath + "/data.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/data.dat", FileMode.OpenOrCreate);
			Data data = new Data ();
			data = (Data)bf.Deserialize (file);
			file.Close ();

			level_1_complete = data.level_1_complete;
			level_2_complete = data.level_2_complete;
		}
	}

	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/data.dat", FileMode.OpenOrCreate);

		Data data = new Data ();
		data.level_1_complete = level_1_complete;
		data.level_2_complete = level_2_complete;

		bf.Serialize (file, data);
		file.Close ();
	}

	[Serializable]
	class Data {
		public bool level_1_complete = false;
		public bool level_2_complete = false;
	}
}
