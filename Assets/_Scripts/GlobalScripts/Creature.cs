using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

	//Een creature is alles wat leeft en beweegt.

	//Stats
	protected float _hp;
	protected float _moveSpeed;

	MovementScript moveScript;

	// Use this for initialization
	protected virtual void Start () {
		SetStats ();
		moveScript = GetComponent<MovementScript> ();
		moveScript.maxSpeed = _moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

	}

	protected virtual void SetStats(){

	}
}
