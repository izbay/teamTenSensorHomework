using UnityEngine;
using System.Collections;

public class TrackPositionAndHeading : MonoBehaviour
{
	private float curr_rot;
	private float curr_x;
	private float curr_y;
	
	void Update ()
	{
		SavePosition();
	}
	
	void SavePosition ()
	{
		curr_x = transform.position.x;
		curr_y = transform.position.y;
		curr_rot = transform.rotation.eulerAngles.z;
	}
}
