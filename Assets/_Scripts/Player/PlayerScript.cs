using UnityEngine;
using System.Collections;

public class PlayerScript : Creature {

	// Use this for initialization
	protected override void Start () {

		base.Start ();
		CameraFocusScript.SetTarget(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}

	protected override void SetStats ()
	{
		base.SetStats ();
		_hp = 100f;
		_moveSpeed = 3f;
	}
}
