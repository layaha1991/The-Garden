using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achievementText : MonoBehaviour {

	public GameObject _textGameObject;
	public Text _text;


	public bool countDown;
	public int achievementProgress;


	private Self _self;

	public float timeCounter;

	void Start ()
	{
		_self = GameObject.Find ("Self").GetComponent<Self> ();
		achievementProgress = 0;
		timeCounter = 0f;
		countDown = false;
	}


	void Update () 
	{
		achievementSystem ();
		countSystem ();
	}

	private void countSystem()
	{
		if (countDown == true)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter > 5f) 
			{
				countDown = false;
				timeCounter -= Time.deltaTime;
				timeCounter = 0f;
				_textGameObject.SetActive (false);
			}
		}
	}

	private void achievementSystem()
	{
		if (CurrencyManager.Instance.zenPower >= 1f && achievementProgress == 0) {
			_textGameObject.SetActive (true);
			_text.text = "Well done! Remember your first step!";
			achievementProgress += 1;
			countDown = true;
		}
		else if (CurrencyManager.Instance.zenPower >= 10f && achievementProgress == 1) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Can you feel yourself?";
			achievementProgress += 1;
			countDown = true;

		}
		else if (CurrencyManager.Instance.zenPower >= 25f && achievementProgress == 2) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Feel yourself... Starting from your finger...";
			achievementProgress += 1;
			countDown = true;
		}
		else if (CurrencyManager.Instance.zenPower >= 50f && achievementProgress == 2) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Now... to the body...";
			achievementProgress += 1;
			countDown = true;
		}
		else if (CurrencyManager.Instance.zenPower >= 100f && achievementProgress == 3) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Thank you very much for participating in our prototype test! \n Your opinions and feedbacks are much appreciated! \n Should you have any inquiry, please contact \n Layaha1991@yahoo.com.hk";
			achievementProgress += 1;
			//countDown = true;
			Camera.main.transform.position = new Vector3 (30f, 20f, -10f);
		}
		else if (CurrencyManager.Instance.zenPower >= 150f && achievementProgress == 4) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Who are you?";
			achievementProgress += 1;
			countDown = true;
		}
		else if (CurrencyManager.Instance.zenPower >= 200f && achievementProgress == 4) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Who are Not you?";
			achievementProgress += 1;
			countDown = true;
		}
		else if (CurrencyManager.Instance.zenPower >= 300f && achievementProgress == 4) 
		{
			_textGameObject.SetActive (true);
			_text.text = "Be yourself! Live yourself!";
			achievementProgress += 1;
			countDown = true;
		}
	}
}
