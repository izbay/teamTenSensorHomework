﻿using UnityEngine;
using System.Collections;

public class SpawnOnClick : MonoBehaviour
{
	public KeyCode spawnKey;
	public GameObject prefab;
	
	void Update ()
	{
		if( Input.GetButtonUp("Fire1") && Input.GetKey(spawnKey))
		{
			Vector3 spawnPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			spawnPoint.z = 0;
			Instantiate (prefab, spawnPoint, Quaternion.AngleAxis(Random.Range(0.0f,360.0f), Vector3.back));
		}
	}
}
