using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Slider targetHealthSlider;
	private Health targetHealth;
	public GameObject target;
	private int health;

	void Start (){
		targetHealth = target.GetComponent<Health> ();
		health = targetHealth.health;
		targetHealthSlider.value = health;
	}

	void Update (){
		if (health != targetHealth.health) {
			ChangeHealth();
			health = targetHealth.health;
		}
	}

	void ChangeHealth (){
		targetHealthSlider.value = health;
	}
}
