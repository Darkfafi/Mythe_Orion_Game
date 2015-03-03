using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class Mission : MonoBehaviour {

	private bool _checkMission = false; 

	// Use this for initialization
	public virtual void StartMission () {
		_checkMission = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(_checkMission){
			CheckMission();
		}
	}


	protected virtual void CheckMission(){

	}
}
