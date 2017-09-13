using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_trigger : MonoBehaviour {

	void OnTriggerStay (Collider c)
	{
		if (c.gameObject.tag == "Player" ) {
			GameObject.Find ("GM").SendMessage ("redTriggered");
		}
	}
	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Player" ) {
			GameObject.Find ("GM").SendMessage ("triggerExit");
			Debug.Log ("Exited trigger");
		}
	}
}
