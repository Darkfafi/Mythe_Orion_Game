using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Gemaakt Door Ramses

public class KeyHold : MonoBehaviour {

	public List<int> keyIdList = new List<int>(); //is een lijst met all je key id's. De lengte is hoeveel keys je heb.

	public void AddKey(int keyId){
		keyIdList.Add (keyId);
	}

	public bool CheckKey(int keyId){

		return keyIdList.Contains (keyId);
	}

	public void RemoveKey(int keyId){
		if(CheckKey(keyId)){
			keyIdList.Remove(keyId);
		}
	}
}
