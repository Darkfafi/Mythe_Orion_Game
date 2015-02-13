using UnityEngine;
using System.Collections;

public class MeleeWeapon : BaseWeapon {

	protected override void Attack (GameObject target)
	{
		base.Attack (target);
		target.GetComponent<Health> ().RemoveHealth (damage);
	}
}
