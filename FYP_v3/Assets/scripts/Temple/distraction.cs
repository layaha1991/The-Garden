using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distraction : MonoBehaviour {

	public GameObject self;
	public GameObject zenPower;
	private float self_zenPower;
	private float distractionSpeed;
	[SerializeField]
	private Text distractionHealthText;

	[SerializeField]
	private float health;


	void Start()
	{




		StartCoroutine ("distractionSpeedUpRoutine");
		if (self_zenPower > 0f && self_zenPower <= 20f) 
		{
			health = 5 - fishManager.Instance.fishEnergyBoost;
			if (health < 3) 
			{
				health = 3;
			}
			distractionSpeed = (0.10f - bbBoost.Instance.bbBoostCount);
			if (distractionSpeed < 0.03f)
			{
				distractionSpeed = 0.03f;
			}
		} 
		else if (self_zenPower > 20f && self_zenPower <= 40f) 
		{
			health = 15 - fishManager.Instance.fishEnergyBoost;
			if (health < 3) 
				{
					health = 3;
				}
			distractionSpeed = (0.20f - bbBoost.Instance.bbBoostCount);
			if (distractionSpeed < 0.03f)
			{
				distractionSpeed = 0.03f;
			}
		} 
		else if (self_zenPower > 40f && self_zenPower <= 60f) 
		{
			
			health = 25 - fishManager.Instance.fishEnergyBoost;
			if (health < 3) 
			{
				health = 3;
			}
			distractionSpeed = (0.35f - bbBoost.Instance.bbBoostCount);
			if (distractionSpeed < 0.04f)
			{
				distractionSpeed = 0.04f;
			}
		} 
		else if (self_zenPower > 60f) 
		{
			
			health = 40 - fishManager.Instance.fishEnergyBoost;
			if (health < 3) 
			{
				health = 3;
			}
			distractionSpeed = (0.50f - bbBoost.Instance.bbBoostCount);
			if (distractionSpeed < 0.05f)
			{
				distractionSpeed = 0.05f;
			}
		}
		Destroy (gameObject, 60f);
	}

	void Update()
	{
		transform.position = Vector3.MoveTowards (transform.position, GameObject.FindGameObjectWithTag ("Self").transform.position, distractionSpeed);
		distractionHealthText.text = ""+health;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag =="ash")
		{
			if (health >= 2) 
				{
				health -= 1;

				ashhit();
				Destroy (col.gameObject);
				}
			if (health == 1) 
				{
				health -= 1;

				distractionDead();
				Destroy (col.gameObject);
				Destroy (this.gameObject);

				}
		}
	}
	private void ashhit()
	{
		Instantiate (zenPower, transform.position, Quaternion.identity);
	}

	private void distractionDead()
	{
		
		GameObject.Find ("Self").GetComponent<Self> ().spawnEnergyCoolDown *= 0.95f;
		GameObject.Find ("Self").GetComponent<Self> ().zenPowerCost *= 0.95f;
	}
	IEnumerator distractionSpeedUpRoutine()
	{
		while(distractionSpeed <=0.2f)
		{
			distractionSpeed += 0.003f;

			yield return new WaitForSeconds (0.5f);
		}
	}
}
