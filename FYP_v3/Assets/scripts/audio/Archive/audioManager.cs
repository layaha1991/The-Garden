
using UnityEngine;
using UnityEngine.Audio;
using System;
public class audioManager : MonoBehaviour {


	public Sound[] sounds;

	public static audioManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.volume = s.volume;
			s.source.clip = s.clip;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	void Start()
	{
		Play ("BGM");
	}
		
	public void Play(string name)
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);
		s.source.Play ();
	}

	public void PlayRandomClip(int numOfSound)
	{
		int x = UnityEngine.Random.Range (0, numOfSound);
		string soundName = "ZenGarden_" +x;
		Play (soundName);
	}
	//  FindObjectOfType<AudioManager>().Play("PlayerDeath");
}
