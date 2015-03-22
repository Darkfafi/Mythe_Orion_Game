using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject OptionsPrefab;

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
	}
	public void ReturnToLvlSelect () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	public void ReturnToMenu () {
		Application.LoadLevel ("Menu");
	}
}
