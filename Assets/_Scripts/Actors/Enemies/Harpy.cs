using UnityEngine;
using System.Collections;

public class Harpy : Enemy {

	protected override void SetStats ()
	{
		base.SetStats ();
		_hp = 50;
		_moveSpeed = 3;
		_attackDmg = 10;
		_viewRange = 5;
		_attackRange = 1.5f;
	}
}
