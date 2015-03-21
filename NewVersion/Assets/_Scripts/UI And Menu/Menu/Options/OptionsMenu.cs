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
		float SoundValue = slider.value;
		PlayerPrefs.SetFloat ("SoundLevel", SoundValue);
	}
	public void Music (Slider slider) {
		float MusicValue = slider.value;
		PlayerPrefs.SetFloat ("MusicValue", MusicValue);
	}
	public void DestroyOptions () {
		Destroy (gameObject);
	}
}
