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
			if(GameObject.FindGameObjectsWithTag("GameController").Length > 1){
				Destroy(gameObject);
			}else{
				destroyIfExists = false;
			}
		}else{
			DontDestroyOnLoad (gameObject);
		}

		saveLoad = gameObject.AddComponent<SaveLoadData> ();
		playerProgression = gameObject.AddComponent<PlayerProgression>();
		dataScoreTransfer = gameObject.AddComponent<DataScoreTransfer> ();

		//save data when scene loaded.
	}
}
