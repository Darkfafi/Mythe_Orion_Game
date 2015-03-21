using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour {

	private Slider slider;
	public Text text;
	private float sliderValue = 1;

	void Start () {
		slider = GetComponent<Slider> ();
	}
	public void UpdateText () {
		if(slider.enabled == true){
			sliderValue = slider.value;
			float sliderValueTemp = sliderValue * 100;
			text.text = sliderValueTemp.ToString("0") + "%";
		}
		else {
			text.text = "0%";
		}
	}
}
