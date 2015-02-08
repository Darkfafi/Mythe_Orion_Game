using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public static Vector3 LEFT = new Vector3(-1,0,0);
	public static Vector3 RIGHT = new Vector3(1,0,0);
	public static Vector3 FORWARD = new Vector3(0,0,1);
	public static Vector3 BACKWARD = new Vector3(0,0,-1);

	public void Move(Vector3 direction,float speed){
		transform.Translate((direction * speed) * Time.deltaTime);
	}
}
