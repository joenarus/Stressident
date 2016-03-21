using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionTimer : MonoBehaviour {

	float timeLeft = 15.0f;
	public bool activate = false; 
	public Text questionTimer;
	public GameObject questionCanvas;

	void Update()
	{
		if (activate) {
			timeLeft -= Time.deltaTime;
			questionTimer.text = timeLeft.ToString();
			if (timeLeft < 0) {
				questionCanvas.SetActive(false);
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
