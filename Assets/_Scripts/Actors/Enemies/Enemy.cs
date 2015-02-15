using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Creature {

	protected Vector3 _spawnPosition;// met dit kan je zeggen (Als hij zo ver is van zijn spawnpoint dan ga terug) ofzo.

	protected CapsuleCollider _view;
	protected float _viewRange;

	protected enum States{
		patrolState,
		chaseState,
		attackState
	}

	protected States state;

	protected override void Awake ()
	{
		base.Awake ();

		_view = gameObject.AddComponent<CapsuleCollider> ();
		_view.isTrigger = true;
		_view.radius = _viewRange;

		_spawnPosition = transform.position;

		state = States.patrolState;
	}

	void Update(){
		switch (state) {
			case States.patrolState:
				Patrol();
			break;

			case States.chaseState:
				Chase();
			break;

			case States.attackState:
				Attack();
			break;
		}
	}

	protected virtual void Patrol(){
		//ga naar een punt. Wacht daar even. Ga naar volgende waypoint
	}

	protected virtual void Chase(){
		//volg target tt target niet meer in zicht is, dood is of dicht bij genoeg is om aan te vallen..
	}

	protected override void HealthToZero ()
	{
		base.HealthToZero ();
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			_target = other;
			state = States.chaseState;
		}
	}

	void OnTriggerExit(Collider other){
		if(other == _target){
			_target = null;
			state = States.patrolState;
		}
	}
}
