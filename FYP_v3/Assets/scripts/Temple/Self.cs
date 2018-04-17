using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : MonoBehaviour {

	[SerializeField]
	private float distance;
	public float ashSpawnCD;
	[SerializeField]
	private GameObject energy;
	public GameObject ash;

	public float spawnEnergyCoolDown;
	public float zenPowerCost;
	[SerializeField]
	public bool isMouseDrag;
	[SerializeField]
	private bool isSpawnEnergyCalled;
	[SerializeField]
	private float elapsed =0f;





	void Start()
	{
		CurrencyManager.Instance.zenPower = 0f;
		spawnEnergyCoolDown = 1.5f;
		StartCoroutine ("ashRoutine");
		ashSpawnCD = 0.5f;
		zenPowerCost = 100f;
	}

	void Update()
	{
		boundPlayer ();

		if (Input.GetMouseButtonUp (0)) 
		{
			isMouseDrag = false;
		}

		if(CurrencyManager.Instance.bambooEnergy >=zenPowerCost)
		{
			if (isMouseDrag == true) {
				elapsed += Time.deltaTime;
				if (elapsed >= spawnEnergyCoolDown) {
					elapsed = elapsed % 1f;
					spawnEnergy ();
				}
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
		CurrencyManager.Instance.zenPower -= zenPowerCost;
	}

	// Random.insideUnitCircle.normalized

	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "ZenPower") 
		{
			Destroy (col.gameObject);
			CurrencyManager.Instance.zenPower += 1f;
			scaleSystem ();
		}
		if (col.gameObject.tag == "distraction") {
			if (CurrencyManager.Instance.zenPower>= 10f) {
				CurrencyManager.Instance.zenPower -= 10f;
				deScaleSystem ();

				Destroy (col.gameObject);
			} 
			else
			{
				CurrencyManager.Instance.zenPower = 0;
				Destroy (col.gameObject);
			}
		}
	}

	private void scaleSystem()
	{
		GameObject.Find ("self_PE").GetComponent<self_PE> ().self_PositivePEScaleSystem ();
		transform.localScale += new Vector3 (0.005f, 0.005f, 0);
	}

	private void deScaleSystem()
	{
		GameObject.Find ("self_PE").GetComponent<self_PE> ().self_NegativePEScaleSystem ();
		transform.localScale -= new Vector3 (0.05f, 0.05f, 0);
	}

	private IEnumerator ashRoutine()
	{
		while (true)
		{
			Instantiate (ash, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (ashSpawnCD);
		}
	}
}
