using UnityEngine;
using System.Collections;

public class StarHolder : MonoBehaviour {

	public GameObject star;
	public GameObject starPrefab;
	public bool holdingStar = false;

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
		}
	}
	public void OnTriggerEnter2D (Collider2D hit){
		if (hit.tag == "Star"){
			if(hit.GetComponent<StarBehavior>().goDown == true && tag == "Player2"){
				holdingStar = true;
				star.SetActive(true);
				Destroy(hit.gameObject);
			}
			else if (hit.GetComponent<StarBehavior>().goDown == false && tag == "Player1"){
				holdingStar = true;
				star.SetActive(true);
				Destroy(hit.gameObject);
			}
		}
		Debug.Log (hit.tag + " " + hit.GetComponent<StarBehavior>().goDown);
	}
	void OnMouseDown () {
		ThrowStar ();
	}
}
