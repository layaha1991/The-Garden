using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bambooStage1 : MonoBehaviour {

	[SerializeField]
	private bool _stage1canSpawn;

	public GameObject[] stageCompleteds;

	[HideInInspector]
	public Vector3 spawnPoint;

	public Stages[] stages;

	public GameObject Bamboo;

	public int Energy = 0;

	private UIManager _uiManager;

	[System.Serializable]
	public class Stages
	{
		public GameObject[] bamboo;
	}

	void Awake(){
		_stage1canSpawn = true;
		_uiManager = GameObject.Find ("UI_Manager").GetComponent<UIManager> ();
	}


	void Update(){ 


//		callEnergy ();

		stageCompleteds = GameObject.FindGameObjectsWithTag("bamboo");

		foreach (GameObject stageCompleted in stageCompleteds) {

			_stage1canSpawn=stageCompleted.GetComponent<spawnStages> ().canOtherBambooSpawn;
		}
	}

		
	void OnMouseDown(){

		if (CurrencyManager.Instance.newWater >= 100f) {
			if (_stage1canSpawn == true) {

				spawnPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));

				StartCoroutine (spawnStage1 ());
		
				_stage1canSpawn = false;	
				CurrencyManager.Instance.newWater-= 100f;
			}
		}
	}

	IEnumerator spawnStage1()
	{
		Instantiate (stages[0].bamboo[0], spawnPoint, Quaternion.identity);
		_stage1canSpawn = false;
		yield break;
	}
		

}
