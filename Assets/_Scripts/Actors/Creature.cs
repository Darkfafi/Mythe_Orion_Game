using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class Creature : MonoBehaviour {

	//Een creature is alles wat leeft en beweegt.

	//Stats
	protected float _hp;
	protected float _healthRegen;
	protected float _moveSpeed;

	//combat
	protected GameObject _target;
	protected int _attackDmg; //voor basis. Wapens tellen hierbij op.
	protected float _attackRate; 
	protected float _attackRange;

	protected Movement moveScript;
	protected Health healthScript;

	Animator anim;

	// Use this for initialization
	protected virtual void Awake () {
		SetStats ();

		moveScript = gameObject.AddComponent<Movement> ();
		healthScript = gameObject.AddComponent<Health> ();

		healthScript.health = _hp;

		moveScript.maxSpeed = _moveSpeed;

		anim = GetComponent<Animator> ();
	}
	protected virtual void SetStats(){

	}
	protected virtual void Attack(){

	}

	protected virtual void Update(){
		healthScript.AddHealth (_healthRegen * Time.deltaTime);
	}

	public virtual void NewTarget(GameObject target){
		_target = target;
	}

	protected virtual void LostHealth(){
		HitMark ();
	}
	protected virtual void HealthToZero(){
		Debug.Log("Creature is Dead ;-;");
	}

	public virtual void GetDamage(int dmg){
		healthScript.RemoveHealth (dmg);
	}

	private void HitMark(){
		renderer.material.color = new Color(1f,0.2f,0.2f,0.2f);
		Invoke("ChangeBack",0.1f);
	}
	private void ChangeBack(){
		renderer.material.color = new Color (1f, 1f, 1f, 0.5f);
	}

	protected virtual void Moving(float speed){

	}
	protected virtual void StoppedMoving(){

	}

	public virtual void PlayAnimation(string animationName,float animationSpeed = 9999){
		anim.speed = 1;
		if(animationSpeed != 9999){
			//anim.animation[animationName].speed = animationSpeed;
			anim.speed = animationSpeed;
		}
		anim.Play (animationName);
	}
}
