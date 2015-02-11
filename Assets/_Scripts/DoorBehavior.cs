using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	public bool doorOpen = false;
	private bool doorMoving = false;

	void Awake () {
		if (doorOpen == true) {
			transform.Translate(Vector3.up * 2.7f);
		}
	}

	void Update () {
		if (doorMoving == true) {
			if(doorOpen == true){
				transform.Translate(Vector3.up * Time.deltaTime);
				if(transform.localPosition.y >= 2.7){
					doorMoving = false;
				}
			}
			else {
				transform.Translate(Vector3.down * Time.deltaTime);
				if(transform.localPosition.y <= 0){
					doorMoving = false;
				}
			}
		}
	}
	public void ChangeDoorPos () {
		if(doorOpen == true){
			doorOpen = false;
		}
		else {
			doorOpen = true;
		}
		doorMoving = true;
	}
}
