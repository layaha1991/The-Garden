using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterPowerScript : MonoBehaviour {

	private waterWheel _ww;
	[SerializeField]
	private float fillAmount;
	[SerializeField]
	private Image content;

	void Start()
	{
		_ww = GameObject.Find ("waterWheel").GetComponent<waterWheel> ();
	}


	/**void Update () {
		content.fillAmount = fillAmount;
		fillAmount = _ww.wheelPower / 100f;

	}**/
}
