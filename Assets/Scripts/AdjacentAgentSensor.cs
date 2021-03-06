﻿using UnityEngine;
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
		double parent_rot = transform.parent.rotation.eulerAngles.z;

		foreach (Transform t in adjacentAgents)
		{
			Vector3 distance = t.position - transform.position;
			double bearing = ((distance.y>0)?1:-1) * Vector3.Angle(Vector3.right,distance);
			bearing = (bearing - parent_rot + 360) % 360;             
			output = output + "Dist = " + distance.magnitude.ToString("F1");
			output = output + ", Brng = " + bearing.ToString ("F1")+"\n";
		}
		
		UItext.text = output;
	}
}
