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
		//Debug.Log (transform.rotation);
		Vector3 mousePos = Input.mousePosition;

		if(transform.rotation.z == 1){
			mousePos = new Vector3(Screen.width - mousePos.x, Screen.height - mousePos.y,mousePos.z);
		}

		if(controlling){
			tiltValue = new Vector2(Mathf.Abs(mousePos.x - swipeStartPosition.x),Mathf.Abs(mousePos.y - swipeStartPosition.y));
			if(tiltValue.x > 5  || tiltValue.y > 5){ // als hij minimaal zover heeft geswiped
				if(tiltValue.x > tiltValue.y){
					if(mousePos.x < swipeStartPosition.x){
						swipeDirectionValue.x = LEFT;
					}else if(mousePos.x > swipeStartPosition.x){
						swipeDirectionValue.x = RIGHT;
					}
					moving = true;
				}else{
					if(mousePos.y < swipeStartPosition.y){
						//throw ball/ star / thingy
						Stop();
					}else if(mousePos.y > swipeStartPosition.y){
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
	}

	void StartTouch(){
		tiltValue = new Vector2(0,0);
		swipeStartPosition = Input.mousePosition;

		if(transform.rotation.z == 1){
			swipeStartPosition = new Vector2(Screen.width - swipeStartPosition.x, Screen.height - swipeStartPosition.y);
		}

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
