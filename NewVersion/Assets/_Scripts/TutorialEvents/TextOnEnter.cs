using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextOnEnter : MonoBehaviour {

	public GameObject targetPlayer;
	public string textAfterEvent;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == targetPlayer.gameObject) {
			GetComponent<Text>().text = textAfterEvent;
			Destroy(this);
		}
	}
}
