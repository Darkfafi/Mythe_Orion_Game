using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuLevelSelection : MonoBehaviour {
	
	private int selectedTab;
	private GameObject[] levelTabs;
	private GameObject startLevelButton;
	private GameObject personalTimeText;

	// Use this for initialization
	void Awake () {
		levelTabs = GameObject.FindGameObjectsWithTag("LevelTab");
		startLevelButton = GameObject.Find ("StartLevelButton");
		personalTimeText = GameObject.Find ("LevelPersonalTime");
	}

	void Start(){
		SelectTab(levelTabs.Length - 1);
	}

	void SelectTab(int tabInt){
		LevelSelectTabData currentTab;

		if(levelTabs[tabInt] != null){
			selectedTab = tabInt;
			currentTab = levelTabs[selectedTab].GetComponent<LevelSelectTabData>();
			currentTab.ChangeArtTo("Selected");
			startLevelButton.GetComponent<Image>().sprite = currentTab.GetStartButtonArt();
			startLevelButton.GetComponentInChildren<Text>().text = "Level " + (currentTab.levelIndex + 1).ToString();
			personalTimeText.GetComponent<Text>().text = "Personal Time: " + currentTab.timeCompleteInfo.ToString();
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
		Application.LoadLevel("LevelScene" + levelTabs[selectedTab].GetComponent<LevelSelectTabData>().levelIndex.ToString());
	}
}
