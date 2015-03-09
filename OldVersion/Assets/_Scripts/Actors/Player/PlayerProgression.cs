using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Gemaakt Door Ramses

public class PlayerProgression : MonoBehaviour {

	public const string CURRENT_LEVEL = "CurrentLevel";
	public const string NEW_GAME_PLUSSED = "NewGamePlussed";
	public const string TIMES_DIED = "TimesDied";
	public const string GOOD_POINTS = "GoodPoints";
	public const string EVIL_POINTS = "EvilPoints";
	public const string SCORE = "Score";

	public int currentLevel = 0; //welk level je momenteel bent
	public int newGamePlussed = 0; //hoe vaak new game plus is gedaan
	public int timesDied = 0;//hoe vaak je character is dood gegaan.
	public int goodPoints = 0; //Je Good points die je door je keuzes vult
	public int evilPoints = 0;//Je Evil Points die je door je keuzes vult.
	public int score = 0; //je score;


	public Dictionary<string,int> GetPlayerProgressionList(){
		Dictionary<string,int> playerProgressionList = new Dictionary<string, int>();
		playerProgressionList.Add (CURRENT_LEVEL, currentLevel);
		playerProgressionList.Add (NEW_GAME_PLUSSED, newGamePlussed);
		playerProgressionList.Add (TIMES_DIED, timesDied);
		playerProgressionList.Add (GOOD_POINTS, goodPoints);
		playerProgressionList.Add (EVIL_POINTS, evilPoints);
		playerProgressionList.Add (SCORE, score);
		return playerProgressionList;
	}

	public void SetPlayerProgression(Dictionary<string,int> playerProgressionList){
		currentLevel = playerProgressionList[CURRENT_LEVEL];
		newGamePlussed = playerProgressionList[NEW_GAME_PLUSSED];
		timesDied = playerProgressionList[TIMES_DIED];
		goodPoints = playerProgressionList[GOOD_POINTS];
		evilPoints = playerProgressionList[EVIL_POINTS];
		score = playerProgressionList[SCORE];
	}
}
