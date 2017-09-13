using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public Transform startingPoint;
	public Transform platformStartingPoint;
	public	Transform gatePosInitial;

	private Transform groundSpawnPoint;

	public GameObject player;
	public GameObject floor;
	public GameObject gate;



	public	int counter;

	// Use this for initialization
	void Start () {

		groundSpawnPoint = platformStartingPoint;
		player.transform.position = startingPoint.position;	
		counter = 0;
		Debug.Log (groundSpawnPoint.position.y);
	}

	void Update(){
		if (counter >= 3) {
			gate.transform.position = new Vector3 (100,0,0);
		}
	}
		
	public void Reset(){
		player.transform.position = startingPoint.position;	
		floor.transform.position = groundSpawnPoint.position;
		gate.transform.position = gatePosInitial.position;
		Debug.Log (groundSpawnPoint.position.y);
		counter = 0;
	}

	public void sumTriggers(){
		counter++;
	}
}
