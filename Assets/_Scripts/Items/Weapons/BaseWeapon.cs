using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class BaseWeapon : MonoBehaviour{

	private float _nextTimeUseAble;
	private bool canUse = true; 

	[SerializeField] 
	private int _damage;  

	[SerializeField] 
	private float _range;

	[SerializeField] 
	private float _coolDownTime;  


	public int damage{
		get{return _damage;}
	}
	public float range{
		get{return _range;}
	}
	public float coolDownTime{
		get{return _coolDownTime;}
	}

	public virtual void Use(GameObject target){
		if(canUse && Time.time > _nextTimeUseAble){
			Attack(target);
		}
	}
	protected virtual void Attack(GameObject target){
		//next time usable mag pas gezet worden nadat de animatie is afgespeeld. Anders telt de animatie als cooldown. Kan pas gemaakt worden met animatie though.
		_nextTimeUseAble = Time.time + coolDownTime;
	}
}
