using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home_Button : MonoBehaviour {

	public void backToMenu()
	{
		Camera.main.transform.position = new Vector3 (-30f, 1f, -10f);
	}
}
