using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	protected int RIGHT = 1;
	protected int LEFT = -1;

	public int speed = 1;

	public void Move(int dir){
		Debug.Log ("Move " + dir);
	}

	public void Stop(){
		Debug.Log ("Stop");
	}

	public void Jump(){
		Debug.Log("Jump");

		//jump with vector 2 up.
	}
}