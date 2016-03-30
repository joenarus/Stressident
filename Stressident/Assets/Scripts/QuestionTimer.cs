using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionTimer : MonoBehaviour {

	public float timeLeft = 15.0f;
	public bool activate = false; 
	public Text questionTimer;
	public GameController Controller;

	void Update()
	{
		if (activate) {
			timeLeft -= Time.deltaTime;
			questionTimer.text = timeLeft.ToString();
			if(timeLeft < 0) {
				Controller.AnswerQuestion(2);
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}

	public void reset() {
		timeLeft = 15.0f;
	}
}
