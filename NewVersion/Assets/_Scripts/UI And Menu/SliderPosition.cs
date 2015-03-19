using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour {

	public Transform player;
	private float xPos;
	public Transform end;
	private Slider thisSlider;
	public GameObject ground;
	private float beginPosX;

	void Start () {
		beginPosX = player.position.x;

		thisSlider = GetComponent<Slider> ();
	}
	void Update () {
		xPos = (player.position.x - beginPosX) / end.position.x;
		thisSlider.value = xPos;
	}
}