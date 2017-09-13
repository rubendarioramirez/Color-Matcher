using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameManager_color : MonoBehaviour {

	Renderer rd;
	public GameObject cube;
	public GameObject playerClone;

	public Camera cam;
	float camZpos;
	float camYpos;
	List<List<GameObject>> cubes;
	public List<GameObject> mine;


	//Test materials
	public Material[] cubeMaterials;

	//UI TEXT
	public TextMesh comboTxt;
	public TextMesh scoreValue;
	public TextMesh movesValue;
	public TextMesh levelValue;

	public Button restartBtn;


	public float cycleTime ;
	int movesLeft;
	int yCount;
	int xCount;
	int winningCondition;
	int scorePoints;
	int currentLevel;

	int colorToPick;
	int colorCount;

	public int onCombo;

	Coroutine co;

	void Start () {

		camZpos = -12f;
//		camYpos = -5.5f;

		cycleTime = 1f;
		scorePoints = 0;
		onCombo = 1;
		currentLevel = 1;
		colorCount = 5;
		yCount = 2;
		xCount = 2;
		movesLeft = 6;
		winningCondition = yCount * xCount;
	
		mine = new List<GameObject> ();
		cubes = new List<List<GameObject>>();

		//Setup the UI
		updateUI();

		//Spawn the cubes.
		spawner ();

		//Start the switching colors automatically.
		co = StartCoroutine (autoChangeColor(cycleTime));
	}

	void FixedUpdate(){
		//Smoothly transform to the Z as the parent.
		foreach (GameObject cube in mine) {
			//Transform the Z position to same as parent.
			Transform cubePos = cube.GetComponent<Transform> ();
			Vector3 oldPos = new Vector3(cubePos.position.x, cubePos.position.y,cubePos.position.z);
			Vector3 newPos = new Vector3(cubePos.position.x, cubePos.position.y, 0);
			cubePos.transform.position = Vector3.Lerp(oldPos, newPos, Time.deltaTime *2);
		}

	}


	void spawner(){
		
		for (int x = 0; x < xCount; x++)
		{
			List<GameObject> ycubes = new List<GameObject>();
			for(int y = 0; y < yCount; y++){
				GameObject go = Instantiate(cube, new Vector3(x * 1, y * 1, Random.Range(-0.3f,-2f)), Quaternion.identity)  as GameObject;
				ycubes.Add (go);
			
				//Get an array of components on children
				Renderer[] cubesToPaint = ycubes[y].GetComponentsInChildren<Renderer>();
				//Calls this function to assign randomly the colors
				colorAssigner(cubesToPaint[1]);
			}
			cubes.Add (ycubes);
		}	

		//This is the player.
		mine.Add (cubes [0] [0]);

		Transform camPos = cam.GetComponent<Transform> ();
		int middleCube = cubes.Count / 2;
		Transform middleCubeTransform = cubes [middleCube][middleCube].GetComponent<Transform>();
		camPos.position = new Vector3 (middleCubeTransform.position.x -0.5f,middleCubeTransform.position.y -6.5f,camZpos);

		Debug.Log (middleCubeTransform.position.y);

	}

	void CheckColor(){
		//Store current count temporarly.
		int tempMine = mine.Count;

		foreach(List<GameObject> ycubes in cubes){
			int x = cubes.IndexOf (ycubes);
			foreach(GameObject cube in ycubes){
				int y = ycubes.IndexOf (cube);
				if (mine.IndexOf(cube) != -1){

					Renderer[] childColor = cube.GetComponentsInChildren<Renderer> ();
					Material col = childColor[1].sharedMaterial;

					GameObject willBemine = null;

					//RIGHT
					if (x + 1 < xCount) {
						Renderer[] rightCubeRD = cubes[x+1][y].GetComponentsInChildren<Renderer>();
						if (col.Equals(rightCubeRD[1].sharedMaterial)){
						
						willBemine = cubes [x + 1] [y];
						}
					}


					if (willBemine != null && mine.IndexOf (willBemine) == -1) {
						mine.Add (willBemine);
						updateScore ();
					}
					willBemine = null;
					//END RIGHT

					//UP
					if (y + 1 < yCount) {
						Renderer[] topCubeRD = cubes [x] [y + 1].GetComponentsInChildren<Renderer> ();
						if (col.Equals (topCubeRD [1].sharedMaterial)) {
							willBemine = cubes [x] [y + 1];
						}
					}
					if (willBemine != null && mine.IndexOf (willBemine) == -1) {
						mine.Add (willBemine);

						updateScore ();
					}
					willBemine = null;
					// END UP


					//DOWN
					if (y - 1 >= 0) {
						Renderer[] bottomCubeRD = cubes [x] [y - 1].GetComponentsInChildren<Renderer> ();	
						if (col.Equals (bottomCubeRD [1].sharedMaterial)) {
							willBemine = cubes [x] [y - 1];
						}
					}
					if (willBemine != null && mine.IndexOf (willBemine) == -1) {
						mine.Add (willBemine);

						updateScore ();
					}
					willBemine = null;
					//END DOWN.

					//LEFT
					if (x - 1 >= 0) {
						Renderer[] leftCubeRD = cubes[x-1][y].GetComponentsInChildren<Renderer>();
						if (col.Equals (leftCubeRD [1].sharedMaterial)) {
							willBemine = cubes [x - 1] [y];
						}
					}
						
					if (willBemine != null && mine.IndexOf (willBemine) == -1) {
						mine.Add (willBemine);

						updateScore ();
					}
					//END LEFT


				}
			}
		}
			
		//if missed
		if (mine.Count == tempMine) {
			scorePoints -= 5;
			onCombo = 1;
			cycleTime = 1f;

			comboTxt.text = "x" + onCombo;
			scoreValue.text = ""+scorePoints;
		
		} else {
			onCombo++;
			comboTxt.text = "x" + onCombo;

			if (cycleTime >= 0.6f) {
				cycleTime -= 0.1f;
			}

			if (mine.Count.Equals(winningCondition)) {
				nextLevel ();
			} 

		}


	}



	//Randomly assigns a different color to each block on start.
	void colorAssigner(Renderer rd){
		colorToPick = Random.Range (0, colorCount);
		rd.material = cubeMaterials[colorToPick];

	}


	//Change the color automatically every 1 second.
	IEnumerator autoChangeColor(float cycleTime) {
		while(true) 
		{ 
				yield return new WaitForSeconds (cycleTime);
				changeColor (cubeMaterials[0]);
				yield return new WaitForSeconds (cycleTime);
				changeColor (cubeMaterials[1]);
				yield return new WaitForSeconds (cycleTime);
				changeColor (cubeMaterials[2]);
				yield return new WaitForSeconds (cycleTime);
				changeColor (cubeMaterials[3]);
				yield return new WaitForSeconds (cycleTime);
				changeColor (cubeMaterials[4]);

		}

	}


	//Change the colors to the same as the parent.
	void changeColor(Material col){
		foreach (GameObject cube in mine) {
			//cube.GetComponent<Renderer> ().material = col;
			Renderer[] cubesToChange = cube.GetComponentsInChildren<Renderer>();
			cubesToChange [1].material = col;

		}
	}

	//Delete all previous objects when restarting the level.
	void destroyObjects(){
		foreach (GameObject cube in mine) {
			Destroy (cube);
		}
	}


	void checkMoves(){
		movesLeft--;
		movesValue.text = "" + movesLeft; 
		if (movesLeft.Equals (0)) {
			finishGame ();
		}
	}

	void finishGame(){
		restartBtn.gameObject.SetActive (true);
	}

	public void restartGame(){
		yCount = 2;
		xCount = 2;
		currentLevel = 1;
		Application.LoadLevel(Application.loadedLevel);
	}
		
	void checkLevelIncrement(){


		if (currentLevel < 4) {
			yCount += 1;
			xCount += 1;
		} else if (currentLevel >= 4) {
			cam.fieldOfView += 0.5f;
			yCount += 1;
			xCount += 1;
		}
		else if (currentLevel >= 12) {
			yCount += 1;

		} 
	}

	void updateScore(){
		if (onCombo < 4) {
			scorePoints += 5 * onCombo;
		} else {
			scorePoints += 5 * 3;
		}
		scoreValue.text = ""+scorePoints; 
	}

	void updateUI(){
		//Update the UI
		movesValue.text = "" + movesLeft;
		levelValue.text = "" + currentLevel;
		restartBtn.gameObject.SetActive (false);
	}


	void nextLevel(){


		StopCoroutine (co);

		destroyObjects ();

		mine.Clear ();

		//Reset the Lists
		mine = new List<GameObject> ();
		cubes = new List<List<GameObject>>();

		//Increase the level
		currentLevel += 1;
	
		checkLevelIncrement ();

		//AddExtra for finishing the level
		scorePoints += 50;
		scoreValue.text = ""+scorePoints; 

		updateUI ();

		//movesLeft = yCount + xCount + 2;
		movesLeft = movesLeft + 10;
		winningCondition = yCount * xCount;

		spawner ();
		co = StartCoroutine (autoChangeColor (cycleTime));
	}

}


