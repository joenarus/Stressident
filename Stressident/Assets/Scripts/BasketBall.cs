using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasketBall : MonoBehaviour {

	// Use this for initialization
	public GameObject ball; //reference to the ball prefab, set in editor
	private Vector3 throwSpeed = new Vector3(0, 10, 10); //This value is a sure basket, we'll modify this using the forcemeter
	public Vector3 ballPos; //starting ball position
	private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
	private GameObject ballClone; //we don't use the original prefab
	private int currentForce = 0;
	public bool enabled = false;
	public GameObject player;
	public GameObject BasketballCanv;
	private bool readyToShoot = false;
	private int availableShots = 5;
	
	public Slider meter; //references to the force meter
	private float arrowSpeed = 0.3f; //Difficulty, higher value = faster arrow movement
	private bool up = true; //used to revers arrow movement
	int counter = 0;

	void Start()
	{

	}

	void FixedUpdate()
	{
		if (enabled) {
			counter++;
			/* Move Meter Arrow */
			if (up) {
				currentForce ++;
			}
			if (currentForce == 20) {
				up = false;
			}
			if (!up) {
				currentForce--;
			}
			if(currentForce == 0) {
				up = true;
			}

			meter.value = currentForce;

			if(Input.GetButton("Fire1") && !thrown && counter > 10 ) {
				Vector3 theVector =  Input.mousePosition;
				theVector.z = 1;
				ballClone = Instantiate(ball, Camera.main.ScreenToWorldPoint(theVector),Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(theVector))) as GameObject;
				ballClone.GetComponent<Rigidbody>().AddForce(player.transform.forward * currentForce, ForceMode.Impulse);
				thrown = true;

			}

			if (ballClone != null && ballClone.transform.position.y < .2)
			{
				Destroy(ballClone);
				thrown = false;
				throwSpeed = new Vector3(0, 5, 5);
				BasketballCanv.SetActive(false);
				enabled = false;
				currentForce = 0;
			}
		}
	}

	public void enable() {
		BasketballCanv.SetActive (true);
		enabled = true;
		counter = 0;
		up = true;
	}
}
