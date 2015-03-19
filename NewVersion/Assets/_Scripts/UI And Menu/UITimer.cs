using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

	private Text text;
	private int timerMinute = 0;
	private float timerSecond = 0;
	private bool timing = false;
	private float totalTime;

	void Start (){
		text = gameObject.GetComponent<Text> ();
		SetTimer (0, -0.5f);
	}

	public void SetTimer (int minutes, float seconds){
		if(seconds >= 9.5f){
			text.text = minutes + " : " + seconds;
		}
		else {
			text.text = minutes + " : 0" + seconds;
		}
		timerMinute = minutes;
		timerSecond = seconds;
		timing = true;
	}
	void Update () {
		if (timing == true) {
			timerSecond += Time.deltaTime;
			if(timerSecond >= 9.5f){
				text.text = timerMinute + " : " + timerSecond.ToString ("0");
			}
			else {
				text.text = timerMinute + " : 0" + timerSecond.ToString ("0");
			}
			if(timerSecond >= 59.5f){
				timerMinute ++;
				timerSecond -= 60;
			}
		}
	}
	public float TotalTime (){
		totalTime = timerMinute + timerSecond / 100;
		return(totalTime);
	}
}
