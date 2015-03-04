using UnityEngine;
using System.Collections;

public class DestroyGameObjectTypeMission : Mission {

	public int totalOfGameObject;

	public GameObject gameobjectToDestroy;

	public int amount = 0;


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
