using UnityEngine;
using System.Collections;

public class TutorialCollid : MonoBehaviour {
	public TutorialController tut;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name.Equals ("FPSController") && !tut.collided) {
			tut.collided = true;
		}
	}
}
