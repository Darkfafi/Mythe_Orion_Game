using UnityEngine;
using System.Collections;

public class RockCoordChecker : MonoBehaviour {

	private SoundController soundController;
	private float posX;
	private float posXDoubleCheck;
	private bool moving = true;
	private float timeBeforeCheck = 0.2f;

	void Start () {
		soundController = GetComponent<SoundController> ();
		posX = transform.position.x;
	}
	void Update () {
		//Debug.Log(posX + " " + transform.position.x);
		if(!moving){
			if (Mathf.Abs(transform.position.x - posXDoubleCheck) > 1) {
				moving = true;
				timeBeforeCheck = 0.5f;
				soundController.PlaySound(0, true);
			}
		}
		else if (timeBeforeCheck <= 0) {
			if (posXDoubleCheck == transform.position.x){
				soundController.StopSound();
				moving = false;
			}
			else {
				posXDoubleCheck = posX;
				posX = transform.position.x;
			}
		}
		else {
			timeBeforeCheck -= Time.deltaTime;
		}
	}
}
