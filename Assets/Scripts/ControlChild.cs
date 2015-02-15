using UnityEngine;
using System.Collections;

public class ControlChild : MonoBehaviour {
	
	public float turnSpeed;
	public float moveSpeed;
	public KeyCode controlKey;
	public KeyCode toggleKey;
	
	private float curr_rot;
	private float curr_x;
	private float curr_y;
	
	private Transform selected;
	private int childIndex = 0;
	
	void Update () {
	
		// Toggle through selected children
		if(Input.GetKeyUp (toggleKey))
		{
			if (selected)
				selected.GetComponent<SpriteRenderer>().color = Color.green;
			
			childIndex = (childIndex+1)%transform.childCount;
			
			selected = transform.GetChild (childIndex);
			selected.GetComponent<SpriteRenderer>().color = Color.cyan;
		
		}
	
		// Handle if W and S are both held.
		if(Input.GetKey (controlKey) && selected){
			int dir_motion = 0;
			if (Input.GetKey (KeyCode.W))
				dir_motion++;
			if (Input.GetKey (KeyCode.S))
				dir_motion--;
			
			// Do motion.
			if (dir_motion != 0)
				selected.transform.Translate (dir_motion * Vector3.right * moveSpeed * Time.deltaTime);
			
			// Handle if A and D are both held.
			int dir_rotation = 0;
			if (Input.GetKey (KeyCode.A))
				dir_rotation++;
			if (Input.GetKey (KeyCode.D))
				dir_rotation--;
			
			// Do rotation.
			if (dir_rotation != 0)
				selected.transform.Rotate(dir_rotation * Vector3.forward * turnSpeed * 10 * Time.deltaTime);
		}
		
		SavePosition();
	}
	
	void SavePosition () {
		curr_x = transform.position.x;
		curr_y = transform.position.y;
		curr_rot = transform.rotation.eulerAngles.z;
	}
}
