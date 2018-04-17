using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cps_text : MonoBehaviour {

	public Text cpsText;

	void Start ()
	{

	}

	void Update () {
		clickPerSecondText ();
	}
		

	private void clickPerSecondText()
	{
		cpsText.text = "Auto-click: 1 click / " + waterWheel.Instance.cpsCD + "seconds \n Cost :" +waterUpgradeManager.Instance.cpsCost+" water";
	}
}
