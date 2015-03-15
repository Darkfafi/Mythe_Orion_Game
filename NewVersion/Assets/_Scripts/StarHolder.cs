using UnityEngine;
using System.Collections;

public class StarHolder : MonoBehaviour {

	public GameObject star;
	public GameObject starPrefab;
	public bool holdingStar = false;
	private bool starHit = false;

	void Start(){
		if (holdingStar == true && star.activeInHierarchy == false) {
			star.SetActive(true);
		}
		else if (holdingStar == false && star.activeInHierarchy == true) {
			star.SetActive(false);
		}
	}
	public void ThrowStar (){
		if (holdingStar == true) {
			Instantiate(starPrefab, star.transform.position, star.transform.rotation);
			holdingStar = false;
			star.SetActive(false);
			starHit = true;
		}
	}
	public void OnTriggerEnter2D (Collider2D hit){
		if (hit.tag == "Star"){
			if(starHit == true){
				starHit = false;
			}
			else {
				if(tag == "Player2"){
					holdingStar = true;
					star.SetActive(true);
					Destroy(hit.gameObject);
				}
				else if (tag == "Player1"){
					holdingStar = true;
					star.SetActive(true);
					Destroy(hit.gameObject);
				}
			}
		}
	}
}