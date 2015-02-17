using UnityEngine;
using System.Collections;

public class DropChance : MonoBehaviour {

	public int dropChance = 50;
	private bool dropItemOnDeath;
	public GameObject dropableItem;

	void Start () {
		int Q = Random.Range (0, 100);
		if (Q <= dropChance) {
			dropItemOnDeath = true;
		}
		else {
			dropItemOnDeath = false;
		}
	}
	public void DropItem () {
		if (dropItemOnDeath == true) {
			Instantiate(dropableItem);
		}
	}
}
