using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

	private Text score;
	private Text bestTime;
	private Text worldTime;
	private PlayerProgression playerProgression;

	void Start () {
		playerProgression = GameObject.Find ("GameController").GetComponent<PlayerProgression> ();
		score = GameObject.Find ("YourTime").GetComponent<Text>();
		bestTime = GameObject.Find ("BestTime").GetComponent<Text>();
		worldTime = GameObject.Find ("WorldBestTime").GetComponent<Text>();

		score.text = TimeConverter.SecTimeToHumanTimeString(GameObject.Find ("TimeText").GetComponent<UITimer> ().TotalTime ());
		bestTime.text = TimeConverter.SecTimeToHumanTimeString(playerProgression.GetLevelTime (playerProgression.currentPlayingLevel));


		string url = "http://15826.hosts.ma-cloud.nl/Leerjaar2/Projecten/Mythe/phpRecordTimeGet.php";
		WWWForm form = new WWWForm ();
		form.AddField ("level", playerProgression.currentPlayingLevel);
		WWW www = new WWW (url, form);

		StartCoroutine (WaitForRequest (www));
	}
	public void BackToSelect () {
		Application.LoadLevel ("LevelSelectionScreen");
	}
	IEnumerator WaitForRequest(WWW www){
		yield return www;

		if (www.error != null) {
			worldTime.text = "No Internet";
		}else{
			if(www.text != "Null"){
				char[] splitchar = {' '};
				string[] splitResult = www.text.Split(splitchar);
				worldTime.text = " by " + splitResult[0] + " \n" +TimeConverter.SecTimeToHumanTimeString (int.Parse(splitResult[1]));
			}else{
				worldTime.text = "No time yet";
			}
		}
	}
}
