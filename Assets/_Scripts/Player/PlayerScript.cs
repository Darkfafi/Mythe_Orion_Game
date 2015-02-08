using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	MovementScript moveScript;

	// Use this for initialization
	void Start () {
		moveScript = GetComponent<MovementScript> ();
		CameraFocusScript.SetTarget(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		moveScript.Move (MovementScript.BACKWARD, 1);
	}
}
