using UnityEngine;
using System.Collections;

public class StarHolder : MonoBehaviour {

	public GameObject starPrefab;
	public bool startWithStar = false;
	private bool holdingStar = false;
	private bool starHit = false;


	void Start(){
		if(startWithStar){
			CatchStar();
		}
	}

	public void ThrowStar (){
		if (holdingStar == true) {
			GetComponentInParent<Rigidbody2D>().mass = 1;
			Instantiate(starPrefab, transform.position, transform.rotation);
			holdingStar = false;
			starHit = true;
		}
	}
	void OnTriggerEnter2D (Collider2D hit){
		if (hit.tag == "Star"){
			if(starHit == true){
				starHit = false;
			}
			else {
				CatchStar();
				Destroy(hit.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag != "Star"){
			GetComponentInParent<PlayerMovement>().Stop();
		}
	}

	void CatchStar(){
		GetComponentInParent<Rigidbody2D> ().mass = 10000;
		holdingStar = true;
		SendMessageUpwards ("CaughtStar");
	}
	void PlayerDeath(){
		if(startWithStar){
			CatchStar();
		}
	}
}