using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CheckIfObjectDestroyed : MonoBehaviour {

	public GameObject objectToCheck;
	public string textAfterEvent;
	
	// Update is called once per frame
	void Update () {
		if(objectToCheck == null){
			GetComponent<Text>().text = textAfterEvent;
			Destroy(this);
		}
	}
}
