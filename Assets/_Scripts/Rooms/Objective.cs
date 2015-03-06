using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class Objective : MonoBehaviour {

	private string _description = "";
	private int _timeInSeconds = 0;
	public Mission mission; //the thing that keeps track of the mission. for example : are all the enemies defeated? 

	void Start(){
		//get mission descrition and calculate time with mission info
		SetTimeForObjective(mission.CalculateMissionTime ());
		SetDescriptionForObjective (mission.GetMissionDescription());
	}

	public void StartMission(){

	}

	public void SetDescriptionForObjective(string text){
		_description = text;
	}

	public void SetTimeForObjective(int seconds){
		_timeInSeconds = seconds;
	}
}
