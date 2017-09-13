using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physic : MonoBehaviour {
	private Rigidbody rb;
	public float forceStrenght;
	public Collider coll;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		coll = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){


//		rb.AddForce (transform.up * forceStrenght, ForceMode.Impulse);
//
//		//transform.rotation = Quaternion.AngleAxis(45, transform.up) * transform.rotation;
//		rb.useGravity = true;


		Ray screenToPointer = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (coll.Raycast(screenToPointer, out hit, Mathf.Infinity)) {
			Vector3 theVector = (transform.position - hit.point).normalized;
			rb.velocity = new Vector3 (theVector.x * 10, theVector.y * 12, 0);

		}

	}
}
