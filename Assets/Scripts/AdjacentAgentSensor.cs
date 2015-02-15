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
		string output = "Adjacent Agents:\n";
		
		foreach (Transform t in adjacentAgents)
		{
			Vector3 distance = t.position - transform.position;
			double bearing = ((distance.y>0)?1:-1) * Vector3.Angle(Vector3.right,distance);
				   bearing = (bearing + 360) % 360;             
			output = output + "D=" + distance.magnitude.ToString("F1");
			output = output + ",B=" + bearing.ToString ("F1")+"\n";
		}
		
		UItext.text = output;
	}
}
