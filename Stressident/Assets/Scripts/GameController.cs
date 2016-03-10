using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;

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
	private int currentQuestion;
	private int pastAnswer;
	private GameView gameView;

	void Start() {
		if (db = null) {
			db = GameObject.Find ("Google2uDatabase");
	
			db1 = db.GetComponent<Google2u.Questions>();
		}

		gameView = GetComponent<GameView>();
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
		gameView.mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

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
	}

	int PickRandomID(int x) {
		if (x == 1) {
			return (int)Google2u.Questions.rowIds.ID_Q1;
		}

		else if (x == 2) {
			return (int)Google2u.Questions.rowIds.ID_Q2;
		}
		else if (x == 3) {
			return (int)Google2u.Questions.rowIds.ID_Q3;
		}
		else if (x == 4) {
			return (int)Google2u.Questions.rowIds.ID_Q4;
		}
		else if (x == 5) {
			return (int)Google2u.Questions.rowIds.ID_Q5;
		}
		else if (x == 6) {
			return (int)Google2u.Questions.rowIds.ID_Q6;
		}
		else if (x == 7) {
			return (int)Google2u.Questions.rowIds.ID_Q7;
		}
		else if (x == 8) {
			return (int)Google2u.Questions.rowIds.ID_Q8;
		}
		else if (x == 9) {
			return (int)Google2u.Questions.rowIds.ID_Q9;
		}
		else {
			return (int)Google2u.Questions.rowIds.ID_Q10;
		}

	}

	public void AnswerQuestion(int x) 
	{
		// Enable FPS controller once question is answered
		enableFPSCamera();
		questionDown();
		gameView.questionUp = false;

		Google2u.QuestionsRow a = db1.Rows [PickRandomID(currentQuestion)]; //pulls current values for question
		Debug.Log (a._No);

		int i = a._Yes;
		int j = a._No;
		int k = a._Maybe;

		//yes
		if (x == 1) {
			approval.value += i;
		}
		//maybe
		else if (x == 2) {
			approval.value += k;
		}
		//no
		else {
			approval.value += j;
		}

		WriteToXml (x);
		QuestionCanvas.SetActive (false);

	}

	string GetQuestion()
	{
		// Disable FPS controller while question GUI is up
		disableFPSCamera();
		questionUp();
		gameView.questionUp = true;

		int x;
		x = Random.Range (1, 11);
		Google2u.QuestionsRow a = db1.Rows [PickRandomID(x)];
		currentQuestion = x;
		LoadFromXml ();
		return a[0];
	}

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
		 // Apply the values to the cube object.
		
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
