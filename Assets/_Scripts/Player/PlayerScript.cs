using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float movSpeed = 2f;

	MovementScript moveScript;

	// Use this for initialization
	void Start () {
		moveScript = GetComponent<MovementScript> ();
		moveScript.maxSpeed = 2f;
		CameraFocusScript.SetTarget(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
