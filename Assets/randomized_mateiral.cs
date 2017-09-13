using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomized_mateiral : MonoBehaviour {
	Renderer rd;

	int colorToPick;
	// Use this for initialization

	void Start () {
		rd = this.GetComponent<Renderer> ();
		colorToPick = Random.Range (0, 5);

		switch (colorToPick) 
		{
			case 0:
			rd.material.color = Color.red;
			break;

			case 1:
			rd.material.color = Color.yellow;
			break;

			case 2:
			rd.material.color = Color.blue;
			break;

			case 3:
			rd.material.color = Color.green;
			break;

			case 4:
			rd.material.color = Color.white;
			break;

			case 5:
			rd.material.color = Color.black;
			break;
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
