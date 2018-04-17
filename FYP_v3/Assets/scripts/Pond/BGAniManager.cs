using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAniManager : MonoBehaviour {


	public Animator lotus_animation;
	// Use this for initialization
	void Start () {
		StartCoroutine ("lotusShine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator lotusShine()
	{
		while (true)
		{
			lotus_animation.Play ("glowingCircle_animation");
			yield return new WaitForSeconds (5f);
		}
	}
}
