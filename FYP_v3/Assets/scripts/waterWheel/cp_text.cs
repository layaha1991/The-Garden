using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cp_text : MonoBehaviour {

	public Text cpText;

	void Start ()
	{
	}

	void Update () {
		clickPowerText ();
	}

	private void clickPowerText()
	{
		cpText.text = "Click Power Increased by: " + waterUpgradeManager.Instance.clickPowerCount * 20f + "% \n Cost :" + waterUpgradeManager.Instance.clickPowerCost +" water";
	}


}
