using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class GameController : MonoBehaviour {

	public bool destroyIfExists = true; // bij menu deze op false zetten

	SaveLoadData saveLoad;
	PlayerProgression playerProgression;
	DataScoreTransfer dataScoreTransfer;

	void Awake(){
		//add alles wat met game controll heeft te maken.
		if(destroyIfExists){
			destroyIfExists = false;
			if(GameObject.FindGameObjectsWithTag("GameController").Length > 1){
				Destroy(gameObject);
			}
		}else{
			DontDestroyOnLoad (gameObject);
		}

		saveLoad = gameObject.AddComponent<SaveLoadData> ();
		playerProgression = gameObject.AddComponent<PlayerProgression>();
		dataScoreTransfer = gameObject.AddComponent<DataScoreTransfer> ();
	}
}
