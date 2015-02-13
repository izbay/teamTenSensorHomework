using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WallRangeSensor : MonoBehaviour {
	
	public Text UItext;
	
	private List<Transform> adjacentWalls = new List<Transform> ();
	private RaycastHit2D hit;
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("wall"))
			adjacentWalls.Add (other.transform);
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag("wall"))
			adjacentWalls.Remove(other.transform);
	}
	
	void Update ()
	{
		Transform leftRay = transform;
		Transform rightRay = transform;


		UpdateGUI();
	}
	
	void UpdateGUI ()
	{
		string output = "Detected Walls:\n";
		
		foreach (Transform t in adjacentWalls)
		{
			Vector3 distance = t.position - transform.position;
			output = output + "(" + distance.magnitude.ToString("F1") + ")";
		}
		Debug.DrawRay (transform.position + (transform.forward * 4), transform.right - transform.up * 2, Color.red,0.0f,true);
		Debug.DrawRay (transform.position + (transform.forward * 4), transform.right * 2, Color.blue,0.0f,true);
		Debug.DrawRay (transform.position + (transform.forward * 4), transform.right + transform.up * 2, Color.green,0.0f,true);

		//Debug.DrawRay (transform.position - (transform.forward * 4), - transform.right * 20, Color.yellow,20f,true);
		
		//Debug.DrawRay (transform.position - (transform.forward * 4), transform.right * 20, Color.yellow,20f,true);

		UItext.text = output;
	}
}