using UnityEngine;
using System.Collections;

//Gemaakt door Nick

public class PressurePlate : MonoBehaviour {

	public DoorBehavior doorScript;
	public bool triggerOn = true;
	public bool destroyOnToggle = true;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" && triggerOn){
			ToggleDoor();
		}
	}

	private void ToggleDoor(){
		doorScript.ChangeDoorPos ();
		if (destroyOnToggle) {
			Destroy(gameObject);
		}
	}


	private void QuestComplete(){
		ToggleDoor ();
	}
}
