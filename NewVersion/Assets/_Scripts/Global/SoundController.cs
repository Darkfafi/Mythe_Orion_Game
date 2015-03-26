using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip sound;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();
	}

	public void PlaySound () {
		source.PlayOneShot(sound, PlayerPrefs.GetFloat("SoundLevel"));
	}
	public float TimeTillEnd () {
		float time;
		time = sound.length - source.time;
		if (time <= 0) {
			return(0);
		}
		else {
			return(time);
		}
	}
}
