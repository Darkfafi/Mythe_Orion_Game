using UnityEngine;
using System.Collections;

public class GoodSlashEvilChoice : MonoBehaviour {

	public GameObject playerProgressionObject;
	private PlayerProgression playerProgression;
	public GameObject otherSide;
	public bool GoodPoints;

	void Start () {
		playerProgression = playerProgressionObject.GetComponent<PlayerProgression>();
		playerProgressionObject = null;
	}
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			if(GoodPoints == true){
				playerProgression.goodPoints ++;
				print("good points +1");
			}
			else {
				playerProgression.evilPoints ++;
				print("evil points +1");
			}
			Destroy(otherSide.gameObject);
			Destroy(gameObject);
		}
	}
}
