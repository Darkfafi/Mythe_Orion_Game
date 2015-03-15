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
		transform.Translate (Vector3.down * Time.deltaTime * speed);
	}
}