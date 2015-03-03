using UnityEngine;
using System.Collections;

public class DestroyGameObjectTypeMission : Mission {

	public int totalOfGameObject;

	public GameObject gameobjectToDestroy;

	public int amount = 0;


	public override void StartMission ()
	{
		totalOfGameObject = GameObject.FindGameObjectsWithTag (gameobjectToDestroy.gameObject.tag).Length;
		base.StartMission ();
	}

	protected override void CheckMission ()
	{
		base.CheckMission ();
		if(amount != 0){
			if(GameObject.FindGameObjectsWithTag(gameobjectToDestroy.gameObject.tag).Length <= totalOfGameObject - amount){ //als de hoeveelheid nog aanwezig kleiner of gelijk is aan het aantal dat aanwezig was toen de missie begon - hoeveel je ervan moest destroyen.
				//guest completed
			}
		}else{
			if(GameObject.FindGameObjectsWithTag(gameobjectToDestroy.gameObject.tag).Length == 0){
				//guest completed
			}
		}
	}
}
