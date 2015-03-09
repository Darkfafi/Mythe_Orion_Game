using UnityEngine;
using System.Collections;

public class DestroyGameObjectTypeMission : Mission {

	public int totalOfGameObject;

	public GameObject gameobjectToDestroy;

	public int amount = 0;

	protected override void Awake ()
	{
		base.Awake ();

		int currentLevel = GameObject.Find ("GameController").GetComponent<PlayerProgression> ().currentLevel;
		int totalToDestroy = amount;

		missionBaseLevelTime = Mathf.RoundToInt (10 / currentLevel);

		if(totalToDestroy == 0)	{
			totalToDestroy = totalOfGameObject;
			description = "Destroy all the " + gameobjectToDestroy.name + "(s).";
		}else{
			
			description = "Destroy " + totalToDestroy +" "+ gameobjectToDestroy.name + "(s).";
		}

		missionPersonalTimeCal = totalToDestroy * (Mathf.RoundToInt(15 / currentLevel));
	}

	public override void StartMission ()
	{
		totalOfGameObject = numberOfGameObjectType(gameobjectToDestroy);
		base.StartMission ();
	}

	protected override void CheckMission ()
	{
		base.CheckMission ();
		if(amount != 0){
			if(numberOfGameObjectType(gameobjectToDestroy) <= totalOfGameObject - amount){ //Als de hoeveelheid nog aanwezig kleiner of gelijk is aan het aantal dat aanwezig was toen de missie begon - hoeveel je ervan moest destroyen.
				//guest completed
			}
		}else{
			if(numberOfGameObjectType(gameobjectToDestroy) == 0){ //als alle van het object vernietigt is.
				//guest completed
			}
		}
	}
}
