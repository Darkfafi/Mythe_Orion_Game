﻿using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class Harpy : Enemy {

	protected override void SetStats ()
	{
		base.SetStats ();
		_hp = 50;
		_healthRegen = 1;
		_moveSpeed = 1.3f;

		_attackDmg = 10;
		_viewRange = 5;
		_attackRange = 1.5f;

		_attackDelay = 2f;
	}

	protected override void Attack ()
	{
		if(Vector3.Distance (transform.position, _target.transform.position) < _attackRange){
			_target.GetComponent<Creature> ().GetDamage (_attackDmg);
			//Debug.Log("Attack!");
		}
		base.Attack ();
	}
}
