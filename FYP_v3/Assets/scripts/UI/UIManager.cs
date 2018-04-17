using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager Instance;


	public GameObject fishEnergyText;
	public GameObject bambooEnergyText;
	public GameObject energyText;
	public GameObject zenPowerText;
	public GameObject[] zenButton;
	public GameObject homeButton;
	public GameObject quitButton;
	public GameObject backButton;
	public GameObject spawnFish;
	public GameObject startButton;
	public GameObject[] waterWheelUpgradeButton;


	private Self _self;


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
		_self = GameObject.Find("Self").GetComponent<Self> ();


	}

	void Update () 
	{
		

		//setSpawnFishButtonActive ();
		setWaterWheelUpgradeButtonActive ();
		setStartMenuButtonActive ();
		setBackButtonActive ();
		setZenButtonActive ();
	}






	/**private void setSpawnFishButtonActive()
	{
		if (Camera.main.transform.position.x == 60f) {
			spawnFish.SetActive (true);
		} else if (Camera.main.transform.position.x != 60f) {
			spawnFish.SetActive (false);
		}
	}
	**/


	private void setWaterWheelUpgradeButtonActive()
	{
		if (cameraManager.Instance.shouldTriggerWaterWheelUI ==true) {
			waterWheelUpgradeButton[0].SetActive (true);
			waterWheelUpgradeButton[1].SetActive (true);
			waterWheelUpgradeButton [2].SetActive (true);
		} else
		{
			waterWheelUpgradeButton[0].SetActive (false);
			waterWheelUpgradeButton[1].SetActive (false);
			waterWheelUpgradeButton [2].SetActive (false);
		}
	}
		
	private void setZenButtonActive()
	{
		if (Camera.main.transform.position.x == 30f) {
			zenButton [0].SetActive (true);
	
		} else if (Camera.main.transform.position.x != 30f) {
			zenButton [0].SetActive (false);

		}
	}
			

	private void setStartMenuButtonActive ()
	{
		if (Camera.main.transform.position.x == -60f) {
			startButton.SetActive (true);
			quitButton.SetActive (true);
			homeButton.SetActive (false);
			energyText.SetActive (false);
			zenPowerText.SetActive (false);
			fishEnergyText.SetActive(false);
			bambooEnergyText.SetActive(false);

		} else if (Camera.main.transform.position.x == -120f) {
			startButton.SetActive (false);
			quitButton.SetActive (false);
			homeButton.SetActive (false);
			energyText.SetActive (false);
			zenPowerText.SetActive (false);
			fishEnergyText.SetActive(false);
			bambooEnergyText.SetActive(false);
		} else if (Camera.main.transform.position.x != -60f) {
			startButton.SetActive (false);
			quitButton.SetActive (false);
			homeButton.SetActive(true);
			energyText.SetActive (true);
			zenPowerText.SetActive (true);
			fishEnergyText.SetActive(true);
			bambooEnergyText.SetActive(true);
		}
	}

	private void setBackButtonActive()
	{
		if (Camera.main.transform.position.x == -60 || Camera.main.transform.position.x == -120) {
			backButton.SetActive (false);
		} else if (Camera.main.transform.position.x != -60)
			backButton.SetActive (true);
	}



}
