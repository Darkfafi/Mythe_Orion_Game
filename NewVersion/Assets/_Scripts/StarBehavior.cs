using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float speed = 5;

	void Update(){
		transform.Translate (-Vector2.up * Time.deltaTime * speed);
		if (transform.position.y > 15) {
			transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
		}
		else if (transform.position.y < -15) {
			transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
		}
	}
}