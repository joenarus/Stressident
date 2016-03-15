using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour
{
	public GameObject score; //reference to the ScoreText gameobject, set in editor
	
	void OnCollisionEnter() //if ball hits board
	{

	}
	
	void OnTriggerEnter(Collider other) //if ball hits basket collider
	{
		if (other.tag == "BasketBall") {
			Debug.Log("YYOOOOOOO");
		}
		/*
		int currentScore = int.Parse(score.GetComponent().text) + 1; //add 1 to the score
		score.GetComponent().text = currentScore.ToString();
		AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
		*/
	}
}