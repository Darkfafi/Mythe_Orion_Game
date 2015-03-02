using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Gemaakt door Nick

public class HealthBar : MonoBehaviour {

	public Slider targetHealthSlider;
	private Health targetHealth;
	public CameraFocus cameraFocus;
	private GameObject target;
	private float healthValue;


	void Update (){
		if (target != cameraFocus.GetTarger ()) {
			target = cameraFocus.GetTarger ();
			targetHealth = target.GetComponent<Health> ();
			healthValue = targetHealth.health;
			targetHealthSlider.value = healthValue;
		}
		if (healthValue != targetHealth.health) {
			healthValue = targetHealth.health;
			ChangeHealth();
		}
	}

	void ChangeHealth (){
		targetHealthSlider.value = healthValue;
	}
}
