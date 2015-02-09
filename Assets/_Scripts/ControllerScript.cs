using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	private Vector3 topStartPos; // start positie van waar je begint met besturen

	private bool controllingLeft = false; //bepaald of je aan het "Touchen" bent. op de linker kant
	private bool controllingRight = false; // bepaald of je aan het "Touchen" bent. op de rechter kant
	private GameObject target; //wie er word bestuurd.

	private int leftTouch = -1; //welke touch de movement bestuurt
	private int rightTouch = -1; // welke touch de ... bestuurt

	void Update(){
		for (var i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began) {
				if (touch.position.x < Screen.width/2 && leftTouch == -1) {
					target = GetComponent<CameraFocusScript> ().GetTarger ();
					topStartPos = Input.GetTouch(i).position;
					controllingLeft = true;
					leftTouch = i;
					print("touch");
				}
				else if (rightTouch == -1) {
					//TODO rechter kant scherm
				}
			}
			else if (touch.phase == TouchPhase.Ended){
				print("touch ended");
				if(i == leftTouch){
					leftTouch = -1;
					controllingLeft = false;
				}
				else if (i < leftTouch){
					leftTouch --;
				}
				print(leftTouch);
			}
		}
		if(controllingLeft){

			float tiltVal;
			tiltVal = Mathf.Abs(Input.GetTouch(leftTouch).position.x - topStartPos.x) * 0.02f; // ziet hoe ver je vanaf het beginpunt af staat in x as. *0.02f is m reële snelheid mee te geven.

			if (Input.GetTouch(leftTouch).position.x < topStartPos.x) { 
				//Left
				target.GetComponent<MovementScript>().Move(MovementScript.LEFT,tiltVal); //ieder gameobject die kan bewegen heeft het movementScript. De controller bepaald welke kant hij op beweegt en met welke snelheid.

			}else if(Input.GetTouch(leftTouch).position.x > topStartPos.x){
				//Right
				target.GetComponent<MovementScript>().Move(MovementScript.RIGHT,tiltVal);
			}
			tiltVal = Mathf.Abs(Input.GetTouch(leftTouch).position.y - topStartPos.y) * 0.02f;
			if(Input.mousePosition.y < topStartPos.y){
				//Down
				target.GetComponent<MovementScript>().Move(MovementScript.BACKWARD,tiltVal);
			}else if(Input.GetTouch(leftTouch).position.y > topStartPos.y){
				//Up
				target.GetComponent<MovementScript>().Move(MovementScript.FORWARD,tiltVal);
			}
		}
	}

	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}
}
