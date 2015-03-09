using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class Health : MonoBehaviour {

	public float _maxHealth;
	public float health;


	void Start(){
		_maxHealth = health;
	}

	public void AddHealth(float amount){
		health += amount;
		if(health > _maxHealth){
			health = _maxHealth;
		}
	}

	public void RemoveHealth(float amount){
		health -= amount;
		gameObject.SendMessage ("LostHealth");
		if(health <= 0){
			health = 0;
			HealthHitZero();
		}
	}

	private void HealthHitZero(){
		gameObject.SendMessage ("HealthToZero");
	}
}
