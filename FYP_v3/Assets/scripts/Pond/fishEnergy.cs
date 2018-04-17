using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishEnergy : MonoBehaviour {


	public ParticleSystem peSystem;
	float counter =0f;
	Vector3 pos;

	void Start ()
	{
		pos = new Vector3 (Random.Range (-.2f, .2f), Random.Range (-.2f, .2f), 0);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (pos * Time.deltaTime);
		self_PESystem ();
		Destroy (this.gameObject, 3f);

	}

	
	public void self_PESystem()
		{
			ParticleSystem.MainModule psMain = peSystem.main;
			ParticleSystem.ShapeModule psShape = peSystem.shape;
			peSystem.startLifetime += 0.1f;
			peSystem.startSpeed += 0.015f;
			peSystem.startSize += 0.015f;
		}
		
}


