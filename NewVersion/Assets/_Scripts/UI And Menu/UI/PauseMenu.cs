using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {
	
	public GameObject OptionsPrefab;
	public GameObject PauseTabMenu;

	public void Pauze () {
		Time.timeScale = 0;

		//Debug.Log ("timeScale = " + Time.timeScale);
	}
	public void Resume () {
		Time.timeScale = 1;
		//Debug.Log ("timeScale = " + Time.timeScale);
	}
	public void Options () {
		GameObject options;
		options = Instantiate (OptionsPrefab, transform.parent.position, transform.rotation) as GameObject;
		options.transform.SetParent(gameObject.transform,false);
		options.transform.position = PauseTabMenu.transform.position;
	}
	public void ReturnToLvlSelect () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	public void ReturnToMenu () {
		Application.LoadLevel ("Menu");
	}
	public void Restart () {
		Application.LoadLevel ("LevelScene" + GameObject.Find ("GameController").GetComponent<PlayerProgression> ().currentPlayingLevel);
	}
}
