using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float maxSpeed = float.MaxValue;

	public static Vector3 LEFT = new Vector3(-1,0,0);
	public static Vector3 RIGHT = new Vector3(1,0,0);
	public static Vector3 FORWARD = new Vector3(0,0,1);
	public static Vector3 BACKWARD = new Vector3(0,0,-1);

	public void Move(Vector3 direction,float speed){
		if (speed > maxSpeed) {
			speed = maxSpeed;
		}
		transform.Translate((direction * speed) * Time.deltaTime);
	}
}
