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
			Ray2D rayCast;
			RaycastHit2D hit;

			Vector3 worldMousePosition;
			Camera currentCam;

			if(Input.mousePosition.y > Screen.height / 2){
				//cameraOne
				currentCam = cameraOne;
				Debug.Log("Player1 Cam");
			}else{
				//cameraTwo
				currentCam = cameraTwo;
				Debug.Log("Player2 Cam");
			}

			worldMousePosition = currentCam.ScreenToWorldPoint(Input.mousePosition);
			worldMousePosition.z = 0;

			hit = Physics2D.Raycast(worldMousePosition,worldMousePosition);

			//Debug.DrawRay(currentCam.transform.position,worldMousePosition - currentCam.transform.position,Color.red,5f);
			if(hit.collider != null){
				if(hit.transform.gameObject.GetComponent<TouchAbleObject>() != null){
					currentTarget = hit.transform.gameObject;
					currentTarget.GetComponent<TouchAbleObject>().StartTouchObject();
					Debug.Log(currentTarget.name);
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
