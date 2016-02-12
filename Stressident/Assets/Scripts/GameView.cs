using UnityEngine;
using System.Collections;

public class GameView : MonoBehaviour 
{
	// The folder clicked event fires an alert to the game controller
	public delegate string FolderClicked();
	public static event FolderClicked folderClicked;

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
				// If the user clicked a folder ...
				if (hit.collider.gameObject.tag == "Folder") 
				{
					string question = "Did you know that if you're seeing this question then something went wrong?";

					if (folderClicked != null) 
					{
						question = folderClicked ();
					}

					Debug.Log (question);
					Destroy (GameObject.Find (hit.collider.gameObject.name));
				}
			}
		}
	}
}
