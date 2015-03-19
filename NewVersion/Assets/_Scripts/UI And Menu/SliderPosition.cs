using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour {

	public Transform player;
	private float xPos;
	private float lvlWidth = 0;
	private Slider thisSlider;
	public GameObject ground;
	private float beginPosX;

	void Start () {
		if(player.position.x > 0){
			lvlWidth -= player.position.x;
		}
		else {
			lvlWidth += player.position.x;
		}
		foreach (Transform child in ground.transform)
		{
			lvlWidth += child.GetComponent<Renderer>().bounds.size.x;
		}
		thisSlider = GetComponent<Slider> ();
	}
	void Update () {
		xPos = player.position.x / lvlWidth;
		thisSlider.value = xPos;
	}
}