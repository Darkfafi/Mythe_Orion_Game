using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Gemaakt door Ramses

public class SaveLoadData : MonoBehaviour {
	
	private BinaryFormatter binaryFormatter = new BinaryFormatter();
	private FileStream file;

	public void Save(){
		file = File.Create(Application.persistentDataPath + "/SaveData.dat");

		SaveData saveData = new SaveData();

		Dictionary<string,int> playerProgressionList = GetComponent<PlayerProgression> ().GetPlayerProgressionList();

		saveData.currentLevel = playerProgressionList[PlayerProgression.CURRENT_LEVEL];
		saveData.newGamePlussed = playerProgressionList[PlayerProgression.NEW_GAME_PLUSSED];
		saveData.timesDied = playerProgressionList[PlayerProgression.TIMES_DIED];
		saveData.goodPoints = playerProgressionList[PlayerProgression.GOOD_POINTS];
		saveData.evilPoints = playerProgressionList[PlayerProgression.EVIL_POINTS];
		saveData.score = playerProgressionList[PlayerProgression.SCORE];

		binaryFormatter.Serialize (file, saveData);
		file.Close();
		Debug.Log("Saved Data");
	}

	public void Load(){

		if(File.Exists(Application.persistentDataPath + "/SaveData.dat")){

			file = File.Open(Application.persistentDataPath + "/SaveData.dat",FileMode.Open);

			SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);

			GetComponent<PlayerProgression>().SetPlayerProgression(savedData.GetPlayerDataList());

			file.Close();
			Debug.Log("Loaded Game");
		}
	}

	[System.Serializable]
	public class SaveData{
		public int currentLevel; //welk level je momenteel bent
		public int newGamePlussed; //hoe vaak new game plus is gedaan
		public int timesDied;//hoe vaak je character is dood gegaan.
		public int goodPoints; //Je Good points die je door je keuzes vult
		public int evilPoints; //Je Evil Points die je door je keuzes vult.
		public int score; //je score;
		public int goodOrEvilRoom; //1 == good room en 0 == evil room (net een boolean)

		public Dictionary<string,int> GetPlayerDataList(){
			Dictionary<string,int> saveDataList = new Dictionary<string, int>();
			saveDataList.Add (PlayerProgression.CURRENT_LEVEL, currentLevel);
			saveDataList.Add (PlayerProgression.NEW_GAME_PLUSSED, newGamePlussed);
			saveDataList.Add (PlayerProgression.TIMES_DIED, timesDied);
			saveDataList.Add (PlayerProgression.GOOD_POINTS, goodPoints);
			saveDataList.Add (PlayerProgression.EVIL_POINTS, evilPoints);
			saveDataList.Add (PlayerProgression.SCORE, score);
			return saveDataList;
		}
	}
}
