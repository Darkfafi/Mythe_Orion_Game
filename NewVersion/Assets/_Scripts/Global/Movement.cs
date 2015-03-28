using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	protected int RIGHT = 1;
	protected int LEFT = -1;
	
	public bool moving = false;

	public int currentDir;
	private float scaleX;
	public float speed;

	public Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
		scaleX = transform.localScale.x;
	}

	public void Move(int dir,float moveSpeed = 0){
		//Debug.Log ("Move " + dir);
		//sendmassage(playanim,typeAsPara)
		if(moveSpeed == 0){
			moveSpeed = speed;
		}
		if(currentDir != dir){
			int calcDir = dir;
			//anim.Play("Walk");
			SendMessage("WalkingState");
			if(transform.rotation.z > 0.8 && transform.rotation.x < 1.2){
				calcDir = -dir;
			}

			transform.localScale = new Vector3(scaleX * calcDir,transform.localScale.y,transform.localScale.z);
		}
		gameObject.transform.Translate (new Vector2 (moveSpeed * dir,0) * Time.deltaTime);
		currentDir = dir;
	}

	public virtual void Stop(){
		moving = false;
		//anim.Play("Idle");
		SendMessage("IdleState");
		currentDir = 0;
//		Debug.Log ("Stop");
	}

	public void Jump(){
		//Debug.Log("Jump");
		SendMessage("JumpingState");
	}
}