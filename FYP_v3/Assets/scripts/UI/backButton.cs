using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour {

	private Vector3 original_CamPos;

	private bool isBackClicked;
	private float counter;

	void Start()
	{
		original_CamPos = new Vector3 (900f,75f,105f);
		isBackClicked = false;

	}
	void Update()
	{
		if (isBackClicked == true) 
		{
			backToMainScene ();
			counter += Time.deltaTime;
			if (counter > 1f) 
				{
				isBackClicked= false;
				counter = 0f;
				}


		}
	}
	public void backButtonClickFunction()
	{
		isBackClicked = true;
	}

	private void backToMainScene()
	{
		Camera.main.transform.rotation = Quaternion.Euler (150f, 0f, 180f);
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 80f, Time.deltaTime * 4f);
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, original_CamPos, Time.deltaTime * 4f);
		cameraManager.Instance.shouldTriggerWaterWheelUI = false;

	}
}
