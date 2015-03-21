using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowUserName : MonoBehaviour {

	public GameObject usernameTextField;

	// Use this for initialization
	void AllDataComponentsAdded () {
		usernameTextField.GetComponent<Text> ().text = "User: " + GetComponent<DataManager> ().GetPlayerProgression().nameUser; 
	}
}
