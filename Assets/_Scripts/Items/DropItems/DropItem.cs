using UnityEngine;
using System.Collections;

public class DropChance : MonoBehaviour {

	public int dropChance = 50;
	public GameObject dropableItem;

<<<<<<< HEAD:Assets/_Scripts/Items/DropItems/DropChance.cs
	public void DropItem () {
		int Q = Random.Range (0, 100);
		if (Q <= dropChance) {
			Instantiate(dropableItem,transform.position,new Quaternion(0,0,0,0));
=======
	void Start () {
		int Q = Random.Range (0, 100);
		if (Q <= dropChance) {
			dropItemOnDeath = true;
		}
		else {
			dropItemOnDeath = false;
		}
		DropItem ();
	}
	public void DropItem () {
		if (dropItemOnDeath == true) {
			Instantiate(dropableItem, transform.position, transform.rotation);
>>>>>>> b58a63ffb47ebd460eb4e2252be9bea202a1367d:Assets/_Scripts/Items/DropItems/DropItem.cs
		}
	}
}
