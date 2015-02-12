using UnityEngine;
using System.Collections;

public class Player : Creature {

	public GameObject[] weapons = new GameObject[]{};

	private GameObject _currentWeapon;

	private bool _movingToEnemy = false;

	// Use this for initialization
	protected override void Start () {

		base.Start ();
		CameraFocus.SetTarget(this.gameObject);
		_currentWeapon = weapons [0];
	}

	protected override void SetStats ()
	{
		base.SetStats ();

		_hp = 100;
		_moveSpeed = 3f;
	}
	void Update(){
		if (_target != null) {
			if (_currentWeapon.GetComponent<BaseWeapon> ().CheckIfInRange (_target)) {
				_currentWeapon.GetComponent<BaseWeapon>().Use(_target);
			}else{
				_movingToEnemy = true;
				moveScript.MoveTransRotation(_target.transform.position - transform.position,_moveSpeed);
			}
		}
		_movingToEnemy = false;
	}
	protected override void Attack (){

	}
	public override void NewTarget (GameObject target)
	{
		base.NewTarget (target);
	}

	void Moving(){
		if(_movingToEnemy == false){
			_target = null;
		}
	}
}
