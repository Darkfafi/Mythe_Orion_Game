using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Gemaakt door Nick

public class HealthBar : MonoBehaviour {

	public Slider targetHealthSlider;
	private Health targetHealth;
	public CameraFocus cameraFocus;
	public GameObject target;
	private float healthInt;


	void Update (){
		if (target != cameraFocus.GetTarger ()) {
			target = cameraFocus.GetTarger ();
			targetHealth = target.GetComponent<Health> ();
			healthInt = targetHealth.health;
			targetHealthSlider.value = healthInt;
		}
		if (healthInt != targetHealth.health) {
			healthInt = targetHealth.health;
			ChangeHealth();
		}
	}

	void ChangeHealth (){
		targetHealthSlider.value = healthInt;
	}
}
