using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	PlayerMovement playerMove;
	GameObject targetObject;

	private bool movingToDestination = false;

	void Awake () {
		playerMove = gameObject.AddComponent<PlayerMovement> ();
		gameObject.AddComponent<TouchAbleObject> ();
		gameObject.AddComponent<RigidBodyCalculator> ();
		rigidbody2D.fixedAngle = true;

		playerMove.speed = 2f;
	}

	public void interactWithObject(GameObject interactionObject){
		targetObject = interactionObject;
		InteractableObject interactSection = interactionObject.GetComponent<InteractableObject> ();

		if(InInteractionRangeTarget()){
			playerMove.Move(directionToTarget());
			InteractWithTarget();
		}else{
			if(movingToDestination == false){
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
					direction = directionToTarget();
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

	int directionToTarget(){
		int result = 0;
		if (targetObject != null) {
			if(targetObject.transform.position.x  - gameObject.transform.position.x < 0){
				result = -1;
			}else{
				result = 1;
			}

			if(gameObject.transform.rotation.z > 0.8f && gameObject.transform.rotation.z < 1.2f){
				result *= -1;
			}

		}
		return result;
	}

	void InteractWithTarget(){

		movingToDestination = false;

		playerMove.Stop();

		if(targetObject != null){
			if(rigidbody2D.mass > 1000){
				playerMove.anim.Play("Interact");
				targetObject.GetComponent<InteractableObject>().Interact();
				movingToDestination = false;
			}
		}
	}
}
