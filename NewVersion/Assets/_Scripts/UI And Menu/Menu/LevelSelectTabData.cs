using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectTabData : MonoBehaviour {


	PlayerProgression playerProgression;

	private bool unlockState = false;
	private bool selectionState = false;
	private Sprite levelImage;
	public int levelIndex;
	private int timeCompleteInfo;

	private string[] names;
	private string artName = "Locked";
	private Sprite[] artList;


	void Awake(){
		artList = Resources.LoadAll<Sprite>("Menu/TabArt"); //haalt uit de resources forlder alle button art

		levelImage = Resources.Load<Sprite> ("Menu/LevelPictureArt/Level" + levelIndex.ToString()); //haalt uit de resources folder zijn screenshot art

		names = new string[artList.Length];

		for(int i = 0; i < names.Length; i++) {
			names[i] = artList[i].name;
		} 
	}

	// Use this for initialization
	void Start () {

		playerProgression = GameObject.FindGameObjectWithTag ("Controller").GetComponent<PlayerProgression> ();

		//vraag voor data uit save stuff e als parameter geef mee zijn level index om goede dta te krijgen
		if(levelIndex <= playerProgression.currentLevel){
			unlockState = true;
			if(levelIndex == playerProgression.currentLevel){
				//TODO artStyle = Current level art
				artName = "Current";
				//GameObject.Find ("StartLevelButton").GetComponent<Image> ().sprite = levelImage; //<---- Test!!!
			}else{
				//TODO artStyle = Finished level art
				artName = "Open";
			}
			levelImage = Resources.Load<Sprite> ("Menu/LevelPictureArt/Level" + levelIndex.ToString());
		}else{
			//TODO artStyle = Locked level art
			artName = "Locked";
			levelImage = Resources.Load<Sprite> ("Menu/LevelPictureArt/Locked");
		}

		timeCompleteInfo = playerProgression.GetLevelTime(levelIndex);

		GetComponent<Image> ().sprite = artList [System.Array.IndexOf(names,artName)];
	}
}
