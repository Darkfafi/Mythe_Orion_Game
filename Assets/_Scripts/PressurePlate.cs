﻿using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public DoorBehavior doorScript;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			doorScript.ChangeDoorPos ();
			Destroy(this.gameObject);
			Destroy(this);
		}
	}
}