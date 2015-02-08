using UnityEngine;
using System.Collections;

public class agentController : MonoBehaviour {

	public float turnSpeed;
	public float moveSpeed;
	public KeyCode controlKey;

	void Update () {
		// Handle if W and S are both held.
		if(Input.GetKey (controlKey)){
			int dir_motion = 0;
			if (Input.GetKey (KeyCode.W))
				dir_motion++;
			if (Input.GetKey (KeyCode.S))
				dir_motion--;
			
			// Do motion.
			if (dir_motion != 0)
				transform.Translate (dir_motion * Vector3.right * moveSpeed * Time.deltaTime);
			
			// Handle if A and D are both held.
			int dir_rotation = 0;
			if (Input.GetKey (KeyCode.A))
				dir_rotation++;
			if (Input.GetKey (KeyCode.D))
				dir_rotation--;
			
			// Do rotation.
			if (dir_rotation != 0)
				transform.Rotate(dir_rotation * Vector3.forward * turnSpeed * 10 * Time.deltaTime);
		}
	}
}
