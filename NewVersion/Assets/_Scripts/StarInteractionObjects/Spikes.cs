using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.tag == "Player") {
			//TODO spikes hit
			print("spikes hit");
		}
	}
}
