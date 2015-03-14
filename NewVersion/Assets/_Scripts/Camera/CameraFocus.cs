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

		
		transform.position = new Vector3(target.transform.position.x - cameraX,target.transform.position.y + cameraY,target.transform.position.z - cameraZoom);

		if(UpsideDown){
			Matrix4x4 mat = Camera.main.projectionMatrix;
			mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
			camera.projectionMatrix = mat;
			transform.Rotate(new Vector3(0,0,180));
		}
	}

	// Update is called once per frame
	void Update () {
		if(target != null){
			Vector3 dis = target.transform.position - transform.position;
			float moveSpeed = dis.magnitude * 0.85f;

			transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.transform.position.x - cameraX,target.transform.position.y + cameraY,target.transform.position.z - cameraZoom),moveSpeed * Time.deltaTime);
		}
	}
	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}

	public GameObject GetTarget(){
		return target;
	}
}
