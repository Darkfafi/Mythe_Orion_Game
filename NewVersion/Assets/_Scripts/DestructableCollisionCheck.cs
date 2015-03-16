using UnityEngine;
using System.Collections;

public class DestructableCollisionCheck : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hit){
		if (hit.tag == "Star") {
			DestroyObject();
		}
		if (hit.tag == "Player") {
			hit.GetComponent<PlayerMovement>().Stop();
		}
	}
	void DestroyObject(){
		Destroy (this.gameObject);
	}
}
