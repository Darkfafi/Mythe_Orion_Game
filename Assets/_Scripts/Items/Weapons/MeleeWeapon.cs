using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class MeleeWeapon : BaseWeapon {

	protected override void Attack (GameObject target)
	{
		base.Attack (target);
		target.GetComponent<Creature> ().GetDamage (damage);
	}
}
