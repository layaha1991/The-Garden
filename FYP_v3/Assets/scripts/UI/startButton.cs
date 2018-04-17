using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour {

	public void cameraSwitchToMainScene()
	{
		Camera.main.transform.position = new Vector3 (0f, 1f, -10f);
	}


}
