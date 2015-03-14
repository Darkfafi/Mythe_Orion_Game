using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	protected int RIGHT = 1;
	protected int LEFT = -1;

	public bool moving = false;

	public int speed = 2;

	public void Move(int dir){
		//Debug.Log ("Move " + dir);
		gameObject.transform.Translate (new Vector2 (speed * dir,0) * Time.deltaTime);
	}

	public void Stop(){
		moving = false;
		Debug.Log ("Stop");
	}

	public void Jump(){
		Debug.Log("Jump");
		//jump with vector 2 up.
	}
}