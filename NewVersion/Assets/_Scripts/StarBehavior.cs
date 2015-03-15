using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float speed = 5;
	public bool goDown;

	void Start () {
		if (transform.position.y >= 0) {
			goDown = true;
		}
		else {
			goDown = false;
		}
	}

	void Update(){
		transform.Translate (-Vector2.up * Time.deltaTime * speed);
		if (transform.position.y > 15) {
			transform.position = new Vector3(transform.position.x, -transform.position.y, 0.01f);
		}
		else if (transform.position.y < -15) {
			transform.position = new Vector3(transform.position.x, -transform.position.y, 0.01f);
		}
	}
}