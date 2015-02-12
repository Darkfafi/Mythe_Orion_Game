using UnityEngine;
using System.Collections;

public class BaseWeapon : MonoBehaviour{



	void Start(){

	}

	[SerializeField] 
	private int _damage;  

	[SerializeField] 
	private float _range;

	[SerializeField] 
	private float _fireRate;  


	public int damage{
		get{return _damage;}
	}
	public float range{
		get{return _range;}
	}
	public float fireRate{
		get{return _fireRate;}
	}

	public virtual void Use(GameObject target){

	}

	public bool CheckIfInRange(GameObject target,string tag = "BerendIsBestEenCooleGast"){
		bool result = false;

		Ray raycast = new Ray (transform.position,target.transform.position - transform.position);
		RaycastHit hitInfo;
		if(Physics.Raycast(raycast,out hitInfo,_range)){
			if(hitInfo.transform.gameObject.tag == tag || tag == "BerendIsBestEenCooleGast"){
				result = true;
			}
		}
		Vector3 test = target.transform.position - transform.position;
		test.Normalize ();
		Debug.DrawRay(transform.position, test * _range,Color.red);
		return result;
	}
}
