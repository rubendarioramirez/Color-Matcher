using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour {

	public Material[] materials;
	public Renderer rend;
	private bool active;
	public Light myLight;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.sharedMaterial = materials [0]; //GREEN

		rend.enabled = true;
		active = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player" && active.Equals(false))
		{
			rend.sharedMaterial = materials [1]; //RED
		    GameObject.Find("GameManager").SendMessage("sumTriggers");
			active = true;
			myLight.intensity = 5;
	}
}
}
