using UnityEngine;
using System.Collections;

public class LevelTabGenerator : MonoBehaviour {

	public GameObject levelTabPrefab;
		
	void Awake(){
		AddLevelTabs (6);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void AddLevelTabs (int amount) {
		GameObject levelTab;
		for (int i = 0; i < amount; i++) {
			levelTab = Instantiate(levelTabPrefab,new Vector3((transform.position.x - 400) + i * 120f,transform.position.y + 100,0),Quaternion.identity) as GameObject;

			levelTab.transform.SetParent(gameObject.transform,false);

			levelTab.transform.localScale = new Vector3(1,4.5f,1);

			levelTab.GetComponent<LevelSelectTabData>().levelIndex = i;
		}
	}


}
