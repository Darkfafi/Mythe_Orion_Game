using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	protected int RIGHT = 1;
	protected int LEFT = -1;
	
	public bool moving = false;

	public int currentDir;
	private float scaleX;
	public float speed;

	Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
		scaleX = transform.localScale.x;
	}

	public void Move(int dir){
		//Debug.Log ("Move " + dir);
		//sendmassage(playanim,typeAsPara)
		if(currentDir != dir){
			int calcDir = dir;
			anim.Play("Walk");
			if(transform.rotation.z > 0.8 && transform.rotation.x < 1.2){
				calcDir = -dir;
			}

			transform.localScale = new Vector3(scaleX * calcDir,transform.localScale.y,transform.localScale.z);
		}
		gameObject.transform.Translate (new Vector2 (speed * dir,0) * Time.deltaTime);
		currentDir = dir;
	}

	public void Stop(){
		moving = false;
		anim.Play("Idle");
		currentDir = 0;
		Debug.Log ("Stop");
	}

	public void Jump(){
		Debug.Log("Jump");
		rigidbody2D.AddForce (GetComponent<RigidBodyCalculator> ().GetVectorToRotation (Vector2.up) * 300);
	}
}