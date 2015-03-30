using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckIfPlayerThrewStar : MonoBehaviour {

	public GameObject playerToCheck;
	public string textAfterEvent;

	public bool hasToBeInRange = true;
	bool inRange = false;
	bool holdingStar = false;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject == playerToCheck){
			inRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject == playerToCheck){
			inRange = false;
		}
	}
	void Update(){
		if(playerToCheck.GetComponentInChildren<StarHolder>() != null){
			if(holdingStar && playerToCheck.GetComponentInChildren<StarHolder>().holdingStar == false){
				if(inRange && hasToBeInRange || !hasToBeInRange){
					GetComponent<Text>().text = textAfterEvent;
					Destroy(this);
				}
			}
			holdingStar = playerToCheck.GetComponentInChildren<StarHolder>().holdingStar == true;
		}
	}

}
