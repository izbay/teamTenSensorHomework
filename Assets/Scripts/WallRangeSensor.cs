using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WallRangeSensor : MonoBehaviour {
	
	public Text UItext;
	public float range=1.0f,l=1.0f,f=1.0f,r=1.0f;
	private List<float> adjacentWalls = new List<float> ();
	public RaycastHit2D leftRayHit, rightRayHit, frontRayHit;

	void Start(){
		//adds in the 3 sensors to the list
		adjacentWalls.Add (l);
		adjacentWalls.Add (f);
		adjacentWalls.Add (r);

	}

	void Update ()
	{
		//detects if the rays hit an object that doesnt belong tot he layer Ignore Raycast
		frontRayHit = Physics2D.Raycast (transform.position, (transform.right)*range,1<<LayerMask.NameToLayer("Ignore Raycast"));
		leftRayHit = Physics2D.Raycast (transform.position, (transform.up+(transform.right/2))*range,1<<LayerMask.NameToLayer("Ignore Raycast"));
		rightRayHit = Physics2D.Raycast (transform.position, (-transform.up+(transform.right/2))*range,1<<LayerMask.NameToLayer("Ignore Raycast"));

		UpdateGUI();
	}
	
	void UpdateGUI ()
	{
		string output = "Detected Walls:\n";
		
		//if the front ray has hit something, display the output and update the f float, else display normal ray and set f to range
		if (!frontRayHit) {
			Debug.DrawRay (transform.position, (transform.right)*range,Color.red);
			f=range;
		} else {
			Debug.DrawRay (transform.position, (transform.right)*range,Color.cyan);
			output = output + "(" + frontRayHit.distance.ToString("F1") + ")";
			f=frontRayHit.distance;
		}
		//if the left ray has hit something, display the output and update the l float, else display normal ray and set l to range
		if (!leftRayHit) {
			Debug.DrawRay (transform.position, (transform.up+(transform.right/2))*range, Color.blue);
			l=range;
		} else {
			Debug.DrawRay (transform.position, (transform.up+(transform.right/2))*range, Color.cyan);
			output = output + "(" + leftRayHit.distance.ToString("F1") + ")";
			l=leftRayHit.distance;
		}
		//if the right ray has hit something, display the output and update the r float, else display normal ray and set r to range
		if (!rightRayHit) {
			Debug.DrawRay (transform.position, (-transform.up+(transform.right/2))*range, Color.green);
			r=range;
		} else {
			Debug.DrawRay (transform.position, (-transform.up+(transform.right/2))*range, Color.cyan);
			output = output + "(" + rightRayHit.distance.ToString("F1") + ")";
			r=rightRayHit.distance;
		}

		UItext.text = output;
	}
}