using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndLevel : MonoBehaviour {

	public int playersAtFinish = 0;
	public int totalPlayers = 1;

	void Start(){
		totalPlayers = GameObject.FindGameObjectsWithTag ("Player").Length;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			playersAtFinish += 1;
			if(playersAtFinish == totalPlayers){
				FinishLevel();
			}
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			playersAtFinish -= 1;
		}
	}

	void FinishLevel(){
		//Show Victory Screen.
		GameObject.Find ("GameController").GetComponent<DataManager> ().FinishLevelWithTime (GameObject.Find ("TimeText").GetComponent<UITimer>().TotalTime());
	}
}
