using UnityEngine;
using System.Collections;

public class QuestPlateEnemyKills : MonoBehaviour {

	public int enemiesToKill;
	public bool checking = false;

	private int totalEnemiesOnStart;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			checking = true;
			Destroy(gameObject.GetComponent<BoxCollider>());
			totalEnemiesOnStart = GameObject.FindGameObjectsWithTag("Enemy").Length;
		}
	}

	void Update(){
		if(checking){
			int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
			if( currentEnemyCount <= totalEnemiesOnStart - enemiesToKill){
				checking = false;
				gameObject.SendMessage ("QuestComplete");
				Destroy(this);
			}
		}
	}
}
