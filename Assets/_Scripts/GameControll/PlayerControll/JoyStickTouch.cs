using UnityEngine;
using System.Collections;

//Gemaakt door Nick

public class JoyStickTouch : MonoBehaviour {

	private Vector3 topStartPos; // start positie van waar je begint met besturen

	private bool controllingLeft = false; //bepaald of je aan het "Touchen" bent. op de linker kant
//	private bool controllingRight = false; // bepaald of je aan het "Touchen" bent. op de rechter kant
	private GameObject target; //wie er word bestuurd.

	private int leftTouch = -1; //welke touch de movement bestuurt
	private int rightTouch = -1; // welke touch de ... bestuurt

	void Update(){

		Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		bool canMove = true;

		for (var i = 0; i < Input.touchCount; ++i) {
			if(Physics.Raycast(rayCast,out hit)){
				if(hit.transform.tag == "Enemy"){
					canMove = false;
					target.GetComponent<Creature>().NewTarget(hit.transform.gameObject);
				}
			}
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && canMove == true) {
				if (touch.position.x < Screen.width/2 && leftTouch == -1) {
					target = GetComponent<CameraFocus> ().GetTarget ();
					topStartPos = Input.GetTouch(i).position;
					controllingLeft = true;
					leftTouch = i;
					//print("touch");
				}
				else if (rightTouch == -1) {
					//TODO rechter kant scherm
				}
			}
			else if (touch.phase == TouchPhase.Ended){
				//print("touch ended");
				if(i == leftTouch){
					leftTouch = -1;
					controllingLeft = false;
					target.GetComponent<Movement>().StopMoving();
				}
				else if (i < leftTouch){
					leftTouch --;
				}
				//print(leftTouch);
			}
		}
		if(controllingLeft){

			float tiltVal;
			Vector3 moveDir = new Vector3();
			float tilt = 0;

			tiltVal = Mathf.Abs(Input.GetTouch(leftTouch).position.x - topStartPos.x) * 0.03f; // ziet hoe ver je vanaf het beginpunt af staat in x as. *0.02f is m reële snelheid mee te geven.
			tilt += tiltVal;
			if (Input.GetTouch(leftTouch).position.x < topStartPos.x) { 
				//Left
				moveDir = moveDir - Vector3.right * tiltVal;

			}else if(Input.GetTouch(leftTouch).position.x > topStartPos.x){
				//Right
				moveDir = moveDir + Vector3.right * tiltVal;
			}

			tiltVal = Mathf.Abs(Input.GetTouch(leftTouch).position.y - topStartPos.y) * 0.03f;
			tilt += tiltVal;
			if(Input.GetTouch(leftTouch).position.y < topStartPos.y){
				//Down
				moveDir = moveDir - Vector3.forward * tiltVal;
			}else if(Input.GetTouch(leftTouch).position.y > topStartPos.y){
				//Up
				moveDir = moveDir + Vector3.forward * tiltVal;
			}
			target.GetComponent<Movement>().MoveTransRotation(moveDir,tilt);
		}
	}

	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}
}
