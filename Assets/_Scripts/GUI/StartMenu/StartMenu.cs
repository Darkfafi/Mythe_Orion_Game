using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	public int highScore = 0;
	public Text highscoreText;
	// Use this for initialization

	void Start (){
		highscoreText.text = "Highscore = " + highScore;
	}
	public void Continue () {
		//TODO Continue function
	}

	public void NewGame () {
		//TODO NewGame function
	}
	public void NewGamePlus () {
		//TODO NewGamePlus function
	}
}
