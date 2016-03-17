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
	private Question currentQuestion;
	private int pastAnswer;
	private GameView gameView;

	public GameObject folder1;
	public GameObject folder2;
	public GameObject folder3;
	
	public int tempDebug = 0;

	double lastChange = 0.0;
	int hour = 8;
	int minutes = 0;
	string ampm = "am";


	Dictionary<string, List<Question>> questions; 
	List<string> topics;

	void Start() {
		folderTopics ();
		List<string> topics = new List<string>();
		if (db = null) {
			db = GameObject.Find ("Google2uDatabase");
			db1 = db.GetComponent<Google2u.Questions>();
		}

		questions = new Dictionary<string, List<Question>>();
		gameView = GetComponent<GameView>();

		//Places questions into their respective topics.
		for(int i = 0; i < 30; i++) {

			List<Question> y;
			Google2u.QuestionsRow a = db1.Rows [i];

			questions.TryGetValue(a._Type, out y);
			
			if(y == null) {
				y = new List<Question>();
			}
			HashSet<string> temptopics = new HashSet<string>();
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
		GUILayout.Label(hour.ToString() + ":" + minutes.ToString() + "0" + ampm);
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
		gameView.mousePosition = new Vector2(Screen.width/2, Screen.height/2);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;

		if (!gameView.questionUp) 
		{
			Cursor.lockState = CursorLockMode.Locked;

		} 
		else 
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Cursor.visible = true;
			gameView.hitEscape = true;
		}

		if (Time.time - lastChange > 5.0) {
			minutes++;
			if(minutes == 6) {
				minutes = 0;
				hour++;
				if(hour == 12) {
					if(ampm == "am")
						ampm = "pm";
				}
				if (hour == 24) {
					hour = 8;
					if(ampm == "pm")
						ampm = "am";
				}
			}
			lastChange = Time.time;
		}
	}

	public void AnswerQuestion(int x) 
	{
		// Enable FPS controller once question is answered
		enableFPSCamera();
		questionDown();
		gameView.questionUp = false;

		int i = currentQuestion.Yes;
		int j = currentQuestion.No;
		int k = currentQuestion.Hold;

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

		Debug.Log (questions [currentQuestion.topic] [tempDebug].Answered);

		QuestionCanvas.SetActive (false);

	}

	string GetQuestion()
	{
		// Disable FPS controller while question GUI is up
		disableFPSCamera();
		questionUp();
		gameView.questionUp = true;

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

	/*
	public void WriteToXml(int answer)
	{
		
		string filepath = Application.dataPath + @"/Data/questionsUsed.xml";
		XmlDocument xmlDoc = new XmlDocument();
		XmlElement elmRoot;
		if (File.Exists (filepath)) {
			xmlDoc.Load (filepath);
			elmRoot = xmlDoc.DocumentElement;
		
			
			//elmRoot.RemoveAll(); // remove all inside the transforms node.
			
			XmlElement elmNew = xmlDoc.CreateElement ("id"); // create the rotation node.
			XmlElement answerX = xmlDoc.CreateElement ("answer");
			elmNew.InnerText = currentQuestion.ToString ();
			answerX.InnerText = answer.ToString ();

			elmNew.AppendChild (answerX);
			elmRoot.AppendChild (elmNew); // make the transform node the parent.
			
			xmlDoc.Save (filepath); // save file.
		}

	}

	public void LoadFromXml()
	{
		string filepath = Application.dataPath + @"/Data/questionsUsed.xml";
		XmlDocument xmlDoc = new XmlDocument();
		
		if(File.Exists (filepath))
		{
			xmlDoc.Load(filepath);
			
			XmlNodeList transformList = xmlDoc.GetElementsByTagName("id");
			
			foreach (XmlNode transformInfo in transformList)
			{
				XmlNodeList transformcontent = transformInfo.ChildNodes;
				
				foreach (XmlNode transformItens in transformcontent)
				{
					if(transformItens.Name == "answer")
					{
						pastAnswer = int.Parse(transformItens.InnerText); // convert the strings to float and apply to the X variable.
						Debug.Log("Past answer: " + pastAnswer);
					}
				}
			}
        }
	}
*/

	void folderTopics() {
		TextMesh temp1 = folder1.GetComponentInChildren<TextMesh> ();
		TextMesh temp2 = folder2.GetComponentInChildren<TextMesh> ();
		TextMesh temp3 = folder3.GetComponentInChildren<TextMesh> ();

		temp1.text = "Military";
		temp2.text = "Medical";
		temp3.text = "Social";
	}
		
	void enableFPSCamera()
	{
		GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = true;	
	}

	void disableFPSCamera()
	{
		GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = false;	
	}
}
