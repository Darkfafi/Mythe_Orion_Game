using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class PlayerMovement : Movement {

	public Vector2 swipeStartPosition;
	private Vector2 swipeDirectionValue = new Vector2 ();

	private bool controlling = false;
	private Vector2 tiltValue;

	//als het word opgetilt en er geen tilt was dan stop. anders doe tilt opdracht (zoals springen etc)

	void Update () {

		if(Input.GetMouseButtonDown(0)){
			tiltValue = new Vector2(0,0);/*
			swipeStartPosition = Input.mousePosition;
			controlling = true;*/
		}

		if(controlling){
			tiltValue = new Vector2(Mathf.Abs(Input.mousePosition.x - swipeStartPosition.x),Mathf.Abs(Input.mousePosition.y - swipeStartPosition.y));
			if(tiltValue.x > 5  || tiltValue.y > 5){ // als hij minimaal zover heeft geswiped
				if(tiltValue.x > tiltValue.y){
					if(Input.mousePosition.x < swipeStartPosition.x){
						swipeDirectionValue.x = LEFT;
					}else if(Input.mousePosition.x > swipeStartPosition.x){
						swipeDirectionValue.x = RIGHT;
					}
					moving = true;
				}else{
					if(Input.mousePosition.y < swipeStartPosition.y){
						//throw ball/ star / thingy
					}else if(Input.mousePosition.y > swipeStartPosition.y){
						Jump();
					}
				}
				controlling = false;
			}
		}

		if(moving){
			if (swipeDirectionValue.x < 0){
				Move(LEFT);
			}else if (swipeDirectionValue.x > 0){
				Move(RIGHT);
			}
		}

		if(Input.GetMouseButtonUp(0)){
			/*
			if(tiltValue.x < 1 && tiltValue.y < 1){
				Stop();
				controlling = false;
				swipeDirectionValue = new Vector2();
			}*/
		}
	}

	void StartTouch(){
		tiltValue = new Vector2(0,0);
		swipeStartPosition = Input.mousePosition;
		controlling = true;
	}

	void StopTouch(){
		if(tiltValue.x < 1 && tiltValue.y < 1){
			Stop();
			controlling = false;
			swipeDirectionValue = new Vector2();
		}
	}
}
