using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour {

	float distance = 10;
	Vector3 startMousePos;
	Rigidbody rb;
	public float thrust;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void OnMouseDown(){
		//startMousePos = (Input.mousePosition);

	}

	void OnMouseDrag(){
//		Vector3 mousePositionWorld = (Input.mousePosition);
//		distance = startMousePos.y - mousePositionWorld.y;
//		startMousePos = mousePositionWorld;
//
//		Debug.Log (distance);
		//transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - (distance/10));
		rb.AddForce (thrust, 0, 0, ForceMode.Impulse);
		//todo change for Addforce
	}

}
