using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public Text tutorial_text;

	// Use this for initialization
	void Start () {
		tutorial_text.text = "Good morning, President. I've lined up some situations I'd like " +
			"for you to address in the folders on your desk. Click on the folders to open them!" +
				"Have an awesome day, Sir!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GOGOGO() {

		Application.LoadLevel (1);
	}
}
