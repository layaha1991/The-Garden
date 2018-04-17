using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zenPower : MonoBehaviour {

	public GameObject self;
	private Self _self;

	void Start () {
		_self = GameObject.Find ("Self").GetComponent<Self>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 selfTransform = _self.transform.position;
		transform.position = Vector3.MoveTowards (this.transform.position, selfTransform , 0.07f);
	}



}
