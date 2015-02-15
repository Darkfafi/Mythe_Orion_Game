using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int _maxHealth;
	public int health;


	void Start(){
		_maxHealth = health;
	}

	public void AddHealth(int amount){
		health += amount;
		if(health > _maxHealth){
			health = _maxHealth;
		}
	}

	public void RemoveHealth(int amount){
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
