using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStages : MonoBehaviour {

	public bool canOtherBambooSpawn;
	public int Stage;
	private float bambooEnergySpawnCD;

	private Vector3 bambooSpawnPoint;
	private Vector3 bambooEnergyspawnPoint;

	public GameObject bambooEnergyBundle;
	public GameObject[] Stage2;
	public GameObject[] Stage3;
	private UIManager _uiManager;
	private grow _grow;


	void Start()
	{
		_uiManager = GameObject.Find ("UI_Manager").GetComponent<UIManager> ();
		_grow = GameObject.Find ("bambooGrowManager").GetComponent<grow> ();
		canOtherBambooSpawn = false;
		Stage = 1;
		bambooSpawnPoint = new Vector3 (-0.17f, 2.14f, 0.0f);
		bambooSpawnPoint += transform.position;
		bambooEnergySpawnCD = 30f;

	}

	void Update ()
	{
		spawnBambooEnergySystem ();
	}


		

	void OnMouseDown ()
	{
		if (CurrencyManager.Instance.newWater >= 500f) {
			if ((_grow.grown == true) && (Stage == 1)) {
				Instantiate (Stage2 [0], bambooSpawnPoint, Quaternion.identity);
				bambooSpawnPoint += new Vector3 (-0.12f, 1.93f, 0.0f);
				Instantiate (Stage2 [1], bambooSpawnPoint, Quaternion.identity);
				Stage = 2;
				CurrencyManager.Instance.newWater -= 300f;
			} else if ((_grow.grown == true) && (Stage == 2)) {
				bambooSpawnPoint += new Vector3 (-0.007f, 1.78f, 0.0f);
				Instantiate (Stage3 [0], bambooSpawnPoint, Quaternion.identity);
				bambooSpawnPoint += new Vector3 (-0.077f, 2.15f, 0.0f);
				Instantiate (Stage3 [1], bambooSpawnPoint, Quaternion.identity);
				bambooSpawnPoint += new Vector3 (-0.007f, 0.74f, 0.0f);
				Instantiate (Stage3 [2], bambooSpawnPoint, Quaternion.identity);
				Stage = 3;
				CurrencyManager.Instance.newWater -= 300f;
				canOtherBambooSpawn = true;
			} else 
			{
				return;
			}
		}
	}


	private IEnumerator spawnBambooEnergy()
	{
		
		while(true)
		{
			bambooSpawnPoint = transform.position + new Vector3 (Random.Range (-1f,1f), Random.Range (4f,9f), 0f);
			Instantiate (bambooEnergyBundle , bambooSpawnPoint, Quaternion.identity);
			if (Camera.main.transform.position.x == 90f) 
			{
				audioManager.Instance.PlayRandomClip (4);
			}
			yield return new WaitForSeconds (bambooEnergySpawnCD);
		}
	}


	private void spawnBambooEnergySystem()
	{
		if (Stage == 3)
		{
			
			StartCoroutine ("spawnBambooEnergy");
			Stage = 4;
		}
	}

}
