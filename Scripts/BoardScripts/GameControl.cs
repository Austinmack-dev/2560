using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;






public class GameControl : MonoBehaviour {
	int score = 0;

	static Transform trans10;
	static TextMesh tm100;
	static GameObject text100;

	GameObject fullSquare0;
	GameObject fullSquare00;
	GameObject fullSquare01;
	GameObject fullSquare02;
	GameObject fullSquare03;
	GameObject fullSquare10;
	GameObject fullSquare11;
	GameObject fullSquare12;
	GameObject fullSquare1;
	GameObject fullSquare9;
	GameObject fullSquare100;
	GameObject fullSquare111;
	GameObject fullSquare222;
	GameObject fullSquare333;
	GameObject fullSquare444;
	GameObject fullSquare555;


	GameObject scoreTxt;
	Text scoreText;

	static Transform fs;

	GameObject textaa;
	TextMesh tmaa;
	Transform trans12;



	int a0;
	int a1;
	int a2;
	int a3;

	List<int> a = new List<int>();
	int[] aArray = new int[16];
	List<int> b = new List<int>();
	static int[] bArray = new int[16];
	List<int> c = new List<int>();
	int[] cArray = new int[16];
	List<int> d = new List<int>();
	int[] dArray = new int[16];





	static int COUNT = 12;
	static int col = 4;
	static int row = 4;



	int[] iArray = new int[16];
	int[] jArray = new int[16];


	int[] numInCol = new int[col];
	int[] numInRow = new int[row];

	static bool[,] emptySquares = new bool[row,col];

	static Transform[] from = new Transform[col];
	static Transform[] to = new Transform[col];
	static Transform[] from2 = new Transform[col];
	static Transform[] to2 = new Transform[col];
	static Transform[] from3 = new Transform[col];
	static Transform[] to3 = new Transform[col];
	static Transform[] from4 = new Transform[col];
	static Transform[] to4 = new Transform[col];




	void OnLevelWasLoaded(int level){
		if (level == 1) {
			GameObject go = GameObject.Find ("ScoreStuff2");
			if(go != null){
				Destroy(go.gameObject);
			}
			else{
			}
		}
	}

	void Awake(){
		
	}

	//	 Use this for initialization
	void Start () {
		init ();


		int randi1 = Random.Range(0,3);
		int randj1 = Random.Range(0,3);
		int randi2 = Random.Range(0,3);
		while (randi2 == randi1) {
			
			randi2 = Random.Range(0,3);
		}
		int randj2 = Random.Range(0,3);

		while (randj2 == randi2) {
			
			randj2 = Random.Range(0,3);
		}


		fullSquare111 = GameObject.CreatePrimitive (PrimitiveType.Plane);
		Transform trans11 = GameObject.Find ("EmptySquare" + randi1.ToString() + randj1.ToString()).transform;
		fullSquare111.transform.position = new Vector3 (trans11.position.x, trans11.position.y, trans11.position.z-.5f);
		fullSquare111.transform.Rotate (270.0f, 0, 0);
		fullSquare111.transform.localScale *= .21f;
		fullSquare111.gameObject.GetComponent<Renderer> ().material = Resources.Load("Five") as Material;
		fullSquare111.gameObject.name = "fullSquare" + randi1.ToString() + randj1.ToString();
		GameObject text111 = Instantiate(Resources.Load("Text")) as GameObject;
		text111.gameObject.transform.SetParent (fullSquare111.transform, false);
		TextMesh tm111 = text111.GetComponent<TextMesh> ();
		text111.gameObject.name = "text" + randi1.ToString() + randj1.ToString();
		tm111.text = "5";
		emptySquares [randi1 , randj1] = false;


		fullSquare555 = GameObject.CreatePrimitive (PrimitiveType.Plane);
		Transform trans18 = GameObject.Find ("EmptySquare" + randi2.ToString() + randj2.ToString()).transform;
		fullSquare555.transform.position = new Vector3 (trans18.position.x, trans18.position.y, trans18.position.z-.5f);
		fullSquare555.transform.Rotate (270.0f, 0, 0);
		fullSquare555.transform.localScale *= .21f;
		fullSquare555.gameObject.GetComponent<Renderer> ().material = Resources.Load("Five") as Material;
		fullSquare555.gameObject.name = "fullSquare" + randi2.ToString() + randj2.ToString();
		GameObject text18 = Instantiate(Resources.Load("Text")) as GameObject;
		text18.gameObject.transform.SetParent (fullSquare555.transform, false);
		text18.gameObject.name = "text" + randi2.ToString() + randj2.ToString();
		TextMesh tm18 = text18.GetComponent<TextMesh> ();
		tm18.text = "5";
		emptySquares [randi2, randj2] = false;

	}

	// Update is called once per frame
	void Update () {

		StartCoroutine ("WaitForDownPress");
		StartCoroutine ("WaitForUpPress");
		StartCoroutine ("WaitForRightPress");
		StartCoroutine ("WaitForLeftPress");



	}

	public void updateScore(int s){
		scoreTxt = GameObject.Find ("Score");
		scoreText = scoreTxt.gameObject.GetComponent<Text> ();
		score += s;
		scoreText.text = "Score: " + score.ToString ();
	}

	IEnumerator checkBoard(){


		int numFull = 0;
		bool fullboard = false;
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				if (emptySquares [i, j] == false) {
					numFull++;
				}
			}

		}

		if (numFull == 16) {
			
			fullboard = true;

		}

		int[] board = new int[16];
		int counter = 0;
		int gCount = 0;


		if (fullboard == true) {
			for(int i = 0; i < row; i++){
				for (int j = 0; j < col; j++) {
					
					GameObject text = GameObject.Find ("text" + i.ToString () + j.ToString ());
					TextMesh tm = text.GetComponent<TextMesh> ();



					int t = System.Int32.Parse (tm.text);


					board[counter] = t;


					counter++;
				}
			}
		}


		for (int i = 0; i < 16; i++) {
			if ((board [0] != board [1]) && (board [0] != board [4])) {
				gCount++;
			}
			if ((board [1] != board [2]) && (board [1] != board [5])) {
				gCount++;
			}
			if((board[2] != board[3]) && (board[2] != board[6])){
				gCount++;
			}
			if((board[3] != board[7])){
				gCount++;
			}
			if((board[4] != board[5]) && (board[4] != board[8])){
				gCount++;
			}
			if((board[5] != board[6]) && (board[5] != board[9])){
				gCount++;
			}
			if((board[6] != board[7]) && (board[6] != board[10])){
				gCount++;
			}
			if((board[7] != board[11])){
				gCount++;
			}
			if((board[8] != board[9]) && (board[8] != board[12])){
				gCount++;
			}
			if((board[0] != board[1]) && (board[0] != board[4])){
				gCount++;
			}
			if((board[9] != board[10]) && (board[9] != board[13])){
				gCount++;
			}
			if((board[10] != board[11]) && (board[10] != board[14])){
				gCount++;
			}
			if((board[0] != board[1]) && (board[0] != board[4])){
				gCount++;
			}
			if((board[11] != board[15])){
				gCount++;
			}
			if((board[12] != board[13])){
				gCount++;
			}
			if((board[13] != board[14])){
				gCount++;
			}
			if((board[14] != board[15])){
				gCount++;
			}

		}

		if (gCount >= 272) {
			yield return new WaitForSeconds (2.5f);
			SceneManager.LoadScene (2);
		}




		yield return null;
	}

	public void init(){


		int count = transform.childCount - COUNT;





		for (int i = 0; i < count * 4; i++) {
			//sameCol [i] = "00";
			//sameRow [i] = "00";
		}

		for (int i = 0; i < count; i++) {
			for (int j = 0; j < count; j++) {
				emptySquares [i, j] = true;

			}
		}
			


	}

	public void initNumInColRow(){
		int count = transform.childCount - COUNT;
		System.Array.Resize (ref numInCol, count); 
		System.Array.Resize (ref numInRow, count); 

		for (int i = 0; i < count; i++) {
			numInCol [i] = 0;
		}

		for (int i = 0; i < count; i++) {
			numInRow [i] = 0;
		}
	}

	IEnumerator WaitForDownPress(){
		int totalFull = 0;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Debug.Log ("DOWN WAS PRESSED!");

			initNumInColRow ();

			int count = transform.childCount - COUNT;
			for (int i = 0; i < count; i++) {
				a.Add (-1);
			}
			aArray = a.ToArray ();

			for (int i = 0; i < count; i++) {
				b.Add (-1);
			}
			bArray = b.ToArray ();

			for (int i = 0; i < count; i++) {
				c.Add (-1);
			}
			cArray = c.ToArray ();

			for (int i = 0; i < count; i++) {
				d.Add (-1);
			}
			dArray = d.ToArray ();




			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					if (emptySquares [i, j] == true) {
						
					}
				}
			}

			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					

					if (emptySquares [i, j] == false) {
						
						totalFull++;

						for (int k = 0; k < count; k++) {

							if (k == j) {
								numInCol [k]++;
							}
							if (k == i) {
								numInRow [k]++;
							}

						}

					}
				}
			}

			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {


					if (emptySquares [i, j] == false) {
						
						fs = GameObject.Find ("fullSquare" + i.ToString () + j.ToString ()).transform;


						if (j == 0) {
							
							if (i == 0) {


								fs.name = "a" + j.ToString ();



								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();

								aArray [j] = System.Int32.Parse (tma.text);

							}
							if (i == 1) {
								fs.name = "b" + j.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textbj
								textb.name = "textb" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();


								bArray [j] = System.Int32.Parse (tmb.text);


							}
							if (i == 2) {
								fs.name = "c" + j.ToString ();

								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [j] = System.Int32.Parse (tmc.text);


							}
							if (i == 3) {
								fs.name = "d" + j.ToString ();
								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textdj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();

								dArray [j] = System.Int32.Parse (tmd.text);

							}

						
						} 
						if (j == 1) {
							if (i == 0) {
								fs.name = "a" + j.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();

								aArray [j] = System.Int32.Parse (tma.text);

							}
							if (i == 1) {
								fs.name = "b" + j.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();

								bArray [j] = System.Int32.Parse (tmb.text);

							}
							if (i == 2) {
								fs.name = "c" + j.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();

								cArray [j] = System.Int32.Parse (tmc.text);

							}
							if (i == 3) {
								fs.name = "d" + j.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();

								dArray [j] = System.Int32.Parse (tmd.text);

							}
						}
						 if (j == 2) {
							if (i == 0) {
								fs.name = "a" + j.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();

								aArray [j] = System.Int32.Parse (tma.text);


							}
							if (i == 1) {

								fs.name = "b" + j.ToString ();


								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + j.ToString ();



								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();

								bArray [j] = System.Int32.Parse (tmb.text);


							}
							if (i == 2) {
								fs.name = "c" + j.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();

								cArray [j] = System.Int32.Parse (tmc.text);

							}
							if (i == 3) {


								fs.name = "d" + j.ToString ();



								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();

								dArray [j] = System.Int32.Parse (tmd.text);

							}
						}
						if (j == 3) {
							if (i == 0) {

								//Set the name to aj
								fs.name = "a" + j.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();

								aArray [j] = System.Int32.Parse (tma.text);


							}
							if (i == 1) {
								fs.name = "b" + j.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();

								bArray [j] = System.Int32.Parse (tmb.text);




							}
							if (i == 2) {
								fs.name = "c" + j.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();

								cArray [j] = System.Int32.Parse (tmc.text);

							}
							if (i == 3) {
								fs.name = "d" + j.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();

								dArray [j] = System.Int32.Parse (tmd.text);


							}
						}

					}
				}
			}


			for (int i = 0; i < count; i++) {
				if (numInCol [i] == 1) {



					//in row 0
					if (aArray [i] >= 5 ) {
						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);


						from [i] = GameObject.Find ("a" + i.ToString ()).transform; 
						GameObject texta = GameObject.Find ("texta" + i.ToString ());

						int toRowNum = row - numInCol [i];
						to [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 0,i to empty
						emptySquares [0, i] = true;

						//set 3, i to full
						emptySquares [3, i] = false;
						from [i].name = "fullSquare3" + i.ToString ();
						texta.name = "text3" + i.ToString ();
						dArray [i] = aArray [i];
						aArray [i] = -1;

					}

					//in row 1
				    else if (bArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);

						from [i] = GameObject.Find ("b" + i.ToString ()).transform; 
						GameObject textb = GameObject.Find ("textb" + i.ToString ());

						int toRowNum = row - numInCol [i];


						to [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 1,i to empty
						emptySquares [1, i] = true;

						//set 3, i to full
						emptySquares [3, i] = false;
						from [i].name = "fullSquare3" + i.ToString ();
						textb.name = "text3" + i.ToString ();
						dArray [i] = bArray [i];
						bArray [i] = -1;




					}

					//in row 2
				   else if (cArray [i] >= 5) {
						

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);


						from [i] = GameObject.Find ("c" + i.ToString ()).transform; 
						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						int toRowNum = row - numInCol [i];

						to [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;


						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 2,i to empty
						emptySquares [2, i] = true;

						//set 3, i to full
						emptySquares [3, i] = false;
						from [i].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();
						dArray [i] = cArray [i];
						cArray [i] = -1;


					}

					//in row 3
					else if (dArray [i] >= 5) {
						
						System.Array.Resize (ref from, col);


						from [i] = GameObject.Find ("d" + i.ToString ()).transform; 
						GameObject textd = GameObject.Find ("textd" + i.ToString ());



						//set rowNum, i to full
						emptySquares [3, i] = false;
						from [i].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();



					}
				} else if (numInCol [i] == 2) {
					
					if ((aArray [i] == bArray [i]) && (aArray [i] >= 5 && bArray [i] >= 5)) {
						

						//DO THIS IN ALL 2s SECTIONS (ANYWHERE WITH to[i] or from[i]

						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;

						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						//put the number in the proper slot in the aArray
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + bArray [i];
						tmb.text = dArray [i].ToString ();
						int toRowNum = (row + 1) - numInCol [i];
						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;
						Destroy (from2 [0].gameObject);
						from2 [1].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [1].gameObject);

						from2 [1].name = "fullSquare3" + i.ToString ();
						textb.name = "text3" + i.ToString ();
						updateScore (dArray [i]);
						//make the spots that we came from -1
						aArray [i] = -1;
						bArray [i] = -1;

					} else if (aArray [i] != bArray [i] && ((aArray [i] >= 5 && bArray [i] >= 5))) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);

						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						int toRowNum1 = row - numInCol [i];
						int toRowNum2 = (row + 1) - numInCol [i];
						to2 [0] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [1] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);

						//Make where the blocks came from empty
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						//Make where the blocks are going full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmb.text);
						aArray [i] = -1;
						bArray [i] = -1;
						from2 [0].name = "fullSquare2" + i.ToString ();
						texta.name = "text2" + i.ToString ();
						from2 [1].name = "fullSquare3" + i.ToString ();
						textb.name = "text3" + i.ToString ();
					
					} else if ((aArray [i] == cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toRowNum = (row + 1) - numInCol [i];

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [2, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);

						from2 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();
						updateScore (dArray [i]);
						//make the spots that we came from -1
						aArray [i] = -1;
						cArray [i] = -1;

					} else if ((aArray [i] != cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);

						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toRowNum1 = row - numInCol [i];
						int toRowNum2 = (row + 1) - numInCol [i];
						to2 [0] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [0, i] = true;
						emptySquares [2, i] = true;
						//Make where the blocks are going full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						aArray [i] = -1;

						from2 [0].name = "fullSquare2" + i.ToString ();
						texta.name = "text2" + i.ToString ();
						from2 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();
					} else if ((aArray [i] == dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toRowNum = (row + 1) - numInCol [i];

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [3, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);

						from2 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
						updateScore (dArray [i]);

						//make the spots that we came from -1
						aArray [i] = -1;

					} else if ((aArray [i] != dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);

						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toRowNum1 = row - numInCol [i];
						int toRowNum2 = (row + 1) - numInCol [i];
						to2 [0] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [0, i] = true;
						emptySquares [3, i] = true;
						//Make where the blocks are going full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						aArray [i] = -1;


						from2 [0].name = "fullSquare2" + i.ToString ();
						texta.name = "text2" + i.ToString ();
						from2 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
					} else if ((bArray [i] == cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);


						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toRowNum = (row + 1) - numInCol [i];

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [1, i] = true;
						emptySquares [2, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);

						from2 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();
						updateScore (dArray [i]);

						//make the spots that we came from -1
						bArray [i] = -1;
						cArray [i] = -1;


					} else if ((bArray [i] != cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toRowNum1 = row - numInCol [i];
						int toRowNum2 = (row + 1) - numInCol [i];
						to2 [1] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [1, i] = true;
						emptySquares [2, i] = true;
						//Make where the blocks are going full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						bArray [i] = -1;


						//set c and d back to original names
						from2 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from2 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();
					} else if ((bArray [i] == dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);

						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toRowNum = (row + 1) - numInCol [i];

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [1, i] = true;
						emptySquares [3, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);

						from2 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						//make the spots that we came from -1
						bArray [i] = -1;

						updateScore (dArray [i]);


					} else if ((bArray [i] != dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toRowNum1 = row - numInCol [i];
						int toRowNum2 = (row + 1) - numInCol [i];
						to2 [1] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [1, i] = true;
						emptySquares [3, i] = true;
						//Make where the blocks are going full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						bArray [i] = -1;


						//set names of c and d back
						from2 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from2 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
					} else if ((cArray [i] == dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toRowNum = (row + 1) - numInCol [i];

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [2].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);

						from2 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						//make the spots that we came from -1
						cArray [i] = -1;
						updateScore (dArray [i]);


					} else if ((cArray [i] != dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to2, col);
						System.Array.Resize (ref from2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();

						//Make where the blocks are going full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);

						//set names of c and d back
						from2 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from2 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
					}




				} 
				else if (numInCol [i] == 3) {


					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);



						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();

						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare3" + i.ToString ()).transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
					
						Destroy (from3 [0].gameObject);

						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;

						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();

						updateScore (dArray [i]);


					} 
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);

						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare3" + i.ToString ()).transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [1, i] = true;

						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 
					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);

						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare3" + i.ToString ()).transform;

						bArray [i] = aArray [i] + bArray [i];
						tmb.text = bArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [1, i] = true;

						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = bArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						dArray [i] = System.Int32.Parse(tmc.text);
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					}
					//Add all not equal case for abc
					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare3" + i.ToString ()).transform;
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);


						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						from3 [0].name = "fullSquare1" + i.ToString ();
						texta.name = "text1" + i.ToString ();
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [2].name = "fullSquare3" + i.ToString ();
						textc.name = "text3" + i.ToString ();
					}

					else if ((aArray [i] == bArray [i] && bArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);

						//set a and b to empty
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						//set c and d to full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						//

						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 

					else if ((aArray [i] != bArray [i] && bArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Debug.Log ("GETTING  HERE!!!");
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 

					else if ((aArray [i] == bArray [i] && bArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Debug.Log ("GETTING  HERE!!!");
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + bArray [i];
						tmb.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("EmptySquare3" + i.ToString ()).transform;
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare1" + i.ToString ();
						texta.name = "text1" + i.ToString ();
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
					}

					else if ((aArray [i] == cArray [i] && cArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						//set c and d to full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;

						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 

					else if ((aArray [i] != cArray [i] && cArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Debug.Log ("GETTING  HERE!!!");
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 

					else if ((aArray [i] == cArray [i] && cArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					}

					else if ((aArray [i] != cArray [i] && cArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("EmptySquare3" + i.ToString ()).transform;
						
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare1" + i.ToString ();
						texta.name = "text1" + i.ToString ();
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
					}

					else if ((bArray [i] == cArray [i] && cArray [i] == dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Grab information about the from and to
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [1].gameObject);
					
						//set a and b to empty
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						//set c and d to full
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;

						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 

					else if ((bArray [i] != cArray [i] && cArray [i] == dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					} 

					else if ((bArray [i] == cArray [i] && cArray [i] != dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						//Debug.Log ("GETTING  HERE!!!");
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (dArray [i]);
					}

					else if ((bArray [i] != cArray [i] && cArray [i] != dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref to3, col);
						System.Array.Resize (ref from3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tmb.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from3 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
					}





				} 
				else if (numInCol [i] == 4) {
					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);

						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {

						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						bArray [i] = aArray [i] + bArray [i];
						
						tmb.text = bArray [i].ToString ();
						Destroy (from4 [0].gameObject);

						
						emptySquares [0, i] = true;
						
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						aArray [i] = -1;

						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						
						tmc.text = cArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
						


					else if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = bArray [i];
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);

						from4 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [0, i] = true;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						cArray [i] = bArray [i];
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();

						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref to4, col);
						System.Array.Resize (ref from4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						emptySquares [3, i] = false;
						from4 [0].name = "fullSquare0" + i.ToString ();
						texta.name = "text0" + i.ToString ();
						from4 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from4 [2].name = "fullSquare2" + i.ToString ();
						textc.name = "text2" + i.ToString ();
						from4 [3].name = "fullSquare3" + i.ToString ();
						textd.name = "text3" + i.ToString ();
						
					}

				}
			}


			StartCoroutine ("Spawn");

			StartCoroutine ("checkBoard");
			yield return null;
		}




	}


	//CHANGE UP TOROWNUMS IN UP VS DOWN
	//Change renaming to 0 and 1 vs 2 and 3
	IEnumerator WaitForUpPress(){
		int totalFull = 0;
		//check for down press
		int counter = 0;





		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			

			Debug.Log ("UP WAS PRESSSSEDDDD!!!!!");

			initNumInColRow ();

			int count = transform.childCount - COUNT;
			for (int i = 0; i < count; i++) {
				a.Add (-1);
			}
			aArray = a.ToArray ();

			for (int i = 0; i < count; i++) {
				b.Add (-1);
			}
			bArray = b.ToArray ();

			for (int i = 0; i < count; i++) {
				c.Add (-1);
			}
			cArray = c.ToArray ();

			for (int i = 0; i < count; i++) {
				d.Add (-1);
			}
			dArray = d.ToArray ();



			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					if (emptySquares [i, j] == true) {
						//Debug.Log ("EMPTY AT I: " + i + " J: " + j);
					}
				}
			}

			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					//Search for number in same row
					//make sure the space is free

					if (emptySquares [i, j] == false) {
						//numberPartsOfName[l] = i.ToString() + j.ToString();

						//store the number thats filled on board
						totalFull++;

						//find the amount that is in a given column and row
						for (int k = 0; k < count; k++) {

							if (k == j) {
								numInCol [k]++;
							}
							if (k == i) {
								numInRow [k]++;
							}

						}

					}
				}
			}

			System.Array.Resize (ref from, totalFull);
			System.Array.Resize (ref to, totalFull);
			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {

					
					if (emptySquares [i, j] == false) {
						
						fs = GameObject.Find ("fullSquare" + i.ToString () + j.ToString ()).transform;
						

						if (j == 0) {
							if (i == 0) {
								fs.name = "d" + j.ToString ();
								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textdj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								
								dArray [j] = System.Int32.Parse (tmd.text);
								
							}

							if (i == 1) {
								fs.name = "c" + j.ToString ();

								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								
								cArray [j] = System.Int32.Parse (tmc.text);
								

							}
							//int column = j;

							if (i == 2) {
								fs.name = "b" + j.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textbj
								textb.name = "textb" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								


								bArray [j] = System.Int32.Parse (tmb.text);

								
							}
							if (i == 3) {


								fs.name = "a" + j.ToString ();


								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								
								aArray [j] = System.Int32.Parse (tma.text);
								
							}




						} 
						if (j == 1) {
							if (i == 0) {
								fs.name = "d" + j.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								
								dArray [j] = System.Int32.Parse (tmd.text);
								
							}
							if (i == 1) {
								fs.name = "c" + j.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								
								cArray [j] = System.Int32.Parse (tmc.text);
								
							}


							if (i == 2) {
								fs.name = "b" + j.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [j] = System.Int32.Parse (tmb.text);
								
							}

							if (i == 3) {
								fs.name = "a" + j.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [j] = System.Int32.Parse (tma.text);
								
							}

						}
						if (j == 2) {
							if (i == 0) {

								fs.name = "d" + j.ToString ();


								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [j] = System.Int32.Parse (tmd.text);
								
							}

							if (i == 1) {
								fs.name = "c" + j.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [j] = System.Int32.Parse (tmc.text);
								
							}

							if (i == 2) {

								fs.name = "b" + j.ToString ();


								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + j.ToString ();



								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [j] = System.Int32.Parse (tmb.text);

								
							}

							if (i == 3) {

								fs.name = "a" + j.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [j] = System.Int32.Parse (tma.text);
								
							}


						}
						if (j == 3) {
							

							if (i == 0) {
								fs.name = "d" + j.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								
								dArray [j] = System.Int32.Parse (tmd.text);
								

							}

							if (i == 1) {
								fs.name = "c" + j.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [j] = System.Int32.Parse (tmc.text);
								
							}
							if (i == 2) {
								fs.name = "b" + j.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [j] = System.Int32.Parse (tmb.text);


								

							}

							if (i == 3) {
								

								//Set the name to aj
								fs.name = "a" + j.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + j.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [j] = System.Int32.Parse (tma.text);
								


							}

						}

						

					}
				}
			}
			

			for (int i = 0; i < count; i++) {
				if (numInCol [i] == 1) {


					//in row 0
					if (aArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);
						from [i] = GameObject.Find ("a" + i.ToString ()).transform; 
						GameObject texta = GameObject.Find ("texta" + i.ToString ());

						int toRowNum = 0;
						to [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 0,i to empty
						emptySquares [3, i] = true;

						//set 3, i to full
						emptySquares [0, i] = false;
						from [i].name = "fullSquare0" + i.ToString ();
						texta.name = "text0" + i.ToString ();
						dArray [i] = aArray [i];
						aArray [i] = -1;
						

					}

					//in row 1
					else if (bArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);
						from [i] = GameObject.Find ("b" + i.ToString ()).transform; 
						GameObject textb = GameObject.Find ("textb" + i.ToString ());

						int toRowNum = 0;

						to [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 1,i to empty
						emptySquares [2, i] = true;

						//set 3, i to full
						emptySquares [0, i] = false;
						from [i].name = "fullSquare0" + i.ToString ();
						textb.name = "text0" + i.ToString ();
						dArray [i] = bArray [i];
						bArray [i] = -1;




					}

					//in row 2
					else if (cArray [i] >= 5 ) {
						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);

						from [i] = GameObject.Find ("c" + i.ToString ()).transform; 
						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						int toRowNum = 0;

						to [i] = GameObject.Find("EmptySquare" + toRowNum.ToString() + i.ToString()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 2,i to empty
						emptySquares [1, i] = true;

						//set 3, i to full
						emptySquares [0, i] = false;
						from [i].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
						dArray [i] = cArray [i];
						cArray [i] = -1;

						
					}

					//in row 3
					else if (dArray [i] >= 5) {
						System.Array.Resize (ref from, col);
						

						from [i] = GameObject.Find ("d" + i.ToString ()).transform; 
						GameObject textd = GameObject.Find ("textd" + i.ToString ());


						//set rowNum, i to full
						emptySquares [0, i] = false;
						from [i].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();

						

					}
					

				} else if (numInCol [i] == 2) {

					
					//MAYBE ADD THE 1, 2, 3, and 4 cases in if not just keep it at duplicates
					if ((aArray [i] == bArray [i]) && (aArray [i] >= 5 && bArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;

						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						//put the number in the proper slot in the aArray
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + bArray [i];
						tmb.text = dArray [i].ToString ();
						int toRowNum = 0;
						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;
						Destroy (from2 [0].gameObject);
						from2 [1].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [1].gameObject);
						from2 [1].name = "fullSquare0" + i.ToString ();
						textb.name = "text0" + i.ToString ();
						//make the spots that we came from -1
						aArray [i] = -1;
						bArray [i] = -1;
						updateScore (dArray [i]);

					} else if (aArray [i] != bArray [i] && ((aArray [i] >= 5 && bArray [i] >= 5))) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						int toRowNum1 = 0;
						int toRowNum2 = 1;
						to2 [0] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						to2 [1] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						//Make where the blocks are going full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmb.text);
						aArray [i] = -1;
						bArray [i] = -1;

						from2 [0].name = "fullSquare1" + i.ToString ();
						texta.name = "text1" + i.ToString ();
						from2 [1].name = "fullSquare0" + i.ToString ();
						textb.name = "text0" + i.ToString ();


					} else if ((aArray [i] == cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toRowNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [3, i] = true;
						emptySquares [1, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);
						from2 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();


						//make the spots that we came from -1
						aArray [i] = -1;
						cArray [i] = -1;
						updateScore (dArray [i]);
					} else if ((aArray [i] != cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)){
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toRowNum1 = 0;
						int toRowNum2 = 1;
						to2 [0] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [3, i] = true;
						emptySquares [1, i] = true;
						//Make where the blocks are going full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						aArray [i] = -1;
						from2 [0].name = "fullSquare1" + i.ToString ();
						texta.name = "text1" + i.ToString ();
						from2 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
					} 
					else if ((aArray [i] == dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toRowNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [3, i] = true;
						emptySquares [0, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();

						//make the spots that we came from -1
						aArray [i] = -1;
						updateScore (dArray [i]);
					} else if ((aArray [i] != dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toRowNum1 = 0;
						int toRowNum2 = 1;
						to2 [0] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [0, i] = true;
						emptySquares [3, i] = true;
						//Make where the blocks are going full
						emptySquares [1, i] = false;
						emptySquares [0, i] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						aArray [i] = -1;
						from2 [0].name = "fullSquare1" + i.ToString ();
						texta.name = "text1" + i.ToString ();
						from2 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
					} else if ((bArray [i] == cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);


						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toRowNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [2, i] = true;
						emptySquares [1, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);
						from2 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();

						//make the spots that we came from -1
						bArray [i] = -1;
						cArray [i] = -1;
						updateScore (dArray [i]);


					} else if ((bArray [i] != cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toRowNum1 = 1;
						int toRowNum2 = 0;
						to2 [1] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [1, i] = true;
						emptySquares [2, i] = true;
						//Make where the blocks are going full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						bArray [i] = -1;

						//set c and d back to original names
						from2 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from2 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
					} else if ((bArray [i] == dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						//Debug.Log ("I AM HERE!!!");
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toRowNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [2, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();

						//make the spots that we came from -1
						bArray [i] = -1;
						updateScore (dArray [i]);
						



					} else if ((bArray [i] != dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toRowNum1 = 1;
						int toRowNum2 = 0;
						to2 [1] = GameObject.Find ("EmptySquare" + toRowNum1.ToString () + i.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + toRowNum2.ToString () + i.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [0, i] = true;
						emptySquares [2, i] = true;
						//Make where the blocks are going full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						bArray [i] = -1;

						//set names of c and d back
						from2 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from2 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
					} else if ((cArray [i] == dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {

						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toRowNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + toRowNum.ToString () + i.ToString ()).transform;

						Destroy (from2 [2].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [0, i] = true;
						emptySquares [1, i] = true;
						emptySquares [toRowNum, i] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();

						//make the spots that we came from -1
						cArray [i] = -1;
						
						updateScore (dArray [i]);

					} else if ((cArray [i] != dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();

						//Make where the blocks are going full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						

						//set names of c and d back
						from2 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from2 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
					}

					
				} 
				else if (numInCol [i] == 3) {


					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);

						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare0" + i.ToString ()).transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						tmb.text = aArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);

						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = aArray [i];
						
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
						updateScore (dArray [i]);


					} 
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare0" + i.ToString ()).transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						tmb.text = aArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);

						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 
					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare0" + i.ToString ()).transform;
						cArray [i] = aArray [i] + bArray [i];
						tmb.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);

						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;

						dArray [i] = System.Int32.Parse(tmc.text);
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					}
					//Add all not equal case for abc
					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("EmptySquare0" + i.ToString ()).transform;
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						from3 [0].name = "fullSquare2" + i.ToString ();
						texta.name = "text2" + i.ToString ();
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [2].name = "fullSquare0" + i.ToString ();
						textc.name = "text0" + i.ToString ();
					}

					else if ((aArray [i] == bArray [i] && bArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot

						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						
						//set a and b to empty
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						//set c and d to full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						//

						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] != bArray [i] && bArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();

						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] == bArray [i] && bArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + bArray [i];
						tmb.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						
						emptySquares [3, i] = true;
						emptySquares [2, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;						
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare2" + i.ToString ();
						texta.name = "text2" + i.ToString ();
						from3 [1].name = "fullSquare1" + i.ToString ();
						textb.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
					}

					else if ((aArray [i] == cArray [i] && cArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [3, i] = true;
						emptySquares [2, i] = true;
						
						//set c and d to full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;

						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] != cArray [i] && cArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] == cArray [i] && cArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != cArray [i] && cArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare2" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare2" + i.ToString ();
						texta.name = "text2" + i.ToString ();
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
					}

					else if ((bArray [i] == cArray [i] && cArray [i] == dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [1].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						//set c and d to full
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;

						cArray [i] = bArray [i];
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 

					else if ((bArray [i] != cArray [i] && cArray [i] == dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						
						emptySquares [3, i] = true;
						emptySquares [2, i] = true;
						
						emptySquares [1, i] = false;
						emptySquares [0, i] = false;
						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					} 

					else if ((bArray [i] == cArray [i] && cArray [i] != dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare1" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (dArray [i]);
					}

					else if ((bArray [i] != cArray [i] && cArray [i] != dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tmb.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from3 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from3 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
					}


					


				} 
				else if (numInCol [i] == 4) {
					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];

						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [2, i] = true;
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						bArray [i] = aArray [i] + bArray [i];
						
						tmb.text = bArray [i].ToString ();
						Destroy (from4 [0].gameObject);

						
						emptySquares [3, i] = true;
						
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						
						aArray [i] = -1;
						

						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);

						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						
						tmc.text = cArray [i].ToString ();
						
						Destroy (from4 [0].gameObject);
						
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						
						tmc.text = cArray [i].ToString ();
						
						Destroy (from4 [0].gameObject);
						
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						dArray [i] = cArray [i] + dArray [i];
						
						tmd.text = dArray [i].ToString ();
						
						Destroy (from4 [0].gameObject);
						
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [3, i] = true;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						emptySquares [3, i] = false;
						emptySquares [0, i] = false;
						emptySquares [1, i] = false;
						emptySquares [2, i] = false;
						from4 [0].name = "fullSquare3" + i.ToString ();
						texta.name = "text3" + i.ToString ();
						from4 [1].name = "fullSquare2" + i.ToString ();
						textb.name = "text2" + i.ToString ();
						from4 [2].name = "fullSquare1" + i.ToString ();
						textc.name = "text1" + i.ToString ();
						from4 [3].name = "fullSquare0" + i.ToString ();
						textd.name = "text0" + i.ToString ();
						//goCount++;
					}
				}
				//yield return null;
			}
			
			StartCoroutine ("Spawn");

			StartCoroutine ("checkBoard");

			yield return null;
		}




	}

	//Add the Change Colors to Right and Left
	IEnumerator WaitForRightPress(){
		int totalFull = 0;
		//check for down press
		int counter = 0;





		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			
			initNumInColRow ();

			int count = transform.childCount - COUNT;
			for (int i = 0; i < count; i++) {
				a.Add (-1);
			}
			aArray = a.ToArray ();

			for (int i = 0; i < count; i++) {
				b.Add (-1);
			}
			bArray = b.ToArray ();

			for (int i = 0; i < count; i++) {
				c.Add (-1);
			}
			cArray = c.ToArray ();

			for (int i = 0; i < count; i++) {
				d.Add (-1);
			}
			dArray = d.ToArray ();




			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					if (emptySquares [i, j] == true) {
						//Debug.Log ("EMPTY AT I: " + i + " J: " + j);
					}
				}
			}

			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					//Search for number in same row
					//make sure the space is free

					if (emptySquares [i, j] == false) {

						//store the number thats filled on board
						totalFull++;

						//find the amount that is in a given column and row
						for (int k = 0; k < count; k++) {

							if (k == j) {
								numInCol [k]++;
							}
							if (k == i) {
								numInRow [k]++;
							}

						}

					}
				}
			}
			for (int i = 0; i < count; i++) {
				//Debug.Log("number in column "+numInRow [i]);
			}

			System.Array.Resize (ref from, totalFull);
			System.Array.Resize (ref to, totalFull);

			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {

					if (emptySquares [i, j] == false) {

						fs = GameObject.Find ("fullSquare" + i.ToString () + j.ToString ()).transform;

						if (i == 0) {
							if (j == 0) {


								fs.name = "a" + i.ToString ();

								//Debug.Log ("FSNAME === " + fs.name);

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [i] = System.Int32.Parse (tma.text);
								
							}
							if (j == 1) {
								fs.name = "b" + i.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textbj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();


								bArray [i] = System.Int32.Parse (tmb.text);

								
							}
							if (j == 2) {
								fs.name = "c" + i.ToString ();

								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								

							}
							if (j == 3) {
								fs.name = "d" + i.ToString ();
								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textdj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								
							}


						} 
						if (i == 1) {
							if (j == 0) {
								fs.name = "a" + i.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [i] = System.Int32.Parse (tma.text);
								
							}
							if (j == 1) {
								fs.name = "b" + i.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [i] = System.Int32.Parse (tmb.text);
								
							}
							if (j == 2) {
								fs.name = "c" + i.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								
							}
							if (j == 3) {
								fs.name = "d" + i.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								
							}
						}
						if (i == 2) {
							if (j == 0) {
								fs.name = "a" + i.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [i] = System.Int32.Parse (tma.text);
								

							}
							if (j == 1) {

								fs.name = "b" + i.ToString ();


								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + i.ToString ();



								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [i] = System.Int32.Parse (tmb.text);

								
							}
							if (j == 2) {
								fs.name = "c" + i.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								
							}
							if (j == 3) {

								fs.name = "d" + i.ToString ();


								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								
							}
						}
						if (i == 3) {
							if (j == 0) {

								//Set the name to aj
								fs.name = "a" + i.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								//aArray = a.ToArray ();
								aArray [i] = System.Int32.Parse (tma.text);
								


							}
							if (j == 1) {
								fs.name = "b" + i.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [i] = System.Int32.Parse (tmb.text);


								

							}
							if (j == 2) {

								//Debug.Log ("HELLOc3");
								fs.name = "c" + i.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								//cArray = c.ToArray ();
								cArray [i] = System.Int32.Parse (tmc.text);
								
							}
							if (j == 3) {

								fs.name = "d" + i.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								

							}
						}
						
					}
				}
			}



			

			for (int i = 0; i < count; i++) {
				if (numInRow [i] == 1) {

					

					//in row 0
					if (aArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);
						from [i] = GameObject.Find ("a" + i.ToString ()).transform; 
						GameObject texta = GameObject.Find ("texta" + i.ToString ());

						int toColNum = 3;
						to [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 0,i to empty
						emptySquares [i, 0] = true;

						//set 3, i to full
						emptySquares [i, 3] = false;
						from [i].name = "fullSquare" + i.ToString () + "3";
						texta.name = "text" + i.ToString () + "3";

						dArray [i] = aArray [i];
						aArray [i] = -1;
						

					}

					//in row 1
					else if (bArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);
						from [i] = GameObject.Find ("b" + i.ToString ()).transform; 
						GameObject textb = GameObject.Find ("textb" + i.ToString ());

						int toColNum = 3;

						to [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 1,i to empty
						emptySquares [i, 1] = true;

						//set 3, i to full
						emptySquares [i, 3] = false;
						from [i].name = "fullSquare" + i.ToString () + "3";
						textb.name = "text" + i.ToString () + "3";
						dArray [i] = bArray [i];
						bArray [i] = -1;




					}

					//in row 2
					else if (cArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);

						from [i] = GameObject.Find ("c" + i.ToString ()).transform; 
						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						int toColNum = 3;

						to [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 2,i to empty
						emptySquares [i, 2] = true;

						//set 3, i to full
						emptySquares [i, 3] = false;
						from [i].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";
						dArray [i] = cArray [i];
						cArray [i] = -1;

						
					}

					//in row 3
					else if (dArray [i] >= 5) {

						

						System.Array.Resize (ref from, col);

						from [i] = GameObject.Find ("d" + i.ToString ()).transform; 
						GameObject textd = GameObject.Find ("textd" + i.ToString ());



						//set rowNum, i to full
						emptySquares [i, 3] = false;
						from [i].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";




					}
					//yield return null;
				} else if (numInRow [i] == 2) {

					
					//MAYBE ADD THE 1, 2, 3, and 4 cases in if not just keep it at duplicates
					if ((aArray [i] == bArray [i]) && (aArray [i] >= 5 && bArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);


						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;

						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						//put the number in the proper slot in the aArray
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + bArray [i];
						tmb.text = dArray [i].ToString ();
						int toColNum = 3;
						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;
						Destroy (from2 [0].gameObject);
						from2 [1].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [1].gameObject);
						from2 [1].name = "fullSquare" + i.ToString () + "3";
						textb.name = "text" + i.ToString () + "3";
						//make the spots that we came from -1
						aArray [i] = -1;
						bArray [i] = -1;

						updateScore (dArray [i]);

					} else if (aArray [i] != bArray [i] && ((aArray [i] >= 5 && bArray [i] >= 5))) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						int toColNum1 = 2;
						int toColNum2 = 3;
						to2 [0] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum1.ToString ()).transform;
						to2 [1] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						//Make where the blocks are going full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmb.text);
						aArray [i] = -1;
						bArray [i] = -1;
						from2 [0].name = "fullSquare" + i.ToString () + "2";
						texta.name = "text" + i.ToString () + "2";
						from2 [1].name = "fullSquare" + i.ToString () + "3";
						textb.name = "text" + i.ToString () + "3";

					} else if ((aArray [i] == cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toColNum = 3;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 0] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);
						from2 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";

						//make the spots that we came from -1
						aArray [i] = -1;
						cArray [i] = -1;
						updateScore (dArray [i]);
					} else if ((aArray [i] != cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toColNum1 = 2;
						int toColNum2 = 3;
						to2 [0] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum1.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 0] = true;
						emptySquares [i, 2] = true;
						//Make where the blocks are going full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						aArray [i] = -1;
						from2 [0].name = "fullSquare" + i.ToString () + "2";
						texta.name = "text" + i.ToString () + "2";
						from2 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";

					} else if ((aArray [i] == dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toColNum = 3;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 0] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";

						//make the spots that we came from -1
						aArray [i] = -1;
						updateScore (dArray [i]);
						
					} else if ((aArray [i] != dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						//Debug.Log ("GETTING HERE");
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toColNum1 = 2;
						int toColNum2 = 3;
						to2 [0] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum1.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 0] = true;
						emptySquares [i, 3] = true;
						//Make where the blocks are going full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						aArray [i] = -1;
						from2 [0].name = "fullSquare" + i.ToString () + "2";
						texta.name = "text" + i.ToString () + "2";
						from2 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					} else if ((bArray [i] == cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toColNum = 3;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 1] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);
						from2 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";

						//make the spots that we came from -1
						bArray [i] = -1;
						cArray [i] = -1;
						updateScore (dArray [i]);

					} else if ((bArray [i] != cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toColNum1 = 2;
						int toColNum2 = 3;
						to2 [1] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum1.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 1] = true;
						emptySquares [i, 2] = true;
						//Make where the blocks are going full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						bArray [i] = -1;

						//set c and d back to original names
						from2 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from2 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";
					} else if ((bArray [i] == dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toColNum = 3;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 1] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3"; 

						//make the spots that we came from -1
						bArray [i] = -1;
						updateScore (dArray [i]);
						



					} else if ((bArray [i] != dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toColNum1 = 2;
						int toColNum2 = 3;
						to2 [1] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum1.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 1] = true;
						emptySquares [i, 3] = true;
						//Make where the blocks are going full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						bArray [i] = -1;

						//set names of c and d back
						from2 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from2 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					} else if ((cArray [i] == dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toColNum = 3;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [2].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare" + i.ToString () + "3";

						textd.name = "text" + i.ToString () + "3";

						//make the spots that we came from -1
						cArray [i] = -1;
						updateScore (dArray [i]);

					} else if ((cArray [i] != dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						//Make where the blocks are going full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from2 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from2 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					}
				} else if (numInRow [i] == 3) {
					//CHECK LEFT AND RIGHT 3s

					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i])
					    && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);

						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "3").transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						tmb.text = aArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);


					} else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "3").transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						tmb.text = aArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);

						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);
					} else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "3").transform;
						bArray [i] = aArray [i] + bArray [i];
						tmb.text = bArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = bArray [i];
						aArray [i] = -1;
						bArray [i] = -1;

						dArray [i] = System.Int32.Parse (tmc.text);
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);
					}
					//Add all not equal case for abc
					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "3").transform;
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);


						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						from3 [0].name = "fullSquare" + i.ToString () + "1";
						texta.name = "text" + i.ToString () + "1";
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [2].name = "fullSquare" + i.ToString () + "3";
						textc.name = "text" + i.ToString () + "3";
					} else if ((aArray [i] == bArray [i] && bArray [i] == dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = bArray [i] + dArray [i];
						tmb.text = aArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						//set a and b to empty
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						//set c and d to full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						//

						cArray [i] = aArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((aArray [i] != bArray [i] && bArray [i] == dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((aArray [i] == bArray [i] && bArray [i] != dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						bArray [i] = aArray [i] + bArray [i];
						tmb.text = bArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = bArray [i];
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((aArray [i] != bArray [i] && bArray [i] != dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [3] = GameObject.Find ("EmptySquare" + i.ToString () + "3").transform;
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare" + i.ToString () + "1";
						texta.name = "text" + i.ToString () + "1";
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					} else if ((aArray [i] == cArray [i] && cArray [i] == dArray [i])
					         && (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						//set c and d to full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;

						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((aArray [i] != cArray [i] && cArray [i] == dArray [i])
					         && (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((aArray [i] == cArray [i] && cArray [i] != dArray [i])
					         && (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Debug.Log ("GETTING  HERE!!!");
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((aArray [i] != cArray [i] && cArray [i] != dArray [i])
					         && (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						

						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare" + i.ToString () + "1";
						texta.name = "text" + i.ToString () + "1";


						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					} else if ((bArray [i] == cArray [i] && cArray [i] == dArray [i])
					         && (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [1].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						//set c and d to full
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;

						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((bArray [i] != cArray [i] && cArray [i] == dArray [i])
					         && (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();

						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((bArray [i] == cArray [i] && cArray [i] != dArray [i])
					         && (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (dArray [i]);

					} else if ((bArray [i] != cArray [i] && cArray [i] != dArray [i])
					         && (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tmb.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from3 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					}


					


				} else if (numInRow [i] == 4) {
					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray [i] == dArray [i])
					    && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray [i] == dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = true;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray [i] != dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						bArray [i] = aArray [i] + bArray [i];
						tmb.text = bArray [i].ToString ();
						Destroy (from4 [0].gameObject);

						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray [i] != dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray [i] != dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);

						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						
						tmc.text = cArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray [i] == dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = bArray [i];
						bArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray [i] == dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 0] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						cArray [i] = bArray [i];
						bArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
						updateScore (cArray [i]);
						updateScore (dArray [i]);

					} else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray [i] != dArray [i])
					         && (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 3] = false;
						from4 [0].name = "fullSquare" + i.ToString () + "0";
						texta.name = "text" + i.ToString () + "0";
						from4 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from4 [2].name = "fullSquare" + i.ToString () + "2";
						textc.name = "text" + i.ToString () + "2";
						from4 [3].name = "fullSquare" + i.ToString () + "3";
						textd.name = "text" + i.ToString () + "3";
					}
				}
				//yield return null;
			}

			StartCoroutine ("Spawn");
			StartCoroutine ("checkBoard");

			yield return null;



		}
	}

	IEnumerator WaitForLeftPress(){
		int totalFull = 0;
		//check for down press
		int counter = 0;





		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Debug.Log ("LEFTTTTT WAS PRESSSSEDDDD!!!!!");

			initNumInColRow ();

			int count = transform.childCount - COUNT;
			for (int i = 0; i < count; i++) {
				a.Add (-1);
			}
			aArray = a.ToArray ();

			for (int i = 0; i < count; i++) {
				b.Add (-1);
			}
			bArray = b.ToArray ();

			for (int i = 0; i < count; i++) {
				c.Add (-1);
			}
			cArray = c.ToArray ();

			for (int i = 0; i < count; i++) {
				d.Add (-1);
			}
			dArray = d.ToArray ();






			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {
					//Search for number in same row
					//make sure the space is free


					if (emptySquares [i, j] == false) {

						//store the number thats filled on board
						totalFull++;

						//find the amount that is in a given column and row
						for (int k = 0; k < count; k++) {

							if (k == j) {
								numInCol [k]++;
							}
							if (k == i) {
								numInRow [k]++;
							}

						}

					}
				}
			}
			for (int i = 0; i < count; i++) {
				//Debug.Log("number in column "+numInRow [i]);
			}


			System.Array.Resize (ref from, totalFull);
			System.Array.Resize (ref to, totalFull);
			for (int i = 0; i < row; i++) {
				for (int j = 0; j < col; j++) {


					if (emptySquares [i, j] == false) {
						//Debug.Log ("FULL SQUARES IN LEFT: " + i + ", " + j);
						fs = GameObject.Find ("fullSquare" + i.ToString () + j.ToString ()).transform;
						//Debug.Log ("FS ===== " + fs);

						if (i == 0) {
							//int column = j;
							if (j == 0) {
								fs.name = "d" + i.ToString ();
								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textdj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								
							}

							if (j == 1) {
								fs.name = "c" + i.ToString ();

								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								

							}

							if (j == 2) {
								fs.name = "b" + i.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textbj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();


								bArray [i] = System.Int32.Parse (tmb.text);

								
							}

							if (j == 3) {
								fs.name = "a" + i.ToString ();


								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [i] = System.Int32.Parse (tma.text);
								
							}



						} 
						if (i == 1) {
							if (j == 0) {
								fs.name = "d" + i.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								
							}
							if (j == 1) {
								fs.name = "c" + i.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								
							}

							if (j == 2) {
								fs.name = "b" + i.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [i] = System.Int32.Parse (tmb.text);
								
							}

							if (j == 3) {
								fs.name = "a" + i.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [i] = System.Int32.Parse (tma.text);
								
							}

						}
						if (i == 2) {

							if (j == 0) {

								fs.name = "d" + i.ToString ();


								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								
							}


							if (j == 1) {
								fs.name = "c" + i.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								
							}

							if (j == 2) {

								//Debug.Log ("I AM HERE");
								fs.name = "b" + i.ToString ();

								//Debug.Log ("FSNAME at spot 12: " + fs.name);

								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [i] = System.Int32.Parse (tmb.text);
								
							}

							if (j == 3) {
								fs.name = "a" + i.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								aArray [i] = System.Int32.Parse (tma.text);
								

							}

						}
						if (i == 3) {

							if (j == 0) {
								fs.name = "d" + i.ToString ();

								//find the textij object
								GameObject textd = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textd.name = "textd" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmd = textd.GetComponent<TextMesh> ();
								dArray [i] = System.Int32.Parse (tmd.text);
								

							}


							if (j == 1) {
								fs.name = "c" + i.ToString ();
								//find the textij object
								GameObject textc = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textc.name = "textc" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmc = textc.GetComponent<TextMesh> ();
								cArray [i] = System.Int32.Parse (tmc.text);
								
							}

							if (j == 2) {
								fs.name = "b" + i.ToString ();
								//find the textij object
								GameObject textb = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								textb.name = "textb" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tmb = textb.GetComponent<TextMesh> ();
								bArray [i] = System.Int32.Parse (tmb.text);
								

							}


							if (j == 3) {

								//Set the name to aj
								fs.name = "a" + i.ToString ();

								//find the textij object
								GameObject texta = GameObject.Find ("text" + i.ToString () + j.ToString ());

								//set the name to textaj
								texta.name = "texta" + i.ToString ();

								//put the number in the proper slot in the aArray
								TextMesh tma = texta.GetComponent<TextMesh> ();
								
								aArray [i] = System.Int32.Parse (tma.text);
								


							}

						}
						
					}
				}
			}
			

			for (int i = 0; i < count; i++) {
				if (numInRow [i] == 1) {


					//in row 0
					if (aArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);
						from [i] = GameObject.Find ("a" + i.ToString ()).transform; 
						GameObject texta = GameObject.Find ("texta" + i.ToString ());

						int toColNum = 0;
						to [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 0,i to empty
						emptySquares [i, 3] = true;

						//set 3, i to full
						emptySquares [i, 0] = false;
						from [i].name = "fullSquare" + i.ToString () + "0";
						texta.name = "text" + i.ToString () + "0";
						dArray [i] = aArray [i];
						aArray [i] = -1;
						

					}

					//in row 1
					else if (bArray [i] >= 5) {

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);
						//Transform fs = GameObject.Find("fullSquare1" + i.ToString()).transform;
						from [i] = GameObject.Find ("b" + i.ToString ()).transform; 
						GameObject textb = GameObject.Find ("textb" + i.ToString ());

						int toColNum = 0;
						//Debug.Log ("ToRowNUM: " + toRowNum);

						to [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 1,i to empty
						emptySquares [i, 2] = true;

						//set 3, i to full
						emptySquares [i, 0] = false;
						from [i].name = "fullSquare" + i.ToString () + "0";
						textb.name = "text" + i.ToString () + "0";
						dArray [i] = bArray [i];
						bArray [i] = -1;




					}

					//in row 2
					else if (cArray [i] >= 5) {
						//Debug.Log ("GETTING HERE");

						System.Array.Resize (ref from, col);
						System.Array.Resize (ref to, col);

						from [i] = GameObject.Find ("c" + i.ToString ()).transform; 
						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						int toColNum = 0;

						to [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						from [i].transform.position = new Vector3 (to [i].position.x, to [i].position.y, to [i].position.z - .5f);
						//set 2,i to empty
						emptySquares [i, 1] = true;

						//set 3, i to full
						emptySquares [i, 0] = false;
						from [i].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";
						dArray [i] = cArray [i];
						cArray [i] = -1;

						
					}

					//in row 3
					else if (dArray [i] >= 5) {

						

						System.Array.Resize (ref from, col);

						from [i] = GameObject.Find ("d" + i.ToString ()).transform; 
						GameObject textd = GameObject.Find ("textd" + i.ToString ());



						//set rowNum, i to full
						emptySquares [i, 0] = false;
						from [i].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";




					}

				} else if (numInRow [i] == 2) {

					
					//MAYBE ADD THE 1, 2, 3, and 4 cases in if not just keep it at duplicates
					if ((aArray [i] == bArray [i]) && (aArray [i] >= 5 && bArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);


						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;

						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						//put the number in the proper slot in the aArray
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + bArray [i];
						tmb.text = dArray [i].ToString ();
						int toColNum = 0;
						to2 [i] = GameObject.Find ("EmptySquare"+ i.ToString () + toColNum.ToString () ).transform;
						Destroy (from2 [0].gameObject);
						from2 [1].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);
						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, toColNum] = false;
					
						ChangeColors (dArray [i], from2 [1].gameObject);
						from2 [1].name = "fullSquare" + i.ToString () + "0";
						textb.name = "text" + i.ToString () + "0";
						//make the spots that we came from -1
						aArray [i] = -1;
						bArray [i] = -1;

						updateScore (dArray [i]);

					} else if (aArray [i] != bArray [i] && ((aArray [i] >= 5 && bArray [i] >= 5))) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						int toColNum1 = 1;
						int toColNum2 = 0;
						to2 [0] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum1.ToString ()).transform;
						to2 [1] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						//Make where the blocks are going full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmb.text);
						aArray [i] = -1;
						bArray [i] = -1;
						from2 [0].name = "fullSquare" + i.ToString () + "1";
						texta.name = "text" + i.ToString () + "1";
						from2 [1].name = "fullSquare" + i.ToString () + "0";
						textb.name = "text" + i.ToString () + "0";


					} else if ((aArray [i] == cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toColNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 1] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);
						from2 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";

						//make the spots that we came from -1
						aArray [i] = -1;
						cArray [i] = -1;
						updateScore (dArray [i]);
					} else if ((aArray [i] != cArray [i]) && (aArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toColNum1 = 1;
						int toColNum2 = 0;
						to2 [0] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum1.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum2.ToString () ).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 1] = true;
						emptySquares [i, 3] = true;
						//Make where the blocks are going full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						aArray [i] = -1;
						from2 [0].name = "fullSquare" + i.ToString () + "1";
						texta.name = "text" + i.ToString () + "1";
						from2 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";

					} else if ((aArray [i] == dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = aArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toColNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare"  + i.ToString ()+ toColNum.ToString ()).transform;

						Destroy (from2 [0].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 0] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";

						//make the spots that we came from -1
						aArray [i] = -1;
						
						updateScore (dArray [i]);

					} else if ((aArray [i] != dArray [i]) && (aArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toColNum1 = 1;
						int toColNum2 = 0;
						to2 [0] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum1.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum2.ToString ()).transform;
						from2 [0].transform.position = new Vector3 (to2 [0].position.x, to2 [0].position.y, to2 [0].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 0] = true;
						emptySquares [i, 3] = true;
						//Make where the blocks are going full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = System.Int32.Parse (tma.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						aArray [i] = -1;
						from2 [0].name = "fullSquare" + i.ToString () + "1";
						texta.name = "text" + i.ToString () + "1";
						from2 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					} else if ((bArray [i] == cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {

						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;

						GameObject textc = GameObject.Find ("textc" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();

						int toColNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [2].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 1] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [2].gameObject);
						from2 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";

						//make the spots that we came from -1
						bArray [i] = -1;
						cArray [i] = -1;
						updateScore (dArray [i]);

					} else if ((bArray [i] != cArray [i]) && (bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						int toColNum1 = 1;
						int toColNum2 = 0;
						to2 [1] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum1.ToString ()).transform;
						to2 [2] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum2.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [2].transform.position = new Vector3 (to2 [2].position.x, to2 [2].position.y, to2 [2].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 1] = true;
						emptySquares [i, 2] = true;
						//Make where the blocks are going full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);
						bArray [i] = -1;

						//set c and d back to original names
						from2 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from2 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";
					} else if ((bArray [i] == dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);

						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toColNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare" + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [1].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 2] = true;
						emptySquares [i, 0] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0"; 

						//make the spots that we came from -1
						bArray [i] = -1;
						
						updateScore (dArray [i]);


					} else if ((bArray [i] != dArray [i]) && (bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						int toColNum1 = 1;
						int toColNum2 = 0;
						to2 [1] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum1.ToString ()).transform;
						to2 [3] = GameObject.Find ("EmptySquare" + i.ToString ()  + toColNum2.ToString ()).transform;
						from2 [1].transform.position = new Vector3 (to2 [1].position.x, to2 [1].position.y, to2 [1].position.z - .5f);
						from2 [3].transform.position = new Vector3 (to2 [3].position.x, to2 [3].position.y, to2 [3].position.z - .5f);
						//Make where the blocks came from empty
						emptySquares [i, 2] = true;
						emptySquares [i, 0] = true;
						//Make where the blocks are going full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						bArray [i] = -1;

						//set names of c and d back
						from2 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from2 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					} else if ((cArray [i] == dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						GameObject textd = GameObject.Find ("textd" + i.ToString ());

						//put the number in the proper slot in the aArray
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						int toColNum = 0;

						to2 [i] = GameObject.Find ("EmptySquare"  + i.ToString () + toColNum.ToString ()).transform;

						Destroy (from2 [2].gameObject);


						from2 [3].position = new Vector3 (to2 [i].position.x, to2 [i].position.y, to2 [i].position.z - .5f);

						emptySquares [i, 1] = true;
						emptySquares [i, 0] = true;
						emptySquares [i, toColNum] = false;
						ChangeColors (dArray [i], from2 [3].gameObject);
						from2 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";

						//make the spots that we came from -1
						cArray [i] = -1;
						updateScore (dArray [i]);

					} else if ((cArray [i] != dArray [i]) && (cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from2, col);
						System.Array.Resize (ref to2, col);
						from2 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						from2 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						//Make where the blocks are going full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from2 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from2 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					}
					//yield return null;

				} 
				else if (numInRow [i] == 3) {


					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);

						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "0").transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;
						
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);

					} 
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "0").transform;
						dArray [i] = bArray [i] + cArray [i];
						tmc.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 
					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "0").transform;
						cArray [i] = aArray [i] + bArray [i];
						tmb.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = -1;

						dArray [i] = System.Int32.Parse(tmc.text);
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [2].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					}
					//Add all not equal case for abc
					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "0").transform;
						from3 [2].transform.position = new Vector3 (to3 [2].position.x, to3 [2].position.y, to3 [2].position.z - .5f);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);


						emptySquares [i, 3] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmc.text);

						from3 [0].name = "fullSquare" + i.ToString () + "2";
						texta.name = "text" + i.ToString () + "2";
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [2].name = "fullSquare" + i.ToString () + "0";
						textc.name = "text" + i.ToString () + "0";
					}

					else if ((aArray [i] == bArray [i] && bArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						//set a and b to empty
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						//set c and d to full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						//

						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString ()  + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] != bArray [i] && bArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = bArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = aArray [i];
						tmb.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] == bArray [i] && bArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + bArray [i];
						tmb.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);

						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [1].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [3] = GameObject.Find ("EmptySquare" + i.ToString () + "0").transform;
						from3 [1].transform.position = new Vector3 (to3 [1].position.x, to3 [1].position.y, to3 [1].position.z - .5f);
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [i, 3] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmb.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [0].name = "fullSquare" + i.ToString () + "2";
						texta.name = "text" + i.ToString () + "2";
						from3 [1].name = "fullSquare" + i.ToString () + "1";
						textb.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					}

					else if ((aArray [i] == cArray [i] && cArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [0].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						
						//set c and d to full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;

						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] != cArray [i] && cArray [i] == dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();

						Destroy (from3 [0].gameObject);
						
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = aArray [i];
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 

					else if ((aArray [i] == cArray [i] && cArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = aArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [0].gameObject);
						
						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;
						
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != cArray [i] && cArray [i] != dArray [i]) 
						&& (aArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [0] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("EmptySquare" + i.ToString () + "1").transform;
						to3 [3] = GameObject.Find ("EmptySquare" + i.ToString () + "0").transform;
						//Destroy (from3 [0].gameObject);
						
						from3 [0].transform.position = new Vector3 (to3 [0].position.x, to3 [0].position.y, to3 [0].position.z - .5f);

						emptySquares [i, 3] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tma.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);

						from3 [0].name = "fullSquare" + i.ToString () + "2";
						texta.name = "text" + i.ToString () + "2";
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					}

					else if ((bArray [i] == cArray [i] && cArray [i] == dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						//Grab information about the from and to
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						//Combine the bottom two
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						//Destroy the middle one
						Destroy (from3 [1].gameObject);

						//Move to new spot
						
						//set a and b to empty
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						//emptySquares [2, i] = false;
						//emptySquares [1, i] = true;
						//set c and d to full
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;

						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 

					else if ((bArray [i] != cArray [i] && cArray [i] == dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						cArray [i] = bArray [i];
						tmc.text = cArray [i].ToString ();

						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					} 

					else if ((bArray [i] == cArray [i] && cArray [i] != dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("EmptySquare" + i.ToString () + "2").transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from3 [1].gameObject);
						emptySquares [i, 3] = true;
						emptySquares [i, 2] = true;
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from3 [2].gameObject);
						ChangeColors (dArray [i], from3 [3].gameObject);
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (dArray [i]);
					}

					else if ((bArray [i] != cArray [i] && cArray [i] != dArray [i]) 
						&& (bArray [i] >= 5 && cArray [i] >= 5 && dArray [i] >= 5)) {
						System.Array.Resize (ref from3, col);
						System.Array.Resize (ref to3, col);
						from3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to3 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to3 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to3 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						emptySquares [i, 3] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = System.Int32.Parse (tmb.text);
						cArray [i] = System.Int32.Parse (tmc.text);
						dArray [i] = System.Int32.Parse (tmd.text);
						from3 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from3 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from3 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					}


					//yield return null;


				} 
				else if (numInRow [i] == 4) {


					if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;

						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;

						dArray [i] = cArray [i] + dArray [i];
						cArray [i] = aArray [i] + bArray [i];
						tmc.text = cArray [i].ToString ();
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						Destroy (from4 [1].gameObject);
						
						emptySquares [i, 2] = true;
						emptySquares [i, 3] = true;

						emptySquares [i, 1] = false;
						emptySquares [i, 0] = false;
						aArray [i] = -1;
						bArray [i] = -1;
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] == bArray [i] && bArray [i] != cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						bArray [i] = aArray [i] + bArray [i];
						tmb.text = bArray [i].ToString ();
						Destroy (from4 [0].gameObject);

						
						emptySquares [i, 3] = true;

						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 3] = true;
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}



					else if ((aArray [i] == bArray [i] && bArray [i] == cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);

						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						cArray [i] = bArray [i] + cArray [i];
						tmc.text = cArray [i].ToString ();
						tmb.text = tma.text;
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 3] = true;
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						bArray [i] = aArray [i];

						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString ()  + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						
						dArray [i] = cArray [i] + dArray [i];
						
						tmd.text = dArray [i].ToString ();
						
						Destroy (from4 [0].gameObject);
						
						emptySquares [i, 3] = true;
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						cArray [i] = bArray [i];
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						tmc.text = cArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}
					else if ((aArray [i] != bArray [i] && bArray [i] == cArray [i] && cArray[i] == dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						dArray [i] = cArray [i] + dArray [i];
						tmd.text = dArray [i].ToString ();
						Destroy (from4 [0].gameObject);
						emptySquares [i, 3] = true;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						emptySquares [i, 0] = false;
						cArray [i] = bArray [i];
						bArray [i] = aArray [i];
						tmb.text = bArray [i].ToString ();
						aArray [i] = -1;
						ChangeColors (bArray [i], from4 [1].gameObject);
						ChangeColors (cArray [i], from4 [2].gameObject);
						ChangeColors (dArray [i], from4 [3].gameObject);
						from4 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
						updateScore (cArray [i]);
						updateScore (dArray [i]);
					}

					else if ((aArray [i] != bArray [i] && bArray [i] != cArray [i] && cArray[i] != dArray[i]) 
						&& (aArray [i] >= 5 && bArray [i] >= 5 && cArray [i] >= 5 && dArray[i] >= 5)) {
						System.Array.Resize (ref from4, col);
						System.Array.Resize (ref to4, col);
						from4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						GameObject texta = GameObject.Find ("texta" + i.ToString ());
						TextMesh tma = texta.GetComponent<TextMesh> ();
						from4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						GameObject textb = GameObject.Find ("textb" + i.ToString ());
						TextMesh tmb = textb.GetComponent<TextMesh> ();
						from4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						GameObject textc = GameObject.Find ("textc" + i.ToString ());
						TextMesh tmc = textc.GetComponent<TextMesh> ();
						from4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						GameObject textd = GameObject.Find ("textd" + i.ToString ());
						TextMesh tmd = textd.GetComponent<TextMesh> ();
						to4 [0] = GameObject.Find ("a" + i.ToString ()).transform;
						to4 [1] = GameObject.Find ("b" + i.ToString ()).transform;
						to4 [2] = GameObject.Find ("c" + i.ToString ()).transform;
						to4 [3] = GameObject.Find ("d" + i.ToString ()).transform;
						emptySquares [i, 3] = false;
						emptySquares [i, 0] = false;
						emptySquares [i, 1] = false;
						emptySquares [i, 2] = false;
						from4 [0].name = "fullSquare" + i.ToString () + "3";
						texta.name = "text" + i.ToString () + "3";
						from4 [1].name = "fullSquare" + i.ToString () + "2";
						textb.name = "text" + i.ToString () + "2";
						from4 [2].name = "fullSquare" + i.ToString () + "1";
						textc.name = "text" + i.ToString () + "1";
						from4 [3].name = "fullSquare" + i.ToString () + "0";
						textd.name = "text" + i.ToString () + "0";
					}
				}
				//yield return null;
			}


			StartCoroutine ("Spawn");
			StartCoroutine ("checkBoard");

			yield return null;
		}




	}


	IEnumerator Spawn(){
		int count = 4;

		int m = 0;
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				if (emptySquares [i, j] == true) {
					
					iArray [m] = i;
					jArray [m] = j;
					m++;
				}
			}
		}
		if (m > 0) {
			int index = Random.Range (0, m);


			Debug.Log ("NUMBER SPAWNED IN: " + iArray[index] + ", " + jArray[index]);

			fullSquare100 = GameObject.CreatePrimitive (PrimitiveType.Plane);
			trans10 = GameObject.Find ("EmptySquare" + iArray [index].ToString () + jArray [index].ToString ()).transform;


			fullSquare100.transform.position = new Vector3 (trans10.position.x, trans10.position.y, trans10.position.z - .5f);
			fullSquare100.transform.Rotate (270.0f, 0, 0);
			fullSquare100.transform.localScale *= .21f;
			fullSquare100.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Five") as Material;
			fullSquare100.gameObject.name = "fullSquare" + iArray [index].ToString () + jArray [index].ToString ();
			text100 = Instantiate (Resources.Load ("Text")) as GameObject;
			text100.gameObject.transform.SetParent (fullSquare100.transform, false);
			text100.gameObject.name = "text" + iArray [index].ToString () + jArray [index].ToString ();
			tm100 = text100.GetComponent<TextMesh> ();
			tm100.text = "5";
			emptySquares [iArray [index], jArray [index]] = false;
			updateScore(5);

		}

		StartCoroutine ("checkBoard");

		yield return null;

	}
	public void ChangeColors(int num, GameObject fs){
		if (num == 5) {
			fs.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Five") as Material;
		}

		else if (num == 10) {
			fs.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Ten") as Material;
		}
		else if(num==20){
			fs.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Twenty") as Material;
		}
		else if(num==40){
			fs.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Forty") as Material;
		}
		else if(num>=80){
			fs.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Eighty") as Material;
		}

	}
		

}

