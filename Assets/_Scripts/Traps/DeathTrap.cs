using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	public int DPS;
	private DOTTimer dotTimer = new DOTTimer();

	void OnTriggerEnter(Collider other) {
		dotTimer = other.gameObject.AddComponent("DOTTimer") as DOTTimer;
		dotTimer.DPS = DPS;
		//Destroy (this.gameObject);
	}
}
