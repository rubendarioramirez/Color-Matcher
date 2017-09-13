using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer : MonoBehaviour {
	private Vector3 movement = Vector3.left * 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			if (this.transform.position.x > 3) {
				movement = Vector3.left * 0.1f;
			} else if (this.transform.position.x < -3) {
				movement = Vector3.right * 0.1f;
			}
			transform.Translate (movement);

	}
}
