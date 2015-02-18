using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	public int DPS;
	private DOTTimer dotTimer;

	void OnTriggerEnter(Collider other) {
		if(other.GetComponent<Health>()){
			dotTimer = other.gameObject.AddComponent<DOTTimer>();
			dotTimer.DPS = DPS;
		}
		//Destroy (this.gameObject);
	}
}
