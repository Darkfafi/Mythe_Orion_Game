using UnityEngine;
using System.Collections;

public class Harpy : Enemy {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void SetStats ()
	{
		base.SetStats ();
		_hp = 50;
		_attackDmg = 10;
		_viewRange = 10;
		_attackRange = 2;
	}
}
