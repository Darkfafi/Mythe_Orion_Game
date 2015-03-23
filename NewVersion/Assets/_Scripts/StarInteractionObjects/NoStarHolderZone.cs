using UnityEngine;
using System.Collections;

public class NoStarHolderZone : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			collider2D.isTrigger = false;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			if(other.gameObject.rigidbody2D.mass > 500){
				collider2D.isTrigger = false;
			}
		}

	}

	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			if(other.gameObject.rigidbody2D.mass < 500){
				collider2D.isTrigger = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Star") {
			other.gameObject.transform.Rotate(new Vector3(0,0,180));
		}
	}
}
