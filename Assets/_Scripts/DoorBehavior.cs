using UnityEngine;
using System.Collections;

//Gemaakt door Nick

public class DoorBehavior : MonoBehaviour {

	public bool doorOpen = false;
	private bool doorMoving = false;
	public BoxCollider doorCollider;

	void Awake () {
		if (doorOpen == true) {
			transform.Translate(Vector3.up * 2.7f);
			doorCollider.enabled = false;
		}
	}

	void Update () {
		if (doorMoving == true) {
			if(doorOpen == true){
				transform.Translate(Vector3.up * Time.deltaTime);
				if(transform.localPosition.y >= 2.7){
					doorMoving = false;
					doorCollider.enabled = false;
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
			doorCollider.enabled = true;
		}
		else {
			doorOpen = true;
		}
		doorMoving = true;
	}
}
