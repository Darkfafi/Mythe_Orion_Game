using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	private Rigidbody2D rigidbodyPlayer = null;
	public bool spikesUp = true;

	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.tag == "Player") {
			rigidbodyPlayer = hit.GetComponent<Rigidbody2D>();
			Debug.Log(rigidbodyPlayer);
		}
	}
	void Update () {
		if (rigidbodyPlayer != null) {
			if (rigidbodyPlayer.mass > 1000) {
				MoveUp();
			}
			else {
				MoveDown();
			}
		}
		else {
			MoveDown ();
		}
	}
	void MoveUp () {
		if(spikesUp == true && transform.localPosition.y < -1.5f){
			transform.Translate(Vector2.up * Time.deltaTime);
		}
	}
	void MoveDown () {
		if (spikesUp == true && transform.localPosition.y > -4.33f) {
			transform.Translate(Vector2.up * -Time.deltaTime);
		}
	}
	void OnTriggerExit2D (Collider2D hit) {
		if(hit.tag == "Player"){
			rigidbodyPlayer = null;
		}
	}
}
