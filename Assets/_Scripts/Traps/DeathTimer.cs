using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

	private float timer = 5;
	private Health health;

	void Start (){
		health = GetComponent<Health> ();
	}

	void Update (){
		timer -= Time.deltaTime;
		if (timer <= 0) {
			health.RemoveHealth(1000);
			Destroy(this);
		}
	}
}
