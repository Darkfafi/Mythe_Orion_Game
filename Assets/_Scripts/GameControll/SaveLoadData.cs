using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Gemaakt door Ramses

public class SaveLoadData : MonoBehaviour {
	
	private BinaryFormatter binaryFormatter = new BinaryFormatter();
	private FileStream file;

	public void Save(){
		file = File.Create(Application.persistentDataPath + "/SaveData.dat");

		SaveData saveData = new SaveData();

		//hier alle saveData data invullen.

		binaryFormatter.Serialize (file, saveData);
		file.Close();
		Debug.Log("Saved Data");
	}

	public void Load(){

		if(File.Exists(Application.persistentDataPath + "/SaveData.dat")){

			file = File.Open(Application.persistentDataPath + "/SaveData.dat",FileMode.Open);

			SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);

			//hier alle savedData data uit de file verdelen over de game.

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
	}
}
