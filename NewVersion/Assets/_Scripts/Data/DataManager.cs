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
		if (playerProgression.levelsCompleteWithTime.ContainsKey (playerProgression.currentPlayingLevel) == false) {
			playerProgression.levelsCompleteWithTime.Add (playerProgression.currentPlayingLevel, time);
		}else{
			playerProgression.levelsCompleteWithTime[playerProgression.currentPlayingLevel] = time;
		}
		saveLoadData.Save ();
		gameObject.AddComponent<NameLevelTimeDataSend> ().SendData ();
		Application.LoadLevel ("LevelSelectionScreen");
	}
}
