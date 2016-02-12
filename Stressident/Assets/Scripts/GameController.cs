using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
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
		// Call the method in the game model that generates questions
		return "Is this the best question anyone has ever asked you?";
	}
}
