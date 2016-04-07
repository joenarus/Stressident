using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	double lastChange = 0.0;
	public int hour = 8;
	public int minutes = 0;
	public string ampm = "am";
	public bool questionGoing = false;

	public GameObject timer;

	public int seconds = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastChange > 2.0) {
			minutes++;
			if(minutes == 6) {
				minutes = 0;
				hour++;
				if(hour == 12) {
					if(ampm == "am")
						ampm = "pm";
				}
				if (hour == 24) {
					hour = 8;
					if(ampm == "pm")
						ampm = "am";
				}
			}
			lastChange = Time.time;
		}
	



	}
}
