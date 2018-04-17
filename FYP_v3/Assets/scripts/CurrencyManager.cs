using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

	public static CurrencyManager Instance;

	public float water;
	public float newWater;

	public float bambooEnergy;
	public float fishEnergy;

	public float zenPower;

	public Text bambooEnergyText;
	public Text fishEnergyText;
	public Text waterText;
	public Text zenPowerText;


	void Awake()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else
		{
			Destroy (gameObject);
		}
	}



	void Start () 
	{
	}
	

	void Update () 
	{
		waterTextSystem ();
		zenPowerTextSystem ();
		bambooEnergyTextSystem ();
		fishEnergyTextSystem ();
	}

	private void waterTextSystem()
	{
		water = (waterWheel.Instance.wheelSpeed/ 3);
		newWater +=water;
		waterText.text= "Water :" + (int) newWater;
	}

	private void bambooEnergyTextSystem()
	{
		bambooEnergyText.text= "Bamboo Energy :" + (int) bambooEnergy;
	}
	private void fishEnergyTextSystem()
	{
		fishEnergyText.text= "Fish Energy :" + (int) fishEnergy;
	}
	private void zenPowerTextSystem()
	{
		zenPowerText.text = "Zen Power :" + (int) zenPower;
	}
}
