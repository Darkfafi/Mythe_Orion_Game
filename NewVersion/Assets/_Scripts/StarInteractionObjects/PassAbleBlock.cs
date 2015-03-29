using UnityEngine;
using System.Collections;

public class PassAbleBlock : InteractableObject {

	bool passing = false;
	public float massObject = 1000000;
	private SoundController soundController;

	// Use this for initialization
	void Awake () {
		gameObject.AddComponent<RigidBodyCalculator> ();
	}

	void Start(){
		soundController = GetComponent<SoundController> ();
		rigidbody2D.fixedAngle = true;
		rigidbody2D.mass = massObject;
	}

	void OnTriggerExit2D(Collider2D other){
		if(passing){
			if(other.gameObject.tag == "Ground"){ //als het door de grond is gegaan
				passing = false; //dan zet boolean uit die bijhield dat hij door de grond ging.
				collider2D.isTrigger = false; //de trigger word een collider zodat het niet meer door dingen gaat.
				//Debug.Log(transform.eulerAngles.z);
				if(transform.eulerAngles.z > 90 && transform.rotation.z < 270){ //als de rotatie 180 was dan ga naar 0
					transform.rotation = new Quaternion(0,0,0,0);
				}else{
					transform.rotation = new Quaternion(0,0,180,0); // anders naar 180
				}
				GetComponent<RigidBodyCalculator>().CheckRotationForGravity(); //dan calculeer wat je zwaartekracht moet zijn
				rigidbody2D.AddForce(GetComponent<RigidBodyCalculator>().GetVectorToRotation(-Vector2.up) * ((400 * rigidbody2D.mass) * gameObject.transform.localScale.y)); //en duw jezelf naar de grond zodat je niet een boog makt voor je de grond raakt
			}
		}
	}

	public override void Interact ()
	{
		base.Interact ();
		if(!passing){
			passing = true;
			collider2D.isTrigger = true;
			soundController.PlaySound(0, false);
		}
	}
}
