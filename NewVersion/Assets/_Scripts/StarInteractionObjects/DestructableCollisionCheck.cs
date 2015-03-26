using UnityEngine;
using System.Collections;

public class DestructableCollisionCheck : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hit){
		if (hit.tag == "Star") {
			GetComponent<SoundController>().PlaySound(0, false);
			DestroyAnim();
		}
		if (hit.tag == "Player") {
			hit.GetComponent<PlayerMovement>().Stop();
		}
	}

	void DestroyAnim(){
		GetComponent<Animator>().Play("Destroy");
	}

	public void DestroyObject(){
		Destroy (this.gameObject);
	}
}
