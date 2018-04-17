using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lotus : MonoBehaviour {


	float counter =0f;
	Vector3 pos;

	void Start ()
	{
		pos = new Vector3 (Random.Range (-.1f, .1f), Random.Range (-.1f, .1f), 0);
		transform.Translate (pos * Time.deltaTime);
	}

	// Update is called once per frame
	void Update () {
		lotusBehavior ();
		transform.Translate (pos*Time.deltaTime);
	}

	private void lotusBehavior()
	{
		counter += Time.deltaTime;
		if(counter >=10)
		{
			pos = new Vector3 (Random.Range (-.1f, .1f), Random.Range (-.1f, .1f), 0);
			counter =0f;
		}
	}

}
