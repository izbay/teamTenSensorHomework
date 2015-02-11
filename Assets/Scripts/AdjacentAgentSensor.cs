using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AdjacentAgentSensor : MonoBehaviour {

	public Text UItext;
	
	private List<Transform> adjacentAgents = new List<Transform> ();
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("agent"))
			adjacentAgents.Add (other.transform);
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag("agent"))
			adjacentAgents.Remove(other.transform);
	}
	
	void Update ()
	{
		UpdateGUI();
	}
	
	void UpdateGUI ()
	{
		string output = "Detected Agents:\n";
		
		foreach (Transform t in adjacentAgents)
		{
			Vector3 distance = t.position - transform.position;
			output = output + "(" + distance.magnitude.ToString("F1") + ")";
		}
		
		UItext.text = output;
	}
}
