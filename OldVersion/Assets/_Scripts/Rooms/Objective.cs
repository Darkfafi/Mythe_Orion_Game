using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class Objective : MonoBehaviour {

	private string _description = "";
	private int _timeInSeconds = 0;
	private Mission mission; //the thing that keeps track of the mission. for example : are all the enemies defeated? 

	void Awake(){
		mission = gameObject.GetComponent<Mission> ();
	}

	void Start(){
		//get mission descrition and calculate time with mission info
		SetTimeForObjective(mission.CalculateMissionTime ());
		SetDescriptionForObjective (mission.GetMissionDescription());
		StartMission ();
	}

	public void StartMission(){
		mission.StartMission ();
		//send time data and description data to hud and if timer hits 0 then add poison component to player
	}

	public void SetDescriptionForObjective(string text){
		_description = text;
	}

	public void SetTimeForObjective(int seconds){
		_timeInSeconds = seconds;
	}
}
