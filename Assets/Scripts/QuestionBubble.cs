
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

		GUI.Label(new Rect(20, 20, 460, 200), currentQuestion.prompt);


		if (GUI.Button (new Rect (20, 160, 220, 100), currentQuestion.answerA)) {

			if (currentQuestion.isA) {
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;



			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;

			}
				
			showQuestion = false;
			showExtra = true;

		}

		if (GUI.Button (new Rect (260, 160, 220, 100), currentQuestion.answerB)) {

			if (currentQuestion.isB) {
				
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}

		if (GUI.Button (new Rect (20, 280, 220, 100), currentQuestion.answerC)) {

			if (currentQuestion.isC) {
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}

		if (GUI.Button (new Rect (260, 280, 220, 100), currentQuestion.answerD)) {

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
		GUI.Label(new Rect(20, 20, 460, 200), currentQuestion.prompt);


		if (GUI.Button (new Rect (20, 160, 220, 100), currentQuestion.answerA)) {

			if (currentQuestion.isA) {
				currentQuestion.extraComment = "Correct! " + currentQuestion.extraComment;
				wasCorrect = true;


			} else {
				currentQuestion.extraComment = "Wrong! " + currentQuestion.extraComment;
			}

			showQuestion = false;
			showExtra = true;

		}
		if (GUI.Button (new Rect (260, 160, 220, 100), currentQuestion.answerB)) {

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
		GUI.Label(new Rect(20, 20, 460, 200), currentQuestion.extraComment);
		if (GUI.Button (new Rect (20, 160, 220, 100), "OK")) {
			showExtra = false;
			GlobalVariables.isPaused = false;
			Destroy(gameObject);
			Punish ();

		}

	}

	void  Punish()
	{
		GameObject wall = GameObject.Find ("WallSpawner");
		spawnWall greatWall = wall.GetComponent<spawnWall> ();
		if (!wasCorrect) {
			
			greatWall.Punish ();
		} else {

			GameObject[] allTrash = GameObject.FindGameObjectsWithTag("Trash");
			greatWall.Reward (allTrash);
		}

	}

			void OnGUI() {
				GUI.skin.button.wordWrap = true;
				if (!currentQuestion.isTF) {
					if (showQuestion) {	
						GUI.skin = skin;
						GUI.Window (0, new Rect (200, 0, 500, 400), DoWindow0, "");
					}

				} 
				else {
			if (showQuestion) {
				GUI.Window (0, new Rect (200, 0, 500, 400), DoTrueFalse, "");
			}
				}

		if (showExtra) {
			GUI.Window(0, new Rect(200, 0, 500, 400), DoExtra, "");
		}
			}

			void OnMouseDown() {
				showQuestion = true;
				GlobalVariables.isPaused = true;
			}
			}