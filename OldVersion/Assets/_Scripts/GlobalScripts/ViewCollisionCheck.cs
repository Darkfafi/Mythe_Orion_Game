using UnityEngine;
using System.Collections;

public class ViewCollisionCheck : MonoBehaviour {

	void OnTriggerStay(Collider other){
		//Debug.Log ("fdgfdfgdfg");
		SendMessageUpwards ("CameIntoView",other);
	}
	
	void OnTriggerExit(Collider other){
		SendMessageUpwards ("GotOutOfView",other);
	}
}
