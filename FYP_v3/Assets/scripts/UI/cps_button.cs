using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cps_button : MonoBehaviour {

	public void cps_button_function()
	{
		waterUpgradeManager.Instance.clickPerSecond ();
	}



}
