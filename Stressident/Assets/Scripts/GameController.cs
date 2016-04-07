using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;
using System.Linq;

public class GameController : MonoBehaviour 
{
	public GameObject db;
	public Google2u.Questions db1;
	public GameObject QuestionCanvas;
	public Slider approval;
	public delegate void QuestionUp();
	public static event QuestionUp questionUp;
	public delegate void QuestionDown();
	public static event QuestionDown questionDown;
	public Slider StressLevels;
	public AudioSource heartbeat;

	private Question currentQuestion;
	private int pastAnswer;
	private GameView gameView;
	private bool heartbeatPlaying = false;

	public GameObject folder1;
	public GameObject folder2;
	public GameObject folder3;
	
	public int tempDebug = 0;

	public Timer time;
	public QuestionTimer questTime;
	public TutorialController tutorial;

	public bool Tutorial_Is_Going = true;

	Dictionary<string, List<Question>> questions; 
	List<string> topics;

	void Start() {
		folderTopics ();
		List<string> topics = new List<string>();
		if (db = null) {
			db = GameObject.Find ("Google2uDatabase");
			db1 = db.GetComponent<Google2u.Questions>();
		}
		HashSet<string> temptopics = new HashSet<string>();
		questions = new Dictionary<string, List<Question>>();
		gameView = GetComponent<GameView>();
		if (tutorial.tutorial_active) {
			List<Question> y = new List<Question>();
			Question temporary = new Question("This is a freebie, go ahead and click any of the answers.", "Tutorial", 10, 10, 10);
			y.Add(temporary);
			temptopics.Add(temporary.topic);
			questions.Add(temporary.topic, y);
		}
		//Places questions into their respective topics.
		for(int i = 0; i < 30; i++) {

			List<Question> y;
			Google2u.QuestionsRow a = db1.Rows [i];

			questions.TryGetValue(a._Type, out y);
			
			if(y == null) {
				y = new List<Question>();
			}

			Question temporary = new Question(a._Name, a._Type, a._Yes, a._No, a._Maybe);
			y.Add(temporary);

			temptopics.Add(temporary.topic); //adding to List for future iteration.
			topics = temptopics.ToList();


			if(questions.ContainsKey(temporary.topic)) {
				questions.Remove(temporary.topic);
			}
			questions.Add(temporary.topic, y);
		}
	}

	void OnGUI () {
		GUILayout.Label(time.hour.ToString() + ":" + time.minutes.ToString() + "0" + time.ampm);
	}

	// The game controller subscribes to these events from other classes
	void OnEnable()
	{	
		GameView.folderClicked += GetQuestion;
	}

	void OnDisable()
	{
		GameView.folderClicked -= GetQuestion;
	}

	void Update()
	{
		if (tutorial.tutorial_active) {
			if(tutorial.counter == 0) {
				disableFPSCamera();
			}
		}
		if (!tutorial.tutorial_active) {

			gameView.mousePosition = new Vector2 (Screen.width / 2, Screen.height / 2);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.None;

			if (!gameView.questionUp) {
				Cursor.lockState = CursorLockMode.Locked;

			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}

			if (Input.GetKeyDown (KeyCode.Escape)) {
				Cursor.visible = true;
				gameView.hitEscape = true;
			}
			if(tutorial.collided && tutorial.counter == 3) {
				tutorial.tutorial_active = true;
			}

			// If stress levels too high, start blurry vision

		}
		if (StressLevels.value > 75) {
			Camera.main.GetComponent<BlurryVision> ().stressed = true;
			if (!heartbeatPlaying) {
				heartbeat.Play ();
				heartbeatPlaying = true;
			}
		} 
		else if (heartbeatPlaying) {
			heartbeat.Stop ();
			heartbeatPlaying = false;
			Camera.main.GetComponent<BlurryVision> ().stressed = false;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
				Debug.Log ("Pause");
			}
	}

	public void AnswerQuestion(int x) 
	{

		int i = currentQuestion.Yes;
		int j = currentQuestion.No;
		int k = currentQuestion.Hold;
		// Enable FPS controller once question is answered
		enableFPSCamera();
		questionDown();
		gameView.questionUp = false;
		bool allAnswered = false;
		int counter = 0;
		List<Question> possibilities;
		questions.TryGetValue (gameView.currentTopic, out possibilities);
		for(int d = 0; d < possibilities.Count; d++) {
			if(!possibilities[d].Answered)
				break;
			
			else if(counter == possibilities.Count - 1)
				allAnswered = true;
			counter++;
		}
		if (!allAnswered) {
			i = currentQuestion.Yes;
			j = currentQuestion.No;
			k = currentQuestion.Hold;
		} 
		else {
			i = 0;
			j = 0;
			k = 0;
		}
			//yes
			if (x == 1) {
				approval.value += i;
				currentQuestion.Answered = true;
			}
		//hold
		else if (x == 2) {
				approval.value += k;

			}
		//no
		else {
				approval.value += j;
				currentQuestion.Answered = true;
			}

			currentQuestion.AnsweredValue = x;

			QuestionCanvas.SetActive (false);

			time.questionGoing = false; 
			questTime.activate = false;
			questTime.reset (); //resets timer
		if (currentQuestion.topic == "Tutorial") {
			tutorial.tutorial_active = true;
		}

	}

	string GetQuestion()
	{
		// Disable FPS controller while question GUI is up
		disableFPSCamera();
		questionUp();
		gameView.questionUp = true;
		time.questionGoing = true;
		questTime.activate = true;

		List<Question> possibilities;
		questions.TryGetValue (gameView.currentTopic, out possibilities);

		int x = 0;
		bool allAnswered = false;
		int counter = 0;
		for(int i = 0; i < possibilities.Count; i++) {
			x = Random.Range (0, possibilities.Count);
			if(!possibilities[x].Answered)
				break;

			else if(counter == possibilities.Count - 1)
				allAnswered = true;
			counter++;
		}

		tempDebug = x;
		string q = "";

		currentQuestion = possibilities[x];
		q = currentQuestion.Qquestion;

		if (allAnswered) {
			q = "You have answered all of the questions for this topic.";
		}
		return q;
	}

	void folderTopics() {
		TextMesh temp1 = folder1.GetComponentInChildren<TextMesh> ();
		TextMesh temp2 = folder2.GetComponentInChildren<TextMesh> ();
		TextMesh temp3 = folder3.GetComponentInChildren<TextMesh> ();
		if (Tutorial_Is_Going) {
			temp1.text = "Tutorial";
			temp2.text = "Tutorial";
			temp3.text = "Tutorial";
		}
		else {
			temp1.text = "Military";
			temp2.text = "Medical";
			temp3.text = "Social";
		}

	}
		
	public void enableFPSCamera()
	{
		GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = true;	
	}

	public void disableFPSCamera()
	{
		GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = false;	
	}
}
