using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class RangedWeapon : BaseWeapon {

	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private GameObject spawnPosition;

	[SerializeField]
	private float speedProjectile;

	protected override void Start ()
	{
		base.Start ();
		allAnimations = new string[]{"BasicBowAttack"};
	}

	public override void Use (GameObject target, int attackInt)
	{
		attackTime = 0.4f;
		base.Use (target, attackInt);
	}

	protected override void Attack (GameObject target)
	{
		base.Attack (target);
		spawnPosition.gameObject.transform.LookAt (target.transform.position);
		GameObject currentProjectile = Instantiate(projectile,spawnPosition.transform.position,spawnPosition.transform.rotation) as GameObject;

		currentProjectile.GetComponent<Projectile> ().SetStats (damage,speedProjectile);
	}
}
