using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRayChooser : MonoBehaviour {

	public Camera cameraOne;
	public Camera cameraTwo;
	
	private GameObject currentTarget;
	// Update is called once per frame
	void Update () {	
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit;

			Vector3 worldMousePosition;
			Camera currentCam;

			if(Input.mousePosition.y > Screen.height / 2){
				//cameraOne
				currentCam = cameraOne;
				//Debug.Log("Player1 Camera");
			}else{
				//cameraTwo
				currentCam = cameraTwo;
				//Debug.Log("Player2 Camera");
			}

			worldMousePosition = currentCam.ScreenToWorldPoint(Input.mousePosition);
			worldMousePosition.z = 0;

			hit = Physics2D.Raycast(worldMousePosition,worldMousePosition);

			//Debug.DrawRay(currentCam.transform.position,worldMousePosition - currentCam.transform.position,Color.red,5f);
			if(hit.collider != null){
				if(hit.transform.gameObject.GetComponent<TouchAbleObject>() != null){
					currentTarget = hit.transform.gameObject;
					currentTarget.GetComponent<TouchAbleObject>().StartTouchObject();
					//Debug.Log(currentTarget.name);
					//if not player. Then send to camera player what object clicked if interactable with player
				}else if(hit.transform.gameObject.GetComponent<InteractableObject>() != null){
					//maak player script daarmee check je mass en interact je met object. Player script maakt ook de playermovement aan.
					currentCam.GetComponent<CameraFocus>().target.GetComponent<Player>().interactWithObject(hit.transform.gameObject); 
				}
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			if(currentTarget != null){
				currentTarget.GetComponent<TouchAbleObject>().StopTouchObject();
				currentTarget = null;
			}
		}
	}
}
