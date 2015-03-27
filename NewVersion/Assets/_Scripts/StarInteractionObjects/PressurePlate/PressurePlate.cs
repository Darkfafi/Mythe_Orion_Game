using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	private Rigidbody2D rigidbodyPlayer = null;
	public bool spikesUp = true;
	private SoundController soundController;
	private bool soundPlaying = false;

	void Start () {
		soundController = GetComponent<SoundController> ();
	}

	void PlayerOnPlate (GameObject hit) {
		rigidbodyPlayer = hit.GetComponent<Rigidbody2D>();
		//Debug.Log(rigidbodyPlayer);
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
		if(spikesUp == true && transform.localPosition.y < -1.3f){
			transform.Translate(Vector2.up * Time.deltaTime * 1.15f);
			if(!soundPlaying){
				soundController.PlaySound(0, false);
				soundPlaying = true;
			}
		}
		else {
			if(soundPlaying == true) {
				soundController.StopSound();
				soundPlaying = false;
			}
		}
	}
	void MoveDown () {
		if (spikesUp == true && transform.localPosition.y > -4.33f) {
			transform.Translate(Vector2.up * -Time.deltaTime * 1.15f);
			if(!soundPlaying){
				soundController.PlaySound(0, false);
				soundPlaying = true;
			}
		}
		else {
			if(soundPlaying == true) {
				soundController.StopSound();
				soundPlaying = false;
			}
		}
	}
	void PlayerLeftPlate () {
		rigidbodyPlayer = null;
	}
}
