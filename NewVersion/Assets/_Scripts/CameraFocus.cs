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
	
		if(UpsideDown){
			//Matrix4x4 m = Matrix4x4.TRS(gameObject.transform.position, new Quaternion(0,0,0,0), new Vector3(1, -1, 1));
			//camera.worldToCameraMatrix = m;
			//gameObject.transform.rotation = new Quaternion(0,0,180,0);
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
			float moveSpeed = dis.magnitude;
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.transform.position.x - cameraX,target.transform.position.y + cameraY,target.transform.position.z - cameraZoom),moveSpeed / 2.5f * Time.deltaTime);
		}
	}
	public void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}

	public GameObject GetTarget(){
		return target;
	}
}
