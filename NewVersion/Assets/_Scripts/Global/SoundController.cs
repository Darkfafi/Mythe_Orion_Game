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
	public void PlaySound (int SoundNumber) {
		source.PlayOneShot(sounds[SoundNumber], PlayerPrefs.GetFloat("SoundLevel"));
	}
}
