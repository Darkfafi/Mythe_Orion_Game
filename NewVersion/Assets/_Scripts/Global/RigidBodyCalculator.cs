using UnityEngine;
using System.Collections;

public class RigidBodyCalculator : MonoBehaviour {

	public bool rotationToGravity = true;

	//private Rigidbody2D rigidbody;

	// Use this for initialization
	void Awake () {
		gameObject.AddComponent<Rigidbody2D> ();
		if(rotationToGravity){
			CheckRotationForGravity();
		}
	}

	public void CheckRotationForGravity(){
		//Debug.Log (gameObject.transform.rotation);
		if(Mathf.Abs(gameObject.transform.rotation.z) == 1){
			if(rigidbody2D.gravityScale == Mathf.Abs(rigidbody2D.gravityScale)){
				rigidbody2D.gravityScale = -rigidbody2D.gravityScale; //maakt het negatief (valt naar boven).
			}
		}else if(rigidbody2D.gravityScale != Mathf.Abs(rigidbody2D.gravityScale)){
			rigidbody2D.gravityScale = -rigidbody2D.gravityScale; //maakt het positief (valt naar beneden).
		}
	}

	public Vector2 GetVectorToRotation(Vector2 vectorDirection){
		if(transform.rotation.z == 1){
			vectorDirection = -vectorDirection;
		}
		return vectorDirection;
	}
}
