using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerChcek : MonoBehaviour
{

	void OnTriggerStay (Collider c)
	{
		if (c.gameObject.tag == "Player" ) {
			GameObject.Find ("GM").SendMessage ("enteredCollision");
		}
	}

//	void OnTriggerExit (Collider c)
//	{
//		if (c.gameObject.tag == "Player") {
//			GameObject.Find ("GM").SendMessage ("exitedCollision");
//		}
//
//	}


}
