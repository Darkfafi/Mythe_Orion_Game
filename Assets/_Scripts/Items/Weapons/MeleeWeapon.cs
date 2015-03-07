using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class MeleeWeapon : BaseWeapon {

	protected override void Start ()
	{
		base.Start ();
		allAnimations = new string[]{"BasicHammerAttack"};
	}

	public override void Use (GameObject target, int attackInt)
	{
		attackTime = 0.4f;
		base.Use (target, attackInt);
	}

	protected override void Attack (GameObject target)
	{
		base.Attack (target);
		target.GetComponent<Creature> ().GetDamage (damage);
	}
}
