using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAction : MonoBehaviour {
	public List<GameObject> objectToSpawn;

	public void Punish() {
		int trashPicker = Random.Range(0, objectToSpawn.Count);
		for (int i = -30; i < 20; i = i + 8) {
			Vector3 position = new Vector3 (-200, i, 18);
			Instantiate (objectToSpawn[trashPicker], position, Quaternion.identity);

		}
			
	}

	public void Reward(GameObject[] allTrash) {
		
		for (int i = 0; i < allTrash.Length; i++) {
			GameObject trashInstance = allTrash [i];
			GameObject PointCounter = GameObject.Find ("Points");
			PointCounter Points = PointCounter.GetComponent<PointCounter> ();
			Points.point += 1;

			Destroy (trashInstance);

		}
		GameObject SwooshPlay = GameObject.Find ("Playswoosh");
		playbottlescript swoosh = SwooshPlay.GetComponent<playbottlescript> ();
		swoosh.play ();
	}

	public void Reward(GameObject[] allTrash, string overload) {

		for (int i = 0; i < allTrash.Length; i++) {
			GameObject trashInstance = allTrash [i];
			Destroy (trashInstance);

		}
		GameObject Squeakplay = GameObject.Find ("Playsqueak");
		playbottlescript squeak = Squeakplay.GetComponent<playbottlescript> ();
		squeak.play ();
	}
}