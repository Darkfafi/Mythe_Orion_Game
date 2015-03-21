using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectTabData : MonoBehaviour {


	PlayerProgression playerProgression;

	public bool unlockState = false;
	private Sprite levelImage;
	public int levelIndex;
	public int timeCompleteInfo;

	private string[] names;
	private string originalArtName = "Locked";
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
				originalArtName = "Current";
			}else{
				originalArtName = "Open";
			}
			levelImage = Resources.Load<Sprite> ("Menu/LevelPictureArt/Level" + levelIndex.ToString());
		}else{
			originalArtName = "Locked";
			levelImage = Resources.Load<Sprite> ("Menu/LevelPictureArt/Locked");
		}
		if (GetComponent<Image> ().sprite.name != "Selected") {
			ChangeArtTo (originalArtName);
		}
		timeCompleteInfo = playerProgression.GetLevelTime(levelIndex);
	}

	public Sprite GetStartButtonArt(){
		return levelImage;
	}

	public void ChangeArtTo(string artResourceName = "backToNormal"){
		string artName = "";
		if(artResourceName != "backToNormal"){
			artName = artResourceName;
		}else{
			artName = originalArtName;
		}
		
		GetComponent<Image> ().sprite = artList [System.Array.IndexOf(names,artName)];
	}
}
