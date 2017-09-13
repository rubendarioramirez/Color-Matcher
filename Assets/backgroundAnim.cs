using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundAnim : MonoBehaviour {

	Renderer rd;

	// Update is called once per frame
	void FixedUpdate () {
		rd = GetComponent<Renderer> ();
		rd.material.color = Color.Lerp (Color.black, Color.red, Mathf.PingPong(Time.time, 1));
		rd.material.color = Color.Lerp (Color.red, Color.yellow, Mathf.PingPong(Time.time, 1));
		rd.material.color = Color.Lerp (Color.yellow, Color.green, Mathf.PingPong(Time.time, 1));
		rd.material.color = Color.Lerp (Color.green, Color.blue, Mathf.PingPong(Time.time, 1));
		rd.material.color = Color.Lerp (Color.blue, Color.black, Mathf.PingPong(Time.time, 1));


	}
}
