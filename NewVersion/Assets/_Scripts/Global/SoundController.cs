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
		Debug.Log (sounds [SoundNumber]);
		if (loop == false) {
			source.loop = false;
			source.volume = 1;
			source.PlayOneShot(sounds[SoundNumber], PlayerPrefs.GetFloat("SoundLevel"));
		}
		else {
			source.loop = true;
			source.volume = PlayerPrefs.GetFloat("SoundLevel");
			source.clip = sounds[SoundNumber];
			source.Play();
		}
	}
	public bool IsPlaying () {
		return(source.isPlaying);
	}
}
