using UnityEngine;
using System.Collections;

//Gemaakt door Nick

public class PressurePlate : MonoBehaviour {

	public DoorBehavior doorScript;
	public bool triggerOn = true;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" && triggerOn){
			ToggleDoor();
		}
	}

	private void ToggleDoor(){
		doorScript.ChangeDoorPos ();
	}


	private void QuestComplete(){
		ToggleDoor ();
	}
}
