using UnityEngine;
using System.Collections;

public class PoisonTimer : MonoBehaviour {

	private float finishTimer = 5;
	private float timer = 0.25f;
	private Health health;
	
	void Start (){
		health = GetComponent<Health> ();
	}
	
	void Update (){
		finishTimer -= Time.deltaTime;
		timer -= Time.deltaTime;
		if (finishTimer <= 0) {
			health.RemoveHealth(1);
			Destroy(this);
		}
		if (timer <= 0) {
			health.RemoveHealth(1);
			timer += 0.25f;
		}
	}
}
