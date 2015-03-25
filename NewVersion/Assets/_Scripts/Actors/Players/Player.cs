﻿using UnityEngine;
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
				movingToDestination = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(playerMove.anim.GetCurrentAnimatorStateInfo(0).IsName("JumpMid")){
			playerMove.Stop();
			playerMove.anim.Play("JumpEnd");
		}
	}
	void IdleState(){
		if(rigidbody2D.mass > 500){
			playerMove.anim.Play("Idle_Star");
		}else{
			playerMove.anim.Play("Idle");
		}
	}

	void WalkingState(){
		if (rigidbody2D.mass > 500) {
			playerMove.anim.Play ("Walk_Star");
		}else{
			playerMove.anim.Play ("Walk");
		}
	}

	void JumpingState(){
		if (rigidbody2D.mass < 500) {
			playerMove.Stop();
			playerMove.anim.Play ("JumpStart");
		}
	}

	void CaughtStar(){
		IdleState ();
	}

	public void CharacterJump(){
		float dir;
		if(transform.localScale.x < 0){
			dir = -1;
		}else{
			dir = 1;
		}
		rigidbody2D.AddForce (GetComponent<RigidBodyCalculator> ().GetVectorToRotation (new Vector2(0.4f * dir,1.1f)) * 350);
	}

	public void DoInteraction(){
		targetObject.GetComponent<InteractableObject>().Interact();
	}
}
