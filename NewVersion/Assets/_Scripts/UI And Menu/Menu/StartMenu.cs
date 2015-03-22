using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	private PlayerProgression playerProgression;
	public GameObject OptionsPrefab;

	void Start () {
		playerProgression = GetComponent<PlayerProgression> ();
	}
	public void Play () {
		if (playerProgression.nameUser != null) {
			Continue();
		}
		else {
			NewGame();
		}
	}

	void Continue () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	void NewGame() {
		Application.LoadLevel ("NameAccountCreate");
	}
	public void Options () {
		(Instantiate (OptionsPrefab, transform.parent.position, transform.rotation) as GameObject).transform.parent = transform;
	}
}
