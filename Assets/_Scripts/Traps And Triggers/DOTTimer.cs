using UnityEngine;
using System.Collections;

//Gemaakt door Nick

public class DOTTimer : MonoBehaviour {

	public int DPS;
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
			Damage();
			Destroy(this);
		}
		if (timer <= 0) {
			Damage();
			timer += 0.25f;
		}
	}
	void Damage () {
		health.RemoveHealth(DPS / 4);
		if (health.health <= 0) {
			Destroy(this);
		}
	}
}
