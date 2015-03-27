using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleBehavior : MonoBehaviour {

	private Toggle toggle;
	public SliderUpdater sliderUpdater;

	void Start () {
		toggle = GetComponent<Toggle> ();
	}
	public void ValueChanged () {
		if(toggle.isOn == false){
			sliderUpdater.UpdateSlider (0);
		}
		else if (sliderUpdater.SliderValue() == 0) {
			sliderUpdater.UpdateSlider(100);
		}
		sliderUpdater.UpdateText ();
	}
	public void CheckValue (Slider slider) {
		if (slider.value != 0 && toggle.isOn == false) {
			toggle.isOn = true;
		}
	}
}
