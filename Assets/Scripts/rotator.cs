using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
	public bool direction;
	private Vector3 movement = Vector3.left * 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement = Vector3.forward * 0.5f;
		transform.Rotate (movement);
	}
}
