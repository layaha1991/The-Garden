using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit_button : MonoBehaviour {

	public void quitTheGame()
	{
		Debug.Log ("has quit the game");
		Application.Quit ();
	}
}
