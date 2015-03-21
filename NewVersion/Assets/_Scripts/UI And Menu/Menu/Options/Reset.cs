using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reset : MonoBehaviour {

	public GameObject youSure;
	public void ResetAll () {
		Application.LoadLevel ("NameAccountCreate");
	}
	public void Disable () {
		GetComponent<Button> ().enabled = false;
	}
}
