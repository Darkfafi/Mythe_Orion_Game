using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NameLevelTimeDataSend : MonoBehaviour {

	PlayerProgression playerProg;

	private string url = "http://15826.hosts.ma-cloud.nl/Leerjaar2/Projecten/Mythe/phpHighScoreSend.php";

	public void SendData(){
		playerProg = GetComponent<PlayerProgression> ();
		WWWForm form = new WWWForm ();
		form.AddField ("name", playerProg.nameUser);
		form.AddField ("level", playerProg.currentPlayingLevel);
		form.AddField("time", playerProg.levelsCompleteWithTime[playerProg.currentLevel]); //data moet eerst opgeslagen worden voor het word opgestuurd

		WWW www = new WWW (url, form);

		StartCoroutine (WaitForRequest (www));
	}

	IEnumerator WaitForRequest(WWW www){
		yield return www;

		if(www.error == null){
			Debug.Log("Data sent: " + www.text);
		}else{
			Debug.Log("Erroorrrr: "+ www.error);
		}
	}
}
