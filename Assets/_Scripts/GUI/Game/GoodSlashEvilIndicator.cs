using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class GoodSlashEvilIndicator : MonoBehaviour {

	public Text goodGUI;
	public Text evilGUI;
	public GameObject playerProgressionObject;
	private PlayerProgression playerProgression;

	// Use this for initialization
	void Start () {
		playerProgression = playerProgressionObject.GetComponent<PlayerProgression>();
		playerProgressionObject = null;
		ChangeScore();
	}
	
	// Update is called once per frame
	void ChangeScore () {
		goodGUI.text = playerProgression.goodPoints.ToString();
		evilGUI.text = playerProgression.evilPoints.ToString();
	}
}
