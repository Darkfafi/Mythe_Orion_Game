using UnityEngine;
using System.Collections;


public class Player : Creature {

	public GameObject[] weapons = new GameObject[]{};

	private GameObject _currentWeapon;

	private bool _movingToEnemy = false;

	// Use this for initialization
	void Start () {

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
			if (CheckIfInRange (_target)) {
				Attack();
			}else{
				_movingToEnemy = true;

				Ray raycast = new Ray(transform.position,_target.transform.position - transform.position);
				RaycastHit hit;

				if(!Physics.Raycast(raycast,out hit,1.5f) || hit.transform.gameObject == _target && Physics.Raycast(raycast,out hit,1.5f)){
					moveScript.MoveTransRotation(_target.transform.position - transform.position,_moveSpeed);
				}
			}
		}
		_movingToEnemy = false;
		//---- Test -----
		if (Input.GetKeyDown(KeyCode.Space)) {
			SwitchWeapon();
		}
		//---------
	}
	protected override void Attack (){
		_currentWeapon.GetComponent<BaseWeapon>().Use(_target);
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

	public void SwitchWeapon(int weaponInt = 9999){
		_currentWeapon.SetActive(false);
		if (weaponInt == 9999) {
			int index = System.Array.IndexOf(weapons,_currentWeapon);
			if(weapons.Length > index + 1){
				_currentWeapon = weapons[index + 1];
			}else{
				_currentWeapon = weapons[0];
			}
		}else{
			_currentWeapon = weapons[weaponInt];
		}
		_currentWeapon.SetActive(true);
	}

	public bool CheckIfInRange(GameObject target){
		bool result = false;

		float weaponRange = _currentWeapon.GetComponent<BaseWeapon> ().range;

		Ray raycast = new Ray (transform.position,target.transform.position - transform.position);
		RaycastHit hitInfo;
		if(Physics.Raycast(raycast,out hitInfo,weaponRange)){
			//Debug.Log(hitInfo.transform.gameObject);
			if(hitInfo.transform.gameObject == target.gameObject){
				result = true;
			}
		}
		//-----For Debugging------
		Vector3 test = target.transform.position - transform.position;
		test.Normalize ();
		Debug.DrawRay(transform.position, test * weaponRange,Color.red);
		//--------------

		return result;
	}
}
