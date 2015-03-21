using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Gemaakt door Ramses

public class SaveLoadData : MonoBehaviour {

	
	private PlayerProgression playerProgression;

	private BinaryFormatter binaryFormatter = new BinaryFormatter();
	private FileStream file;

	void Awake(){
		playerProgression = GetComponent<PlayerProgression> ();
	}

	public void Save(){
		file = File.Create(Application.persistentDataPath + "/SaveData.dat");

		SaveData saveData = new SaveData();
		//via een appart script aanroepen. Waar alle informatie in staat net als vorige game playerprograssion

		saveData.name = playerProgression.nameUser;
		saveData.currentLevel = playerProgression.currentLevel;
		saveData.levelsCompleteWithTime = playerProgression.levelsCompleteWithTime;
		saveData.currentPlayingLevel = playerProgression.currentPlayingLevel;

		binaryFormatter.Serialize (file, saveData);
		file.Close();
		Debug.Log("Saved Data");
	}

	public void Load(){

		if(File.Exists(Application.persistentDataPath + "/SaveData.dat")){

			file = File.Open(Application.persistentDataPath + "/SaveData.dat",FileMode.Open);

			SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);
			playerProgression.nameUser = savedData.name;
			playerProgression.currentLevel = savedData.currentLevel;
			playerProgression.levelsCompleteWithTime = savedData.levelsCompleteWithTime;
			playerProgression.currentPlayingLevel = savedData.currentPlayingLevel;

			file.Close();
			Debug.Log("Loaded Game");
		}
	}

	[System.Serializable]
	public class SaveData{
		public string name;
		public int currentLevel;
		public Dictionary<int,int> levelsCompleteWithTime = new Dictionary<int, int>();
		public int currentPlayingLevel;
	}
}
