using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour {

	private Slider slider;
	public Text text;
	private float sliderValue = 1;

	void Start () {
		slider = GetComponent<Slider> ();
		if (gameObject.name == "Sound") {
			slider.value = PlayerPrefs.GetFloat("SoundLevel");
			UpdateText();
		}
		else if (gameObject.name == "Music"){
			slider.value = PlayerPrefs.GetFloat("MusicLevel");
			UpdateText();
		}
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
