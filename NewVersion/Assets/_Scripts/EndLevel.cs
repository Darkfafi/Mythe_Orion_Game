using UnityEngine;
using System.Collections;

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
				NextLevel();
			}
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			playersAtFinish -= 1;
		}
	}

	void NextLevel(){
		Debug.Log("Next level");
	}
}
