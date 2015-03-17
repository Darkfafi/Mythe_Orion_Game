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
		int currentLevel;
		Dictionary<int,float> levelsCompleteWithTime = new Dictionary<int, float>();
	}
}
