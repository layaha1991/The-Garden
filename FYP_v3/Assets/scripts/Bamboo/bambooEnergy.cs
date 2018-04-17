using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bambooEnergy : MonoBehaviour {

	//private spawnStages _sStages;
	private float speed;
	public GameObject bundle;




	private spawnStages _spawnStages;

	void Start () {
		//_sStages = GameObject.Find ("bambooGrowManager").GetComponent<spawnStages> ();
		speed = 0.5f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (0, speed * Time.deltaTime, 0);
	}

	void OnMouseDown()
	{
		CurrencyManager.Instance.bambooEnergy += Random.Range (50f,100f);
		bbBoost.Instance.bbBoostCount += 0.01f;
		Destroy (bundle);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "bambooEnergyBoundary") 
		{
			speed *= -1f ;
		}
	}


}
