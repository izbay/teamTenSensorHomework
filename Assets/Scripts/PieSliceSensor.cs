using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PieSliceSensor : MonoBehaviour {
	
	public Text UItext;
	public double[] SliceBoundaries = new double[4];
	public double SliceDepth;

	private int[] SliceOccupants = new int[4];
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
		double parent_rot = transform.parent.rotation.eulerAngles.z;

		foreach (Transform t in adjacentAgents)
		{
			Vector3 distance = t.position - transform.position;
			double bearing = ((distance.y>0)?1:-1) * Vector3.Angle(Vector3.right,distance);
			bearing = (bearing - parent_rot + 360) % 360; 

			if(distance.magnitude <= SliceDepth){
				CountAgentInSlice(bearing);
			}
		}

		string output = "Pie Slice Activation:\n";
		int idx = 0;
		foreach (int cnt in SliceOccupants)
		{
			output += "[" + idx + "] = " + (cnt / 10.0).ToString("F1") + "\n";
			SliceOccupants[idx++] = 0;
		}

		UItext.text = output;
	}

	void CountAgentInSlice(double bearing)
	{
		if(bearing < SliceBoundaries[0] || bearing >= SliceBoundaries[SliceBoundaries.Length-1]){
			SliceOccupants[0]++;
		} else {
			for(int i=1; i<SliceBoundaries.Length; i++){
				if(bearing >= SliceBoundaries[i-1] && bearing < SliceBoundaries[i]){
					SliceOccupants[i]++;
					break;
				}
			}
		}
	}
}