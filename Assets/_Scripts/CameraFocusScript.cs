using UnityEngine;
using System.Collections;

public class CameraFocusScript : MonoBehaviour {

	private static GameObject target;
	
	// Update is called once per frame
	void Update () {
		Debug.Log (target);
		if(target != null){
			transform.position = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z - 5);
		}
	}

	public static void SetTarget(GameObject givenTarget){
		target = givenTarget;
	}
}
