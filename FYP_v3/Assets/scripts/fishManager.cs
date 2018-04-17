using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishManager : MonoBehaviour {


	public static fishManager Instance;

	public float fishEnergyBoost;
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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
