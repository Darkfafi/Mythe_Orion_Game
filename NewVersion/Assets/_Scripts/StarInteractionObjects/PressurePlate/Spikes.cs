using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.tag == "Player") {
			//TODO spikes hit
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player") as GameObject[];
			for(int i = 0; i < players.Length; i++){
				players[i].GetComponent<Player>().Death();
			}
		}
	}
}
