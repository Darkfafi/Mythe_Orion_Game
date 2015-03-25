using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour {

	public Transform player;

	private float xPos;
	public Transform end;

	private Slider thisSlider;
	private float startDisance;
	private float beginPosX;

	void Start () {
		beginPosX = player.position.x;

		startDisance = Mathf.Abs (beginPosX) + Mathf.Abs (end.position.x);

		thisSlider = GetComponent<Slider> ();
	}
	void Update () {

		float distance = Mathf.Abs (end.position.x) - (player.transform.position.x);

		float part = startDisance - distance;

		xPos = (part) / startDisance;

		thisSlider.value = xPos;
	}
}