using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	public int DPS;
	private DOTTimer dotTimer = new DOTTimer();

	void OnTriggerEnter(Collider other) {
		if(other.GetComponent<Health>()){
			dotTimer = other.gameObject.AddComponent("DOTTimer") as DOTTimer;
			dotTimer.DPS = DPS;
		}
		//Destroy (this.gameObject);
	}
}
