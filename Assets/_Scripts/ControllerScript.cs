using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	private Vector3 topStartPos; // start positie van waar je begint met besturen

	private bool controlling = false; //bepaald of je aan het "Touchen" bent. Dit kan beter met een simpele onTouch check denk ik.

	private GameObject target; //wie er word bestuurd.

	void Update(){
		/* // De multi touch code om die vraagt of touch is begonnen en of het aan het linker deel van het scherm is.
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began || touch.position.x < Screen.width / 2){
				Debug.Log("herro");
			}
		}
		*/
		if(Input.GetMouseButtonDown(0)){

			target = GetComponent<CameraFocusScript> ().GetTarger (); //checkt wie de camera volgt en diegene kan je besturen.

			if(Input.mousePosition.x < Screen.width / 2){
				// als het scherm word aangeraakt dan word de start positie opgeslagen zodat je altijd vanaf het midden het verschil kan berekenen (of je naar links of rechts gaat met je vinger etc).
				topStartPos = Input.mousePosition;
				controlling = true; 
			}
		}

		if(Input.GetMouseButtonUp(0)){
			controlling = false; // Als je het scherm los laat dan stopt hij met checken.
		}

		if(controlling){

			float tiltVal;

			tiltVal = Mathf.Abs(Input.mousePosition.x - topStartPos.x) * 0.02f; // ziet hoe ver je vanaf het beginpunt af staat in x as. *0.02f is m reële snelheid mee te geven.

			if (Input.mousePosition.x < topStartPos.x) { 
				//Left
				target.GetComponent<MovementScript>().Move(MovementScript.LEFT,tiltVal); //ieder gameobject die kan bewegen heeft het movementScript. De controller bepaald welke kant hij op beweegt en met welke snelheid.

			}else if(Input.mousePosition.x > topStartPos.x){
				//Right
				target.GetComponent<MovementScript>().Move(MovementScript.RIGHT,tiltVal);
			}
			tiltVal = Mathf.Abs(Input.mousePosition.y - topStartPos.y) * 0.02f;
			if(Input.mousePosition.y < topStartPos.y){
				//Down
				target.GetComponent<MovementScript>().Move(MovementScript.BACKWARD,tiltVal);
			}else if(Input.mousePosition.y > topStartPos.y){
				//Up
				target.GetComponent<MovementScript>().Move(MovementScript.FORWARD,tiltVal);
			}
		}
	}

	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}
}
