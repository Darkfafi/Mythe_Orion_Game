using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip[] sounds;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();
	}
	public void StopSound () {
		source.Stop ();
	}
	public void PlaySound (int SoundNumber, bool loop) {
		Debug.Log(sounds[SoundNumber] + " " + SoundNumber + " " + loop);
		if (loop == false) {
			source.loop = false;
		}
		else {
			source.loop = true;
		}
		source.PlayOneShot(sounds[SoundNumber], PlayerPrefs.GetFloat("SoundLevel"));
	}
}
