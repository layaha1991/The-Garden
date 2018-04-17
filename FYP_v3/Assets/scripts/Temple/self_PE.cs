using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_PE : MonoBehaviour {


	public ParticleSystem peSystem;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 public void self_PositivePEScaleSystem()
	{
		ParticleSystem.MainModule psMain = peSystem.main;
		ParticleSystem.ShapeModule psShape = peSystem.shape;
		peSystem.startLifetime += 0.001f;
		peSystem.startSpeed += 0.0003f;
		peSystem.startSize += 0.0003f;
	}
	public void self_NegativePEScaleSystem()
	{
		ParticleSystem.MainModule psMain = peSystem.main;
		ParticleSystem.ShapeModule psShape = peSystem.shape;
		peSystem.startLifetime -= 0.01f;
		peSystem.startSpeed -= 0.003f;
		peSystem.startSize -= 0.003f;
	}
}
