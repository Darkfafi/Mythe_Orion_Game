using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject OptionsPrefab;

	public void Pauze () {
		Time.timeScale = 0;
		Debug.Log ("timeScale = " + Time.timeScale);
	}
	public void Resume () {
		Time.timeScale = 1;
		Debug.Log ("timeScale = " + Time.timeScale);
	}
	public void Options () {
		(Instantiate (OptionsPrefab, transform.parent.position, transform.rotation) as GameObject).transform.parent = transform;
	}
	public void ReturnToLvlSelect () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	public void ReturnToMenu () {
		Application.LoadLevel ("Menu");
	}
}
