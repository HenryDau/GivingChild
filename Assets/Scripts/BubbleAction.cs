using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAction : MonoBehaviour {
	public List<GameObject> objectToSpawn;

	public void Punish() {
		int trashPicker = Random.Range(0, objectToSpawn.Count);
		for (float i = -GlobalVariables.height / 3; i < GlobalVariables.height / 3; i += GlobalVariables.height / 21) {
			Vector3 position = new Vector3 (-GlobalVariables.width / 2, i, 0);
			var trash = Instantiate (objectToSpawn[trashPicker], position, Quaternion.identity);
			trash.transform.localScale *= GlobalVariables.SHRINK_FACTOR;

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