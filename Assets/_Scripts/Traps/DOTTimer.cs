using UnityEngine;
using System.Collections;

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
			health.RemoveHealth(DPS / 4);
			Destroy(this);
		}
		if (timer <= 0) {
			health.RemoveHealth(DPS / 4);
			timer += 0.25f;
		}
	}
}
