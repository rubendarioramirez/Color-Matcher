using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lostTrigger : MonoBehaviour {

	//gameManager gm;

	// Use this for initialization
	void Start () {
	//	gm = new gameManager ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player")
			GameObject.Find ("GameManager").SendMessage ("Reset");
	}
}
