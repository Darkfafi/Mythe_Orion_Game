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

	public static int SecTimeToDatabaseTime(int time){
		int dataTime = 0;

		while(time >= 3600){
			time -= 3600;
			dataTime += 10000; // simuleert 1:00:00
		}
		while (time >= 60){
			time -= 60;
			dataTime += 100;
		}
		dataTime += time;

		return dataTime;
	}
}
