using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	private PlayerProgression playerProgression;
	public GameObject OptionsPrefab;

	void Start () {
		if (!PlayerPrefs.HasKey ("SoundLevel")) {
			PlayerPrefs.SetFloat("SoundLevel", 1);
			PlayerPrefs.Save();
		}
		if (!PlayerPrefs.HasKey ("MusicLevel")) {
			PlayerPrefs.SetFloat("MusicLevel", 1);
			PlayerPrefs.Save();
		}
	}
	void AllDataComponentsAdded () {
		playerProgression = GetComponent<PlayerProgression> ();
		if(playerProgression.nameUser == null){
			NewGame();
		}
	}
	public void Play () {
		Continue();
	}

	void Continue () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	void NewGame() {
		Application.LoadLevel ("NameAccountCreate");
	}
	public void Options () {
		GameObject options;
		GameObject Canvas = GameObject.Find ("Canvas");
		options = Instantiate (OptionsPrefab, transform.parent.position, transform.rotation) as GameObject;
		options.transform.SetParent(Canvas.transform,false);
		options.transform.position = Canvas.transform.position;
	}
}
