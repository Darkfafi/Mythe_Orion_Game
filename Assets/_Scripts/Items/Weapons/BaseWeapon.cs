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
}
