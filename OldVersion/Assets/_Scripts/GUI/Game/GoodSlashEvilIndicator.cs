using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoodSlashEvilIndicator : MonoBehaviour {

	public Text goodGUI;
	public Text evilGUI;
	public GameObject playerProgressionObject;
	private PlayerProgression playerProgression;

	void OnEnable () {
		if (playerProgression == null) {
			playerProgression = playerProgressionObject.GetComponent<PlayerProgression>();
			if(playerProgression != null){
				playerProgressionObject = null;
			}
		}
		goodGUI.text = playerProgression.goodPoints.ToString(); 
		evilGUI.text = playerProgression.evilPoints.ToString();
	}
}
