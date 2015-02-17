using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class CameraFocus : MonoBehaviour {

	//public GameObject controller;
	public float cameraHeight = 7;
	public float cameraDistanse = 3.5f;

	private static GameObject _target;
	
	// Update is called once per frame
	void Update () {
		if(_target != null){
			Vector3 dis = _target.transform.position - transform.position;
			float moveSpeed = dis.magnitude;
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(_target.transform.position.x,_target.transform.position.y + cameraHeight,_target.transform.position.z - cameraDistanse),moveSpeed / 2.5f * Time.deltaTime);
		}
	}
	public static void SetTarget(GameObject givenTarget){
		_target = givenTarget;
	}

	public GameObject GetTarger(){
		return _target;
	}
}
