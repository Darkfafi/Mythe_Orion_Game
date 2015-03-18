using UnityEngine;
using System.Collections;

public class StarHolder : MonoBehaviour {

	public GameObject star;
	public GameObject starPrefab;
	public bool holdingStar = false;
	private bool starHit = false;

	void Start(){
		if (holdingStar == true && star.activeInHierarchy == false) {
			CatchStar();

		}
		else if (holdingStar == false && star.activeInHierarchy == true) {
			star.SetActive(false);
		}
	}
	public void ThrowStar (){
		if (holdingStar == true) {
			GetComponentInParent<Rigidbody2D>().mass = 1;
			Instantiate(starPrefab, transform.position, transform.rotation);
			holdingStar = false;
			star.SetActive(false);
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
	void CatchStar(){
		GetComponentInParent<Rigidbody2D> ().mass = 10000;
		holdingStar = true;
		star.SetActive(true);
	}
}