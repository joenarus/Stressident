using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destress : MonoBehaviour {

	public Timer clock;
	public GameObject DestressGUI;
	public Slider StressSlider;
	public Basket scoreKeep;
	public bool activate = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (clock.hour == 9) { //checks time and displays options to destress.
			//DestressGUI.SetActive(true);
			//Debug.Log ("Sweet");
		}


	}

	public void ToggleActivate() {
		if (activate)
			activate = false;
		else
			activate = true;
	}

	public void SetDestressLevel(int x) {
		StressSlider.value -= x;
	}
}
