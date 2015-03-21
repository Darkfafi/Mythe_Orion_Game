using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProgression : MonoBehaviour {

	public string nameUser = "Ramses"; //De speler zijn Username
	public int currentLevel = 0; //Hoe ver de speler is in het spel.

	public int currentPlayingLevel = 0; //het level die hij op dit moment speeld

	public Dictionary<int,int> levelsCompleteWithTime = new Dictionary<int, int>(); //lijst van level/time data

	public int GetLevelTime(int levelIndex){
		int result = 0;
		if (levelsCompleteWithTime.ContainsKey(levelIndex)) {
			result = levelsCompleteWithTime [levelIndex];
		}
		return result;
	}
}
