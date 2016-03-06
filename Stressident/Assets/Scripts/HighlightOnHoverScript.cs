using UnityEngine;
using System.Collections;

public class HighlightOnHoverScript : MonoBehaviour 
{
	private Color originalColor;
	public bool questionUp = false;

	void Start()
	{
		originalColor = GetComponent<Renderer>().material.color;
	}

	void Update()
	{
		if (questionUp) 
		{
			GetComponent<Renderer>().material.color = originalColor;
		}
	}

	void OnEnable()
	{	
		GameController.questionUp += setQuestionUp;
		GameController.questionDown += setQuestionDown;
	}

	void OnDisable()
	{
		GameController.questionUp -= setQuestionUp;
		GameController.questionDown -= setQuestionDown;
	}

	void OnMouseEnter()
	{
		if (!questionUp) 
		{
			GetComponent<Renderer>().material.color = Color.yellow;
		}
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = originalColor;
	}

	void setQuestionUp()
	{
		questionUp = true;
	}

	void setQuestionDown()
	{
		questionUp = false;
	}
}
