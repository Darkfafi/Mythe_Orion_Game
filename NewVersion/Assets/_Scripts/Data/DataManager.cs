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

		SendMessage("AllDataComponentsAdded",SendMessageOptions.DontRequireReceiver); //laat weten dat alle data dingen zijn geadd.
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

	}

	void DoneSendingData(){
		Application.LoadLevel ("LevelSelectionScreen");
	}

	public PlayerProgression GetPlayerProgression(){
		return playerProgression;
	}
}
