using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {

	PlayerProgression playerProgression;
	SaveLoadData saveLoadData;

	// Use this for initialization
	void Awake () {
		playerProgression = gameObject.AddComponent<PlayerProgression> ();
		saveLoadData = 	gameObject.AddComponent<SaveLoadData> ();
		saveLoadData.Load();
	}

	public void FinishLevelWithTime(int time){
		bool sendDataToDatabase = true;

		if (playerProgression.levelsCompleteWithTime.ContainsKey (playerProgression.currentPlayingLevel) == false) {
			playerProgression.levelsCompleteWithTime.Add (playerProgression.currentPlayingLevel, time);
		}else if (playerProgression.levelsCompleteWithTime[playerProgression.currentPlayingLevel] > time){ //alleen als je een betere tijd heb gehaald.
			playerProgression.levelsCompleteWithTime[playerProgression.currentPlayingLevel] = time;
		}else{
			sendDataToDatabase = false;
		}

		saveLoadData.Save ();
		if (sendDataToDatabase) {
			gameObject.AddComponent<NameLevelTimeDataSend> ().SendData ();
		}
		Application.LoadLevel ("LevelSelectionScreen");
	}
}
