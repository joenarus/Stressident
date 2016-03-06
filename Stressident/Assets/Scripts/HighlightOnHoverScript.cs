using UnityEngine;
using System.Collections;

public class HighlightOnHoverScript : MonoBehaviour 
{
	private Color originalColor;

	void OnMouseEnter()
	{
		originalColor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.yellow;
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = originalColor;
	}
}
