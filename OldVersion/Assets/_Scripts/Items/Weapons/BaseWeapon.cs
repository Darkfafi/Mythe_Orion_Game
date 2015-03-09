using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class BaseWeapon : MonoBehaviour{


	protected string[] allAnimations = new string[]{};

	private float _timeToDmg;
	protected float attackTime;

	private float _nextTimeUseAble;
	private bool canUse = true; 

	[SerializeField] 
	private int _damage;  

	[SerializeField] 
	private float _range;

	[SerializeField] 
	private float _coolDownTime; 

	protected string userAnimation;

	protected virtual void Start(){

	}

	public int damage{
		get{return _damage;}
	}
	public float range{
		get{return _range;}
	}
	public float coolDownTime{
		get{return _coolDownTime;}
	}

	public virtual void Use(GameObject target,int attackInt = 0){
		if(Time.time > _nextTimeUseAble){
			if(GetComponentInParent<Player> ().CheckIfAnimationPlaying (allAnimations[attackInt]) == false){
				GetComponentInParent<Player>().PlayAnimation(allAnimations[attackInt],1.5f);
				_timeToDmg = attackTime + Time.time;
			}else if(canUse && Time.time > _timeToDmg){
				Attack(target);
			}
		}
	}
	protected virtual void Attack(GameObject target){
		//next time usable mag pas gezet worden nadat de animatie is afgespeeld. Anders telt de animatie als cooldown. Kan pas gemaakt worden met animatie though.
		_nextTimeUseAble = Time.time + coolDownTime;
	}
}
