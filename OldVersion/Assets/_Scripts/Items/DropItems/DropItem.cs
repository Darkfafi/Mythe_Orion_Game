using UnityEngine;
using System.Collections;

//Gemaakt door Nick

public class DropChance : MonoBehaviour {

	public int dropChance = 50;
	public GameObject dropableItem;

	public void DropItem () {
		int Q = Random.Range (0, 100);
		if (Q <= dropChance) {
			Instantiate(dropableItem,transform.position,new Quaternion(0,0,0,0));
		}
	}
}
