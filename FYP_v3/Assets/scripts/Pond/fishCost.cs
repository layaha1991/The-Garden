using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishCost : MonoBehaviour {

	public Text fishCostText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fishCostText.text = "Cost: " + GameObject.Find ("spawnFishButton").GetComponent<spawnFish> ().fishCost;
	}
}
