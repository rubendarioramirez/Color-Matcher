using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{

	//Game objects
	public GameObject player;
	public GameObject playerHud;
	public GameObject enemy;
	public GameObject enemy2;

	//Components
	private Rigidbody rb;
	private Animator anim;
	private Renderer hud;

	//All time favourite booleans
	public bool dodgedRight;


	public Vector3 targetPosition;
	public float smoothFactor;

	public int triggerSwitch;



	// Use this for initialization
	void Start ()
	{
		rb = player.GetComponent<Rigidbody> ();
		hud = playerHud.GetComponent<Renderer> ();
		dodgedRight = false;

		triggerSwitch = 0; //User is not in trigger.
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log (rb.velocity);

		if (Input.GetKeyDown (KeyCode.Space)) {
			switch (triggerSwitch) {
			case 1: 
					if (!dodgedRight) {
						StartCoroutine (steer (1));
					rb.velocity = rb.velocity /1.1f;
					} else {
						StartCoroutine (steer (0));
					rb.velocity = rb.velocity /1.1f;
					}
				break;

			case 2: 
					if (!dodgedRight) {
						StartCoroutine (steer (1));
					} else {
						StartCoroutine (steer (0));
					}
				break;

			default:
				Debug.Log ("Error has been made");
				break;
			}
		} 
	}


	IEnumerator steer (int dir)
	{
		if (dir.Equals (1)) {
			rb.AddForce (Vector3.right * 20, ForceMode.Impulse);
			yield return new WaitForSeconds (0.4f);
			rb.AddForce (Vector3.left * 20, ForceMode.Impulse);
			dodgedRight = true;
			yield break;
		} else if (dir.Equals (0)) {
			rb.AddForce (Vector3.left * 20, ForceMode.Impulse);
			yield return new WaitForSeconds (0.4f);
			rb.AddForce (Vector3.right * 20, ForceMode.Impulse);	
			dodgedRight = false;
			yield break;
		}

	}

	void blueTriggered ()
	{
		triggerSwitch = 1;
		hud.material.color = Color.blue;
	}

	void redTriggered ()
	{
		triggerSwitch = 2;
		hud.material.color = Color.red;
	}


	void triggerExit ()
	{
		triggerSwitch = 0;
		hud.material.color = Color.white;
	}



}
