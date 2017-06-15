
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionBubble : MonoBehaviour {

	private float speed;
	Vector3 position;
	float initialY;
	float amplitude = 20.0f;
	float phase_angle;
	public GUISkin skin;
	public static bool wasCorrect = false;

	public Question[] questions; 
	private static List<Question> unansweredQuestions;
	private Question currentQuestion;

	//public spawnController spawn;


	// Use this for initialization
	void Start () {
		wasCorrect = false;
		speed = Random.Range (-0.5f, -1.0f);
		if (transform.position.x < 0) {
			speed = -speed;
		}
		initialY = transform.localPosition.y;
		phase_angle = Random.Range (0.0f, 360.0f);

		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<Question>();
		}

		GetRandomQuestion ();
	}

	void GetRandomQuestion() {
		if (unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<Question> ();
		}
		int randomIndex = Random.Range (0, unansweredQuestions.Count);

		currentQuestion = unansweredQuestions [randomIndex];

		unansweredQuestions.RemoveAt (randomIndex);

	}

	// Update is called once per frame
	void Update () {
		if (!GlobalVariables.isPaused) {
			position = transform.localPosition;
			if (position.x < -200) {
				Destroy (gameObject);
			}

			transform.localPosition = new Vector3 (
				position.x + speed,
				initialY + amplitude * Mathf.Sin (Time.fixedTime + phase_angle),
				position.z);
		}
	}

	public bool showQuestion = false;
	public bool doWindow0 = false;
	public bool doTrueFalse = false;
	public bool showExtra = false;

	void DoWindow0(int windowID) {

		GUI.Label(new Rect(20, Screen.height / 8, Screen.width - 40, (Screen.height / 2) - 60), currentQuestion.prompt);


		if (GUI.Button (new Rect (20, (Screen.height / 2) - 40, (Screen.width / 2) - 30, (Screen.height / 4)), currentQuestion.answerA)) {

			if (currentQuestion.isA) {
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;



			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;

			}
				
			showQuestion = false;
			showExtra = true;

		}

		if (GUI.Button (new Rect ((Screen.width / 2) + 10, (Screen.height / 2) - 40, (Screen.width / 2) - 30, Screen.height / 4), currentQuestion.answerB)) {

			if (currentQuestion.isB) {
				
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}

		if (GUI.Button (new Rect (20, ((Screen.height / 2) + (Screen.height / 4)) - 20, (Screen.width / 2) - 30, (Screen.height / 4)), currentQuestion.answerC)) {

			if (currentQuestion.isC) {
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}

		if (GUI.Button (new Rect ((Screen.width / 2) + 10, ((Screen.height / 2) + (Screen.height / 4)) - 20, (Screen.width / 2) - 30, (Screen.height / 4)), currentQuestion.answerD)) {

			if (currentQuestion.isD) {
				
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}

	
	

	}

	void DoTrueFalse(int windowID) {
		GUI.Label(new Rect(20, Screen.height / 4, Screen.width - 40, Screen.height / 2), currentQuestion.prompt);


		if (GUI.Button (new Rect (20, (Screen.height / 2), (Screen.width / 2) - 30, (Screen.height / 2) - 20), currentQuestion.answerA)) {

			if (currentQuestion.isA) {
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height / 2), (Screen.width / 2) - 20, (Screen.height / 2) - 20), currentQuestion.answerB)) {

			if (currentQuestion.isB) {
				
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}


			showQuestion = false;
			showExtra = true;
		}



	}

	void DoExtra(int windowID) {
		GUI.skin = skin;
		GUI.Label(new Rect(20, 60, Screen.width - 40, Screen.height), currentQuestion.extraComment);
		if (GUI.Button (new Rect ((Screen.width / 2) - (Screen.width / 8), (Screen.height / 2) + (Screen.height / 8), Screen.width / 4, Screen.height / 4), "OK")) {
			showExtra = false;
			GlobalVariables.isPaused = false;
			Destroy(gameObject);
			Action ();

		}

	}

	void  Action()
	{
		GameObject action = GameObject.Find ("WallSpawner");
		BubbleAction consequence = action.GetComponent<BubbleAction> ();
		if (!wasCorrect) {

			consequence.Punish ();
		} else {

			GameObject[] allTrash = GameObject.FindGameObjectsWithTag ("Trash");
			GameObject[] allOil = GameObject.FindGameObjectsWithTag ("Oil");

			if (allTrash.Count() >= 10) {
				consequence.Reward (allTrash);
			} else if (allOil.Count() >= 5) {
				consequence.Reward (allOil, "Oil");
			} else {
				TroutControl.healFish ();
			}
				
		}

	}

			void OnGUI() {
				GUI.skin.button.wordWrap = true;
				if (!currentQuestion.isTF) {
					if (showQuestion) {	
						GUI.skin = skin;
						GUI.Window (0, new Rect (0, 0, Screen.width, Screen.height), DoWindow0, "");
					}

				} 
				else {
			if (showQuestion) {
				GUI.skin = skin;
				GUI.Window (0, new Rect (0, 0, Screen.width, Screen.height), DoTrueFalse, "");
			}
				}

		if (showExtra) {
			GUI.skin = skin;
			GUI.Window(0, new Rect(0, 0, Screen.width, Screen.height), DoExtra, "");
		}
			}

			void OnMouseDown() {
				showQuestion = true;
				GlobalVariables.isPaused = true;
			}
			}