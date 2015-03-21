using UnityEngine;
using System.Collections;

public class TimeConverter {

	public static string SecTimeToHumanTimeString(int timeSec){
		string result = "0:00";
		int timerMinutes = 0;

		while(timeSec >= 60){
			timerMinutes ++;
			timeSec -= 60;
		}

		if(timeSec >= 10){
			result = timerMinutes.ToString() + ":" + timeSec.ToString();
		}
		else {
			result = timerMinutes.ToString() + ":0" + timeSec.ToString();
		}

		return result;
	}
}
