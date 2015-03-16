using UnityEngine;
using System.Collections;

public class PassAbleBlock : TouchAbleObject {

	bool passing = false;
	public float massObject = 10000;

	// Use this for initialization
	void Awake () {
		gameObject.AddComponent<RigidBodyCalculator> ();
	}

	void Start(){
		rigidbody2D.fixedAngle = true;
		rigidbody2D.mass = massObject;
	}

	void OnTriggerExit2D(Collider2D other){
		if(passing){
			if(other.gameObject.tag == "Ground"){ //als het door de grond is gegaan
				passing = false; //dan zet boolean uit die bijhield dat hij door de grond ging.
				collider2D.isTrigger = false; //de trigger word een collider zodat het niet meer door dingen gaat.
				if(transform.rotation.z > 0.8 && transform.rotation.z < 1.2){ //als de rotatie 180 was dan ga naar 0
					transform.rotation = new Quaternion(0,0,0,0);
				}else{
					transform.rotation = new Quaternion(0,0,180,0); // anders naar 180
				}
				GetComponent<RigidBodyCalculator>().CheckRotationForGravity(); //dan calculeer wat je zwaartekracht moet zijn
				rigidbody2D.AddForce(GetComponent<RigidBodyCalculator>().GetVectorToRotation(-Vector2.up) * ((400 * rigidbody2D.mass) * gameObject.transform.localScale.y)); //en duw jezelf naar de grond zodat je niet een boog makt voor je de grond raakt
			}
		}
	}

	void StartTouch(){
		if(!passing){
			passing = true;
			collider2D.isTrigger = true;
		}
	}

	void StopTouch(){

	}
}
