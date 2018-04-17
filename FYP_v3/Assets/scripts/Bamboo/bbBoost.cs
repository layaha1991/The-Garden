using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbBoost : MonoBehaviour {

	public static bbBoost Instance;

	public float bbBoostCount;

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
