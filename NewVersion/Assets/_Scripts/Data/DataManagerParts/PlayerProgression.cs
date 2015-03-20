using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProgression : MonoBehaviour {

	public string nameUser;
	public int currentLevel;
	public Dictionary<int,int> levelsCompleteWithTime = new Dictionary<int, int>();

	public int GetLevelTime(int levelIndex){
		int result = 0;
		if (levelsCompleteWithTime.ContainsKey(levelIndex)) {
			result = levelsCompleteWithTime [levelIndex];
		}
		return result;
	}
}
