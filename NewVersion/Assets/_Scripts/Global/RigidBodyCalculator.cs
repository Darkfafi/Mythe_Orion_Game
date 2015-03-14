using UnityEngine;
using System.Collections;

public class RigidBodyCalculator : MonoBehaviour {

	public bool rotationToGravity = true;

	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.AddComponent<Rigidbody2D> ();
		if(rotationToGravity){
			CheckRotationForGravity();
		}
	}

	public void CheckRotationForGravity(){
		Debug.Log (gameObject.transform.rotation);
		if(Mathf.Abs(gameObject.transform.rotation.z) == 1){
			if(rigidbody.gravityScale == Mathf.Abs(rigidbody.gravityScale)){
				rigidbody.gravityScale = -rigidbody.gravityScale; //maakt het negatief (valt naar boven).
			}
		}else if(rigidbody.gravityScale != Mathf.Abs(rigidbody.gravityScale)){
			rigidbody.gravityScale = -rigidbody.gravityScale; //maakt het positief (valt naar beneden).
		}
	}
}
