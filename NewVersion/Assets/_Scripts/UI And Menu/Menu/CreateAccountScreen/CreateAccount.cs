using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateAccount : MonoBehaviour {

	public GameObject reportText;
	PlayerProgression playerProg;

	// Use this for initialization
	void Start () {
		playerProg = GetComponent<PlayerProgression> ();
	}

	public void SubmitName(){
		string usernameGiven = GameObject.Find("UserNameInput").GetComponent<Text>().text;
		if(usernameGiven.Length < 3){
			reportText.GetComponent<Text>().text = "Account name must be at least 3 characters long";
		}else if(usernameGiven.Length > 15){
			reportText.GetComponent<Text>().text = "Account name can't be longer than 15 characters";
		}
		else{
			StartCreateAccount(usernameGiven);
		}
	}

	void StartCreateAccount(string name){
		playerProg.nameUser = name;
		playerProg.currentLevel = 0;
		playerProg.currentPlayingLevel = 0;
		playerProg.levelsCompleteWithTime = new Dictionary<int, int> (); 
		GetComponent<SaveLoadData> ().Save ();
		Application.LoadLevel ("Menu");
	}
}
