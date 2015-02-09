using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float maxSpeed = float.MaxValue;
	
	public void Move(Vector3 direction,float speed){
		Vector3 realMove;
		realMove = direction;
		realMove.Normalize();
		if (speed > maxSpeed) {
			speed = maxSpeed;
		}
		transform.Translate((realMove * speed) * Time.deltaTime);
	}
	public void MoveTransRotation(Vector3 direction,float speed){

		transform.eulerAngles = new Vector3 (0, 0, 0);
		Vector2 dir = new Vector2 (direction.x, direction.z);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Debug.Log (angle);
		transform.eulerAngles = new Vector3(transform.rotation.x,angle * -1,transform.rotation.z);
		Move(Vector3.forward, speed);
	}
}
