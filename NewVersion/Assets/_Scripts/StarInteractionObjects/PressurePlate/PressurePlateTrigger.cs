using UnityEngine;
using System.Collections;

public class PressurePlateTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hit) {
		//Debug.Log("Enter");
		if (hit.tag == "Player") {
			BroadcastMessage("PlayerOnPlate",hit.gameObject);
		}
	}
	void OnTriggerExit2D (Collider2D hit) {
		if(hit.tag == "Player"){
			BroadcastMessage("PlayerLeftPlate");
		}
	}
}
