using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class GameController : MonoBehaviour {

	SaveLoadData saveLoad;

	void Awake(){
		//add alles wat met game controll heeft te maken.
		saveLoad = gameObject.AddComponent<SaveLoadData> ();
	}
}
