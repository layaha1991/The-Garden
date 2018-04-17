using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnFish : MonoBehaviour {
	[SerializeField]
	private GameObject _koi;


	private float fishNum;
	public float fishCost;

	private GameObject blocker;
	void Start()
	{

		fishCost = 200f;
	}
		


	void Update()
	{
		
	}

	public void spawnTheFish()
	{
		fishCost = Mathf.Round (200f * Mathf.Pow (1.15f, fishNum));
		if (CurrencyManager.Instance.water >= fishCost  && fishNum < 10f) {
			CurrencyManager.Instance.water -= fishCost;
			Instantiate (_koi, new Vector3 (Random.Range(54f,66f), Random.Range(-2f,4f), 0f), Quaternion.Euler (0, 0, Random.Range (0, 360)));
			fishNum += 1;

		}
	}
}
