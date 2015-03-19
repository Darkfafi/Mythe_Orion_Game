using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Gemaakt door Ramses

public class SaveLoadData : MonoBehaviour {
	
	private BinaryFormatter binaryFormatter = new BinaryFormatter();
	private FileStream file;

	public void Save(string name, int currentLevel = 0,Dictionary<int,float> levelsCompleteWithTime = null){
		file = File.Create(Application.persistentDataPath + "/SaveData.dat");

		SaveData saveData = new SaveData();
		//via een appart script aanroepen. Waar alle informatie in staat net als vorige game playerprograssion.
		saveData.name = name;
		saveData.currentLevel = currentLevel;
		saveData.levelsCompleteWithTime = levelsCompleteWithTime;

		binaryFormatter.Serialize (file, saveData);
		file.Close();
		Debug.Log("Saved Data");
	}

	public void Load(){

		if(File.Exists(Application.persistentDataPath + "/SaveData.dat")){

			file = File.Open(Application.persistentDataPath + "/SaveData.dat",FileMode.Open);

			SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);


			file.Close();
			Debug.Log("Loaded Game");
		}
	}

	[System.Serializable]
	public class SaveData{
		public string name;
		public int currentLevel;
		public Dictionary<int,float> levelsCompleteWithTime = new Dictionary<int, float>();
	}
}
