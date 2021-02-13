using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMovement : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GameObject score = GameObject.Find ("ScoreStuff");

		Transform canvas = score.transform.GetChild (0);
		Transform scoreText = canvas.transform.GetChild (0);
		Text scoreTxt = scoreText.gameObject.GetComponent<Text>();
		scoreTxt.fontSize = 35;
		RectTransform scoreTextRectTrans = scoreTxt.gameObject.GetComponent<RectTransform> ();
		//scoreTextRectTrans.sizeDelta = new Vector2 (400, 70);
		//scoreTextRectTrans.anchoredPosition = new Vector2 (56, 17);
		score.name = "ScoreStuff2";


		//scoreTextRectTrans.transform.position = new Vector3 (0,.1f,0f);

	}

	// Update is called once per frame
	void Update () {

	}
}
