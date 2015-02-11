using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public GameObject door;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			door.GetComponent<DoorScript>().ChangeDoorPos ();
			Destroy(this.gameObject);
		}
	}
}
