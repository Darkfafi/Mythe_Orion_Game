using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	private Vector3 topStartPos; // start positie van waar je begint met besturen

	private bool controlling = false; //bepaald of je aan het "Touchen" bent. Dit kan beter met een simpele onTouch check denk ik.

	private GameObject target; //wie er word bestuurd.

	void Update(){

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
			Vector3 moveDir = new Vector3();
			float tilt = 0;

			tiltVal = Mathf.Abs(Input.mousePosition.x - topStartPos.x) * 0.03f; // ziet hoe ver je vanaf het beginpunt af staat in x as. *0.02f is m reële snelheid mee te geven.

			tilt += tiltVal; //berekend de snelheid waarin de character moet lopen aan de hand van de tilt

			if (Input.mousePosition.x < topStartPos.x) { 
				//Left
				moveDir = moveDir - Vector3.right * tiltVal;

			}else if(Input.mousePosition.x > topStartPos.x){
				//Right
				moveDir = moveDir + Vector3.right * tiltVal;
			}
			tiltVal = Mathf.Abs(Input.mousePosition.y - topStartPos.y) * 0.03f;
			tilt += tiltVal;
			if(Input.mousePosition.y < topStartPos.y){
				//Down
				moveDir = moveDir - Vector3.forward * tiltVal;
			}else if(Input.mousePosition.y > topStartPos.y){
				//Up
				moveDir = moveDir + Vector3.forward * tiltVal;
			}
			target.GetComponent<MovementScript>().MoveTransRotation(moveDir,tilt);
		}
	}

	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}
}
