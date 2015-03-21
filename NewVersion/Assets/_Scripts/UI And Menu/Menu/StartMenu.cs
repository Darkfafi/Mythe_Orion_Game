using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	private PlayerProgression playerProgression;

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
		Application.LoadLevel ("Options");
	}
	public void Credits () {
		Application.LoadLevel ("Credits");
	}
}
