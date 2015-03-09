using UnityEngine;
using System.Collections;

//Gemaakt door Ramses

public class DataScoreTransfer : MonoBehaviour {

	//score roept naar dataTransfer wat hij wil sturen

	public void sendScoreToDatabase(string name, int goodPoints, int evilPoints){

		string url = "http://localhost/school/LeerJaar%202/JimTussenLessen/wwwHighScoreSend/sendHighScoreData.php";

		WWWForm form = new WWWForm ();
		form.AddField ("name", name);
		form.AddField ("goodPoints", goodPoints);
		form.AddField ("evilPoints", evilPoints);
		form.AddField ("table", "highscoreoefeningdata");
		WWW www = new WWW (url, form);

		StartCoroutine(WaitForRequest (www));
	}

	private IEnumerator WaitForRequest(WWW www){
		yield return www;
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
}
