using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

	private Text text;
	private int timerMinute = 0;
	private float timerSecond = 0;
	private bool timing = false;

	void Start (){
		text = gameObject.GetComponent<Text> ();
		SetTimer (1, 3);
	}

	public void SetTimer (int minutes, int seconds){
		if(seconds >= 10){
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
			timerSecond -= Time.deltaTime;
			if(timerSecond >= 10){
				text.text = timerMinute + " : " + timerSecond.ToString ("0");
			}
			else {
				text.text = timerMinute + " : 0" + timerSecond.ToString ("0");
			}
			if(timerSecond <= 0){
				if(timerMinute > 0){
					timerMinute --;
					timerSecond += 60;
				}
				else {
					timing = false;
					timerSecond = 0;
					text.text = " ";
					//TODO tijd is op
				}
			}
		}
	}
}
