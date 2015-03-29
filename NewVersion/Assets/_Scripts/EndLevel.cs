using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndLevel : MonoBehaviour {

	public int playersAtFinish = 0;
	public int totalPlayers = 1;
	public GameObject victoryScreen;

	void Start(){
		totalPlayers = GameObject.FindGameObjectsWithTag ("Player").Length;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<StarHolder>() != null) {
			playersAtFinish += 1;
			if(playersAtFinish == totalPlayers){
				FinishLevel();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.GetComponent<StarHolder>() != null){
			playersAtFinish -= 1;
		}
	}

	void FinishLevel(){
		Time.timeScale = 0;
		GameObject.Find ("GameController").GetComponent<DataManager> ().FinishLevelWithTime (GameObject.Find ("TimeText").GetComponent<UITimer>().TotalTime());
		GameObject victory;
		GameObject canvas = GameObject.Find ("UI");
		victory = Instantiate (victoryScreen, canvas.transform.position, transform.rotation) as GameObject;
		victory.transform.SetParent(canvas.transform,false);
		victory.transform.position = canvas.transform.position;
	}
}
