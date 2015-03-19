using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	void Continue () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	void NewGame() {
		Application.LoadLevel ("NameAccountCreate");
	}
}
