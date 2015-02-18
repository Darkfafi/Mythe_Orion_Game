using UnityEngine;
using System.Collections;

public class QuestPlateEnemyKills : MonoBehaviour {

	public int enemiesToKill;
	public bool checking = false;
	private int _enemiesKilled;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			checking = true;
		}
	}

	void Update(){
		gameObject.SendMessage ("QuestComplete");
	}
}
