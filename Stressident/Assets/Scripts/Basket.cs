using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
	public GameObject score; //reference to the ScoreText gameobject, set in editor
	public int tempScore = 0;

	void OnCollisionEnter() //if ball hits board
	{

	}
	
	void OnTriggerEnter(Collider other) //if ball hits basket collider
	{
		if (other.tag == "Basketball") {
			tempScore++;
			GameObject.Destroy(GameObject.Find("Ball(clone)"));
		}

		score.GetComponent<Text> ().text = tempScore.ToString();
		/*
		int currentScore = int.Parse(score.GetComponent().text) + 1; //add 1 to the score
		score.GetComponent().text = currentScore.ToString();
		AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
		*/
	}
}