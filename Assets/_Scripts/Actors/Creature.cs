using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

	//Een creature is alles wat leeft en beweegt.

	//Stats
	protected int _hp;
	protected float _moveSpeed;

	//combat
	protected GameObject _target;
	protected float _attackDmg; //voor basis. Wapens tellen hierbij op.
	protected float _fireRate; 
	protected float _attackRange;

	Movement moveScript;

	// Use this for initialization
	protected virtual void Awake () {
		SetStats ();

		moveScript = gameObject.AddComponent<Movement> ();
		gameObject.AddComponent<Health> ().health = _hp;

		moveScript.maxSpeed = _moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

	}

	protected virtual void SetStats(){

	}
	protected virtual void Attack(){

	}

	protected virtual void HealthToZero(){
		Debug.Log("bleh");
	}


}
