using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	PlayerMovement playerMove;
	float differents;
	GameObject targetObject;

	private bool movingToDestination = false;

	void Awake () {
		playerMove = gameObject.AddComponent<PlayerMovement> ();
		gameObject.AddComponent<TouchAbleObject> ();
		gameObject.AddComponent<RigidBodyCalculator> ();

		playerMove.speed = 2f;
	}

	public void interactWithObject(GameObject interactionObject){
		targetObject = interactionObject;
		InteractableObject interactSection = interactionObject.GetComponent<InteractableObject> ();

		if(InInteractionRangeTarget()){
			InteractWithTarget();
		}else{
			if(movingToDestination == false){
		 		differents = interactionObject.transform.position.x - transform.position.x;
				movingToDestination = true;
				playerMove.Stop();
			}
		}
	}
	void Update(){
		if (playerMove.getControlling ()) {
			movingToDestination = false;
		}
		if(movingToDestination){
			int direction = playerMove.currentDir;
			if(!InInteractionRangeTarget()){
				if(playerMove.currentDir == 0){ //<-- zodat het maar 1 keer word berekend.
					if(differents < 0){
						direction = -1;
					}else{
						direction = 1;
					}
					if(gameObject.transform.rotation.z >= 0.8 && gameObject.transform.rotation.z < 1.2){
						direction *= -1;
					}
				}
				playerMove.Move(direction);
			}else{
				InteractWithTarget();
			}
		}
	}
	bool InInteractionRangeTarget(){
		bool result = false;
		if(targetObject != null){
			if(Vector2.Distance(transform.position,targetObject.transform.position) <= targetObject.GetComponent<InteractableObject>().interactionDistance){
				result = true;
			}
		}
		return result;
	}

	void InteractWithTarget(){

		movingToDestination = false;

		playerMove.Stop();

		if(targetObject != null){
			if(rigidbody2D.mass > 1000){
				targetObject.GetComponent<InteractableObject>().Interact();
				movingToDestination = false;
			}
		}
	}
}
