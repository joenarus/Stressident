using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class DisplayQuestionScript : MonoBehaviour
{
	public string question;

	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		GUI.Label (new Rect (Screen.width-(buttonHeight*9), Screen.height / 3, Screen.width, buttonHeight), question);

		if (
			GUI.Button(
				// Center in X, 1/3 of the height in Y
				new Rect(
					Screen.width / 6 + (buttonWidth),
					(2 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"Yes"
			)
		)
		{
			// Record a "yes" answer
			Debug.Log("Yes!");
			Application.LoadLevel("Main");
		}

		if (
			GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(
					Screen.width / 3 + (buttonWidth),
					(2 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"No"
			)
		)
		{
			// Record a "No" answer
			Debug.Log("No!");
			Application.LoadLevel("Main");
		}
	}
}
