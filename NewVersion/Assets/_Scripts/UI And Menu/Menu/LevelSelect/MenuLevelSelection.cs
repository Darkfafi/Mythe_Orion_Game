using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuLevelSelection : MonoBehaviour {
	
	private int selectedTab;
	private GameObject[] levelTabs;
	private GameObject startLevelButton;
	private GameObject personalTimeText;
	private GameObject recordTimeText;
	private GameObject startText;

	void Start(){
		levelTabs = GameObject.FindGameObjectsWithTag("LevelTab");
		startLevelButton = GameObject.Find ("StartLevelButton");
		personalTimeText = GameObject.Find ("LevelPersonalTime");
		recordTimeText = GameObject.Find ("LevelRecordTime");
		startText = GameObject.Find("StartText");

		SelectTab(selectedTab);
	}

	void SelectTab(int tabInt){
		LevelSelectTabData currentTab;

		if(levelTabs[tabInt] != null){
			selectedTab = tabInt;
			currentTab = levelTabs[selectedTab].GetComponent<LevelSelectTabData>();
			currentTab.ChangeArtTo("Selected");

			startLevelButton.GetComponent<Image>().sprite = currentTab.GetStartButtonArt();
			startLevelButton.GetComponentInChildren<Text>().text = "Level " + (currentTab.levelIndex + 1).ToString();

			personalTimeText.GetComponent<Text>().text = "Personal Time: " + TimeConverter.SecTimeToHumanTimeString(currentTab.timeCompleteInfo);

			if(currentTab.unlockState){
				SetRecordTimeText(currentTab.levelIndex);
				startText.GetComponent<Text>().text = "Press to Play";
			}else{
				recordTimeText.GetComponent<Text>().text = "Unlock level to see world record time";
				startText.GetComponent<Text>().text = "Locked";
			}
			//recordTimeText.GetComponent<Text>().text = "Record time: by " +  
		}
	}

	public void ChangeTab(int directionValue){
		levelTabs[selectedTab].GetComponent<LevelSelectTabData>().ChangeArtTo();
		if(selectedTab + directionValue <= levelTabs.Length - 1 && selectedTab + directionValue >= 0){
			selectedTab = selectedTab + directionValue;
		}else if(directionValue < 0){
			selectedTab = levelTabs.Length - 1;
		}else{
			selectedTab = 0;
		}

		SelectTab(selectedTab);
	}

	public void StartSelectedLevel(){
		if (levelTabs [selectedTab].GetComponent<LevelSelectTabData> ().unlockState) {

			GetComponent<PlayerProgression>().currentPlayingLevel = levelTabs[selectedTab].GetComponent<LevelSelectTabData>().levelIndex;
			GetComponent<SaveLoadData>().Save();

			Application.LoadLevel ("LevelScene" + levelTabs [selectedTab].GetComponent<LevelSelectTabData> ().levelIndex.ToString ());
		}
	}

	void SetRecordTimeText(int levelIndex){
		string url = "http://15826.hosts.ma-cloud.nl/Leerjaar2/Projecten/Mythe/phpRecordTimeGet.php";
		WWWForm form = new WWWForm ();
		form.AddField ("level", levelIndex);
		WWW www = new WWW (url, form);
		StartCoroutine (WaitForRequest (www));
	}
	IEnumerator WaitForRequest(WWW www){

		yield return www;

		string recordText = "No connection";

		if(www.error == null){
			if(www.text != "Null"){
				char[] splitchar = { ' ' };
				string[] splitResult = www.text.Split(splitchar);
				recordText = "World record time: " + TimeConverter.SecTimeToHumanTimeString(int.Parse(splitResult[1])) +" by "+ splitResult[0];
			}else{
				recordText = "No World record time yet!";
			}
		}else{
			recordText = "Internet connection needed for World record time";
		}
		recordTimeText.GetComponent<Text>().text = recordText;
	}

}
