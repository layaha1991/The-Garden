using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wwSound : MonoBehaviour {

	private float counter;
	public AudioClip waterWheelSound;
	AudioSource audioSource;
	private bool isLastOneFinish;
	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource> ();
		isLastOneFinish = true;
	}
	
	// Update is called once per frame
	void Update () {
		playWaterWheelSound ();
		checkIfLastOneIsFinish ();
	}


	private void playWaterWheelSound()
	{
		if (waterWheel.Instance.wheelSpeed > 0f && isLastOneFinish == true) {
			if (Camera.main.transform.position.x == 0f) {
				audioSource.PlayOneShot (waterWheelSound);
				isLastOneFinish = false;
			}

		} 
		if(waterWheel.Instance.wheelSpeed == 0f && isLastOneFinish ==false)
		{
			audioSource.Stop();
			isLastOneFinish = true;
			counter =0f;
		}

	}

	private void checkIfLastOneIsFinish ()
	{
		if (isLastOneFinish == false) {
			counter += Time.deltaTime;
			if (counter >= 60f) {
				isLastOneFinish = true;
			}
		}
	}

}
