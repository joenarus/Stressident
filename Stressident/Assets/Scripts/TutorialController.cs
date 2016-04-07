using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public Text tutorial_text;
	public bool tutorial_active = true;
	public int counter = 0;
	public GameObject tutorialCanvas;
	public GameController control;
	public GameObject arrow;

	public bool collided = false;
	// Use this for initialization
	void Start () {
		if (tutorial_active && counter == 0)
			tutorial_text.text = "Good morning, Mr. President. Congratulations on your recent victory in the election! " +
				"\n\nLet's get you acquainted with the office!";
					
	}
	
	// Update is called once per frame
	void Update () {
		if (control.Tutorial_Is_Going) {
			if (tutorial_active) {
				tutorialCanvas.SetActive (true);
				control.disableFPSCamera ();
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				if (counter == 1) {
					tutorial_text.text = "Let's start by walking over to the desk!";
				}
				if (counter == 2) {
					tutorial_active = false;
					control.enableFPSCamera ();
					counter++;
				}

				if (counter == 3) {
					tutorial_text.text = "Click on the Tutorial Folder!";
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;

				}

				if (counter == 4) {
					tutorial_active = false;
					control.enableFPSCamera ();
					counter++;
					GameObject.Destroy(GameObject.Find("TutCollide"));
				}

				if (counter == 5) {
					tutorial_text.text = "Notice how your answer impacted your approval rating!";
					arrow.SetActive (true);
				}
				if (counter == 6) {
					tutorial_text.text = "You will be given many different situations to respond to. " +
						"Your answers will impact what the People think of you. Choose carefully!";
				}
				if (counter == 7) {

					control.StressLevels.value = 76;
					tutorial_text.text = "Various things in the environment will cause you stress. Upon hitting 75 stress, you will begin to experience negative effects.";
				}
				if (counter == 8) {
					tutorial_text.text = "Luckily, there are many ways to destress in this environment. Clicking the ball on the table is one of those!";
				}
				if (counter == 9) {
					tutorial_active = false;
					control.enableFPSCamera ();
					counter++;
				}
				if (counter == 10) {
					tutorial_text.text = "Throwing the ball into the trash by the desk will relieve some stress. But doing it too many times will lessen the effect. Give it a shot by clicking the ball again!!";
				}
				if (counter == 11) {
					tutorial_active = false;
					control.enableFPSCamera ();
					counter++;
				}

				if (counter == 12) {
					tutorial_text.text = "Finally, at the end of each day, you get to pick between a few actions that will impact your stress levels. When used multiple times, their effects on stress lessen, so choose carefully.";
				}
				if (counter == 13) {
					tutorial_text.text = "That about sums everything up! Good luck on the job! ";
				}
				if (counter == 14) {
					tutorial_active = false;
					control.enableFPSCamera ();
					counter++;
					control.Tutorial_Is_Going = false;
				}

			}
			if (!tutorial_active) {
				tutorialCanvas.SetActive (false);

			

			}
		}
		
	}


	public void GOGOGO() {


	}

	public void counterInc() {
		counter++;
	
	}


}
