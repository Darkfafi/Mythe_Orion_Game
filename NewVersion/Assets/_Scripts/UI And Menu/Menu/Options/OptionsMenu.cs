using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	private PlayerProgression playerProgression;

	void Start () {
		playerProgression = GetComponent<PlayerProgression> ();
		if (playerProgression.nameUser == null) {
			GetComponentInChildren<Reset>().Disable();
		}
	}
	public void Sound (Slider slider) {
		PlayerPrefs.SetFloat ("SoundLevel", slider.value);
		PlayerPrefs.Save();
		Debug.Log (PlayerPrefs.GetFloat("SoundLevel"));
	}
	public void Music (Slider slider) {
		PlayerPrefs.SetFloat ("MusicLevel", slider.value);
		PlayerPrefs.Save();
		Debug.Log (slider.value);
	}
	public void DestroyOptions () {
		Destroy (gameObject);
	}
}
