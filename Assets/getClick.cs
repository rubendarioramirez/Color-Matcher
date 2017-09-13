using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class getClick : MonoBehaviour {

	public gameManager_color gm;

	void OnMouseDown(){

		//On click check if the colors matches.
		gm.SendMessage ("CheckColor");
		gm.SendMessage ("checkMoves");
	}
}
