using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterUpgradeManager: MonoBehaviour {

	public static waterUpgradeManager Instance;

	[SerializeField]
	public float cpsPowerUp;
	[SerializeField]
	public float cpsCost;
	[SerializeField]
	public float clickPower;
	[SerializeField]
	public float clickPowerCost;


	public float cpsCount;
	public float clickPowerCount;

	private float elapsed;

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

	void Start () {
		
		clickPowerCount = 0f;
		clickPowerCost = 150f;
		cpsCount = 0f;
		cpsCost = 200f;
		cpsPowerUp = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clickPerSecond()
	{
		if (cpsPowerUp > 0.8f) 
		{
			cpsPowerUp = 0.8f;
		}

		if (CurrencyManager.Instance.newWater >= cpsCost && cpsPowerUp <= 0.7f) 
		{
			CurrencyManager.Instance.newWater -= cpsCost;
			cpsPowerUp += 0.06f;
			cpsCount++;
		}

		if (cpsPowerUp <= 0.5f) {
			cpsCost = Mathf.Round (200f * Mathf.Pow (1.15f, cpsCount));
		} else if (cpsPowerUp > 0.5f) {
			cpsCost = Mathf.Round (350f * Mathf.Pow (1.3f, cpsCount));
		}
	}


	public void clickPowerSystem()
	{
		
		if (CurrencyManager.Instance.newWater >= clickPowerCost) {
			CurrencyManager.Instance.newWater-= clickPowerCost;
			waterWheel.Instance.wheelSpeedUpgrade += 0.2f;
			clickPowerCount++;
		}
		if (waterWheel.Instance.wheelSpeedUpgrade <= 0.5f) {
			clickPowerCost = Mathf.Round (100f * Mathf.Pow (1.15f, clickPowerCount));
		} else if (waterWheel.Instance.wheelSpeedUpgrade > 0.5f) {
			clickPowerCost = Mathf.Round (150f * Mathf.Pow (1.2f, clickPowerCount));
		}
	}
		
}
