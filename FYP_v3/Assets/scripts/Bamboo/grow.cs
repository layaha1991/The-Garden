using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour {


	private float growAmount;
	private float growTime;
	private float growScale;
	private float timeCounter;

	public bool grown = false;

	void Awake()
	{
		transform.localScale = new Vector3 (0, 0, 0);
	}


	void Start()
	{
		growTime = 2f;
		growAmount = 0.2f;
		growScale = 0f;
	}

	// Use this for initialization
	void Update () 
	{
		if (timeCounter <= growTime) {
			timeCounter += Time.deltaTime;
			growScale += growAmount/growTime*Time.deltaTime;
			transform.localScale = new Vector3 (growScale, growScale, growScale);	 
		}

		else
			grown = true;
			
	}


}
