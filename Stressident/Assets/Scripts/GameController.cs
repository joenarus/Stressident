using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	public GameObject db;
	public Google2u.Sheet1 db1;
	void Start() {
		if (db = null) {
			db = GameObject.Find ("Google2uDatabase");
	
			db1 = db.GetComponent<Google2u.Sheet1>();
			
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

	string GetQuestion()
	{
		Google2u.Sheet1Row a = db1.Rows [(int)Google2u.Sheet1.rowIds.ID_Q1];
		Debug.Log(a[0]);
		Debug.Log (db1.Rows.GetType ());
		Debug.Log (db1.Rows [(int)Google2u.Sheet1.rowIds.ID_Q1]);
		// Call the method in the game model that generates questions
		return a[0];
	}
}
