using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float speed = 5;

	void Update(){
		transform.Translate (-Vector2.up * Time.deltaTime * speed);
		if (transform.position.y > 16) {
			transform.position = new Vector3(transform.position.x, -(transform.position.y - 1), transform.position.z);
		}
		else if (transform.position.y < -16) {
			transform.position = new Vector3(transform.position.x, -(transform.position.y + 1), transform.position.z);
		}
	}
}