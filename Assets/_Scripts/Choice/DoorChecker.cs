using UnityEngine;
using System.Collections;

public class DoorChecker : MonoBehaviour {
	
	public GameObject playerProgressionObject;
	private PlayerProgression playerProgression;
	public bool GoodChoice = true;
	private DoorBehavior doorBehavior;

	void Start (){
		playerProgression = playerProgressionObject.GetComponent<PlayerProgression>();
		playerProgressionObject = null;
		doorBehavior = gameObject.GetComponent<DoorBehavior> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			if(GoodChoice == true){
				if(playerProgression.goodPoints >= playerProgression.evilPoints){
					doorBehavior.ChangeDoorPos();
				}
			}
			else {
				if(playerProgression.goodPoints <= playerProgression.evilPoints){
					doorBehavior.ChangeDoorPos();
				}
			}
			Destroy(this);
		}
	}
}
