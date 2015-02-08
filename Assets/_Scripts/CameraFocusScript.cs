using UnityEngine;
using System.Collections;

public class CameraFocusScript : MonoBehaviour {

	private static GameObject target;
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			Vector3 dis = target.transform.position - transform.position;
			float moveSpeed = dis.magnitude;
			Debug.Log(moveSpeed / 1.7f);
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.transform.position.x,target.transform.position.y + 7,target.transform.position.z - 5),moveSpeed / 1.7f * Time.deltaTime);
		}
	}
	public static void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}
}
