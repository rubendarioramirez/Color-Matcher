using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTrigger : MonoBehaviour {

	Renderer otherRd;
	Renderer myRd;
	Color myColor;

	void Start(){

	}

	void Update(){
		myRd = this.GetComponent<Renderer>();
		myColor = myRd.material.color;
	}




	void OnTriggerEnter(Collider c)
	{
		
		otherRd = c.gameObject.GetComponent<Renderer> ();
		Color otherColor = otherRd.material.color;
		Debug.Log (otherColor);


	}
}
