using UnityEngine;
using System.Collections;

public class TouchAbleObject : MonoBehaviour {

	protected bool getsTouched = false;

	public virtual void StartTouchObject(){
		getsTouched = true;
		SendMessage ("StartTouch");
	}

	public virtual void StopTouchObject(){
		getsTouched = false;
		SendMessage ("StopTouch");
	}
}
