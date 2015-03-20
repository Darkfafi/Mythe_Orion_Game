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
}
