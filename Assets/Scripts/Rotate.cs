﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (45, 30, 15) * Time.deltaTime);
	}
}
