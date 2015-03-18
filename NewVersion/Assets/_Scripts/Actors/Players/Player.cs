using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	PlayerMovement playerMove;

	void Awake () {
		playerMove = gameObject.AddComponent<PlayerMovement> ();
		gameObject.AddComponent<TouchAbleObject> ();
		gameObject.AddComponent<RigidBodyCalculator> ();

		playerMove.speed = 2f;
	}

	public void interactWithObject(GameObject interactionObject){
		InteractableObject interactSection = interactionObject.GetComponent<InteractableObject> ();
		if(interactSection.interactableWithStarUser && rigidbody2D.mass > 1000){
			interactSection.Interact();
		}
	}
}
