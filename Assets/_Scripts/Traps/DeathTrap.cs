using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	public int DamageType; // 0 is instadeath, 1 is poison
	private DeathTimer DeathTimer = new DeathTimer();
	private PoisonTimer PoisonTimer = new PoisonTimer();

	void OnTriggerEnter(Collider other) {
		if(DamageType == 0){
			DeathTimer = other.gameObject.AddComponent("DeathTimer") as DeathTimer;
		}
		else {
			PoisonTimer = other.gameObject.AddComponent("PoisonTimer") as PoisonTimer;
		}
		//Destroy (this.gameObject);
	}
}
