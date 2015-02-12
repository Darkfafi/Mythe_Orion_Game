using UnityEngine;
using System.Collections;

public class Player : Creature {

	public GameObject[] weapons = new GameObject[]{};

	private GameObject _currentWeapon;


	// Use this for initialization
	void Start () {

		CameraFocus.SetTarget(this.gameObject);
	}

	protected override void SetStats ()
	{
		base.SetStats ();

		_hp = 100;
		_moveSpeed = 3f;
	}
}
