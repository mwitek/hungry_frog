using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
	public static int score;
	private Text ScoreCounterText;

	// Use this for initialization
	void Start () {
		score = 0;
		ScoreCounterText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreCounterText.text = score + " Flies";	
	}
}
