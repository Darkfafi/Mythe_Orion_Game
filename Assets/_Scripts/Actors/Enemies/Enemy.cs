﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Creature {

	protected Vector3 _spawnPosition;// met dit kan je zeggen (Als hij zo ver is van zijn spawnpoint dan ga terug) ofzo.
	
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

		View view;

		view = gameObject.AddComponent<View> ();
		view.ChangeViewRange (_viewRange);

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
		Vector3 raycastDirection = _target.transform.position - transform.position;
		Ray ray = new Ray(transform.position, raycastDirection);
		RaycastHit hit;
		Debug.DrawRay(transform.position, raycastDirection * _viewRange / 4);
		
		if(Physics.Raycast(ray, out hit,_viewRange)){
			if(hit.transform.tag == "Player"){
				moveScript.MoveTransRotation(raycastDirection,_moveSpeed);
				if (Vector3.Distance (transform.position, _target.transform.position) < _attackRange) {
					state = States.attackState;
				}
			}
		}
	}
	
	protected override void HealthToZero ()
	{
		base.HealthToZero ();
		Destroy (this.gameObject);
	}

	void CameIntoView(Collider other){
	
		if(other.gameObject.tag == "Player"){
			_target = other.gameObject;
			state = States.chaseState;

		}
	}

	void GotOutOfView(Collider other){
		if(other.gameObject == _target){
			_target = null;
			state = States.patrolState;
		}
	}
}
