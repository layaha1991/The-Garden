using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : MonoBehaviour {

	[SerializeField]
	private float distance;
	[SerializeField]
	private GameObject energy;

	[SerializeField]
	private bool isMouseDrag;
	[SerializeField]
	private bool isSpawnEnergyCalled;
	[SerializeField]
	private float elapsed =0f;
	[SerializeField]
	private float _selfScale;

	public float zenPower;


	void Start()
	{

	}

	void Update()
	{
		boundPlayer ();

		if (Input.GetMouseButtonUp (0)) 
		{
			isMouseDrag = false;
		}

		if (isMouseDrag == true) {
			elapsed += Time.deltaTime;
			if (elapsed >= 1f) {
				elapsed = elapsed % 1f;
				spawnEnergy ();
			}
		}
	}

	//boundaries for the self object

	private void boundPlayer()
	{
		if (transform.position.x > 38.3f) {
			transform.position = new Vector3 (38.3f, transform.position.y, 0);
		} else if (transform.position.x < 21.6f) {
			transform.position = new Vector3 (21.6f, transform.position.y, 0);
		}
		if (transform.position.y > 5f) {
			transform.position = new Vector3 (transform.position.x, 5f, 0);
		} else if (transform.position.y < -3f) {
			transform.position = new Vector3 (transform.position.x, -3f, 0);
		}

	}



	private void scaleSystem()
	{
		transform.localScale
	}

	private void OnMouseDrag ()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = objPosition;
		isMouseDrag = true;
	}﻿	


	public static Vector3 RandomPointOnUnitCircle(float radius)
	{
		float angle = Random.Range (0f, Mathf.PI * 2);
		float x = Mathf.Sin (angle) * radius;
		float y = Mathf.Cos (angle) * radius;
		float z = 0;
		return new Vector3 (x, y,z);
	}

	private void spawnEnergy()
	{
		float randomRadius = Random.Range (2f,5f);
		Vector3 rpoc = transform.position + RandomPointOnUnitCircle (randomRadius);
		Instantiate (energy,rpoc , Quaternion.identity);

	}

	// Random.insideUnitCircle.normalized

	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "ZenPower") 
		{
			Destroy (col.gameObject);
			zenPower += 1;
			_selfScale += 1;
		}
	}




}
