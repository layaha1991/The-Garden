using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerCD : MonoBehaviour {


	private Self _self;


	void Start () {
		_self = GameObject.Find ("Self").GetComponent<Self> ();

	}


	public void spawnPowerCDSystem()
	{
		if (CurrencyManager.Instance.water >= 100f) {
			_self.spawnEnergyCoolDown *= (0.9f);
			CurrencyManager.Instance.water -= 100f;
		}
	}
}
