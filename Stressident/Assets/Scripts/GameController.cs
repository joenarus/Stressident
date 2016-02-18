using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

	public GameObject db;
	public Google2u.Questions db1;
	public GameObject QuestionCanvas;
	public Slider approval;
	private int currentQuestion;


	void Start() {
		if (db = null) {
			db = GameObject.Find ("Google2uDatabase");
	
			db1 = db.GetComponent<Google2u.Questions>();
			
		}
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

	public void AnswerQuestion(int x) {
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

		QuestionCanvas.SetActive (false);

	}

	string GetQuestion()
	{
		int x;
		x = Random.Range (1, 11);
		Google2u.QuestionsRow a = db1.Rows [PickRandomID(x)];
		currentQuestion = x;
		// Call the method in the game model that generates questions
		return a[0];
	}
}
