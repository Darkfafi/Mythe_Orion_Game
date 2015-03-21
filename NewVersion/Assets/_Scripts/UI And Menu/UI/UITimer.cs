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
		SetTimer (0, 0);
	}

	public void SetTimer (int minutes, float seconds){
		if(seconds >= 10){
			text.text = minutes + ":" + seconds;
		}
		else {
			text.text = minutes + ":0" + seconds;
		}
		timerMinute = minutes;
		timerSecond = seconds;
		timing = true;
	}
	void Update () {
		if (timing == true) {
			timerSecond += Time.deltaTime;
			if(timerSecond >= 10){
				text.text = timerMinute + ":" + Mathf.Floor (timerSecond);
			}
			else {
				text.text = timerMinute + ":0" + Mathf.Floor (timerSecond);
			}
			if(timerSecond >= 60){
				timerMinute ++;
				timerSecond -= 60;
			}
		}
	}
	public int TotalTime (){
		int totalTime = Mathf.RoundToInt(timerSecond);
		int timeMinute = timerMinute;
		while (timeMinute >= 60) {
			timeMinute -= 60;
			totalTime += 10000;
		}
		totalTime += timeMinute * 100;
		if (timerMinute > 50339) {
			totalTime = 8385959; //hoger dan dit crasht de database, en zet een score van 00:00:00 neer, wat dus de highscore wordt
		}
		return(totalTime);
	}
}
