using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubjectController : MonoBehaviour {

	public float turnSpeed;
	public float moveSpeed;
	public Text UItext;
	public KeyCode abortKey1;
	public KeyCode abortKey2;

	private float curr_rot;
	private float curr_x;
	private float curr_y;

	void Start () {
		SavePosition ();
	}

	void Update () {
		// Handle if W and S are both held.
		if(!(Input.GetKey (abortKey1) || Input.GetKey (abortKey2))){
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

			SavePosition ();
		}
	}

	void SavePosition () {
		curr_x = transform.position.x;
		curr_y = transform.position.y;
		curr_rot = transform.rotation.eulerAngles.z;

		UpdateGUI ();
	}

	void UpdateGUI () {
		string output = "Position: ("+curr_x.ToString("F2")+","+curr_y.ToString("F2")+")\n";
		output += "Heading: "+curr_rot.ToString("F2")+"\n";

		UItext.text = output;
	}
}
