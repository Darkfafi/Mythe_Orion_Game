using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class CameraFocus : MonoBehaviour {

	//public GameObject controller;
	public float cameraY = 3f;
	public float cameraX = 0f;
	public float cameraZoom = 1f;

	public bool UpsideDown = false;

	public GameObject target;

	void Start(){

		transform.position = new Vector3(target.transform.position.x - cameraX,calculateY(),target.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		this.camera.orthographicSize = cameraZoom * 5;

		if(target != null){
			Vector3 dis = target.transform.position - transform.position;
			float moveSpeed = (dis.magnitude * 1f) / (camera.orthographicSize * 0.3f);



			transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.transform.position.x - cameraX,calculateY(),target.transform.position.z - 1),moveSpeed * Time.deltaTime);
		}
	}

	private float calculateY(){
		float yPos = target.transform.position.y + cameraY + camera.orthographicSize;
		
		if(UpsideDown){
			yPos = target.transform.position.y + (cameraY * -1) + (camera.orthographicSize * -1);
		}
		return yPos;
	}

	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}

	public GameObject GetTarget(){
		return target;
	}
}
