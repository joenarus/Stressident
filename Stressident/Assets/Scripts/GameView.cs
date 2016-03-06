﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameView : MonoBehaviour 
{
	// The folder clicked event fires an alert to the game controller
	public delegate string FolderClicked();
	public static event FolderClicked folderClicked;
	public GameObject QuestionCanvas;
	public bool questionUp = false;

	void Update () 
	{
		// If user clicks something ..
		if ( Input.GetMouseButtonDown(0))
		{
			// Use raycasting to determine which object the player clicked
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 100.0f))
			{  
				if (!questionUp) 
				{
					// If the user clicked a folder ...
					if (hit.collider.gameObject.tag == "Folder") {
						// Default question
						string question = "Did you know that if you're seeing this question then something went wrong?";

						// Get question from folderClicked event raised to game controller
						question = folderClicked ();

						// Get the GUI to assign the question to
						QuestionCanvas.SetActive (true);
						QuestionCanvas.GetComponentInChildren<Text> ().text = question;

						// Remove the folder game object
						//Destroy (GameObject.Find (hit.collider.gameObject.name));
					}
				}
			}
		}
	}
}
