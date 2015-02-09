using UnityEngine;
using System.Collections;

public class CameraFocusScript : MonoBehaviour {

	//public GameObject controller;

	private static GameObject target;
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			Vector3 dis = target.transform.position - transform.position;
			float moveSpeed = dis.magnitude;
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.transform.position.x,target.transform.position.y + 7,target.transform.position.z - 5),moveSpeed / 3.5f * Time.deltaTime);
		}
	}
	public static void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}

	public GameObject GetTarger(){
		return target;
	}
}
