﻿using UnityEngine;
using System.Collections;

public class SinkFloor : MonoBehaviour {

	bool sink = false;

	public int sinkDepth = 2;
	public float sinkSpeed = 0.2f;
	public bool destroyOnCompleteSink = true; 

	Vector3 startPos;

	void Start(){
		startPos = transform.position;
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			sink = true;
		}
	}

	void Update(){
		if(sink){
			if(transform.position.y >= startPos.y - sinkDepth){
				transform.Translate(new Vector3(0,-sinkSpeed,0) * Time.deltaTime);
			}else{
				if(destroyOnCompleteSink){
					Destroy(gameObject);
				}
			}
		}
	}
}
