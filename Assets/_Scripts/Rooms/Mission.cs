using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class Mission : MonoBehaviour {

	private bool _checkMission = false; 

	//mission Time vars
	protected int missionBaseLevelTime; //aan de hand van in welk level je zit hoe hoog is de timer.
	protected int missionPersonalTimeCal; //aan de hand van de missie welke tijd zit er aan. Deze word gevult bij elke mission awake door hun eigen calculate. Voorbeeld: 'Killmission' missionPersonalTimeCal = enemiesToKill * timePerEnemy + (level * timeForEnemyPerLevel).

	//--

	protected string description = "";

	protected virtual void Awake(){
		//set missionBaseLevelTime and missionPersonalTimeCal.
		//Add mission description. 
	}

	// Use this for initialization
	public virtual void StartMission () {
		_checkMission = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(_checkMission){
			CheckMission();
		}
	}

	public string GetMissionDescription(){
		return description;
	}

	public int CalculateMissionTime(){
		return missionBaseLevelTime + missionPersonalTimeCal;
	}

	protected virtual void CheckMission(){

	}

	protected int numberOfGameObjectType(GameObject checkingGameObject){
		int amount = 0; 
		foreach(GameObject gameobj in GameObject.FindObjectsOfType<GameObject>()){

			if(checkingGameObject.name == gameobj.name){
				amount += 1;
			}
		}
		return amount;
	}
}
