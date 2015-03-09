using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Gemaakt door Ramses

public class Enemy : Creature {

	protected Vector3 _spawnPosition;// met dit kan je zeggen (Als hij zo ver is van zijn spawnpoint dan ga terug) ofzo.
	
	protected float _viewRange;

	protected float _attackDelay;

	private float _nextAttackTime;

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

	protected override void Update(){
		base.Update ();
		switch (state) {
			case States.patrolState:
				Patrol();
			break;

			case States.chaseState:
				Chase();
			break;

			case States.attackState:
				if(_nextAttackTime < Time.time){
					Attack();
				}
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
		Debug.DrawRay (transform.position, raycastDirection * _viewRange / 4);

		if(Physics.Raycast(ray, out hit)){
			if(hit.transform.tag == "Player"){
				if (Vector3.Distance (transform.position, _target.transform.position) < _attackRange) {
					state = States.attackState;
				}else{
					moveScript.MoveTransRotation(raycastDirection,_moveSpeed);
				}
			}
		}
	}

	protected override void LostHealth ()
	{
		base.LostHealth ();
		
		_target = GameObject.Find("Player");
		state = States.chaseState;

	}

	protected override void HealthToZero ()
	{
		base.HealthToZero ();
		Destroy (this.gameObject);
	}

	void CameIntoView(Collider other){
	
		if(other.gameObject.tag == "Player" && state != States.attackState){
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
	protected override void Attack ()
	{
		base.Attack ();

		_nextAttackTime = Time.time + _attackDelay;

		if(_target != null){
			state = States.chaseState;
		}else{
			state = States.patrolState;
		}
	}
}
