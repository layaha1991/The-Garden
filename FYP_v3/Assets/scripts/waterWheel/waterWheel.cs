using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterWheel : MonoBehaviour {
	public static waterWheel Instance;

	// 0 = no water  , 1 = slow water , 2= strong water
	private int [] waterFlow;	
	[SerializeField]
	public float wheelPower;
	// wheelSpeed = rotation angle
	[SerializeField]
	public float wheelSpeed;
	private float clickFactor = 1f;
	private float clickFactor_counter;
	[SerializeField]
	private float elapsed;

	[SerializeField]
	private bool isWheelStop = false;

	public float wheelSpeedUpgrade;	

	public float cpsCD;

	void Awake()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else
		{
			Destroy (gameObject);
		}
	}
      
	void Start()
	{
		GetComponent<AudioSource> ();
		wheelSpeedUpgrade = 1f;
		elapsed = 0f;
		wheelSpeedUpgrade = 1f;
		wheelPower = 0f;
		StartCoroutine (spinWheelSystem ());
		StartCoroutine (slowDown ());



	}



	void Update ()
	{


		if (wheelPower <= 0.1f) 
		{
			wheelPower = 0.1f;
		}
	
		if (wheelPower <= 0.1f)
		{
			StopCoroutine (slowDown ());
			StopCoroutine (spinWheelSystem ());
		}
		if (wheelPower > 0.1f && isWheelStop == true) {
			Invoke ("OnMouseDown",0f);
			isWheelStop = false;
		}

		clickPerSecond ();
		reActivate ();
		rotSpeed ();
		clickFactorFucntion ();

		cpsCD = (10f - (10f * waterUpgradeManager.Instance.cpsPowerUp));


	}


	private void clickPerSecond()
	{
		elapsed += Time.deltaTime;
		if (waterUpgradeManager.Instance.cpsPowerUp != 0f) 
		{
			if (elapsed >= cpsCD) {
				elapsed = elapsed % 1f;
				OnMouseDown ();
			}
		}
	}

	// the more the player click, the less water then will get per click.
	private void clickFactorFucntion ()
	{
		if (clickFactor > 50f)
		{
			clickFactor =50f;
		}
		if (clickFactor >=30f)
		{
			clickFactor_counter += Time.deltaTime;
			if (clickFactor_counter >10f)
			{
				clickFactor -= 1f;
			}
		}
		if (clickFactor >=10f && clickFactor <30f)
		{
			clickFactor_counter += Time.deltaTime;
			if (clickFactor_counter >30f)
			{
				clickFactor -= 1f;
			}
		}
		if (clickFactor >=2f && clickFactor <10f)
		{
			clickFactor_counter += Time.deltaTime;
			if (clickFactor_counter >180f)
			{
				clickFactor -= 1f;
			}
		}
	}

	private void OnMouseDown()
	{
		//how often does the player needs to click
		wheelPower += 50 * (1/clickFactor);
		clickFactor += 1;
		if (isWheelStop == true)
		{
				StartCoroutine (spinWheelSystem ());
				StartCoroutine (slowDown ());
				isWheelStop = false;
		}
	}


	private void rotSpeed()
	{

		if (wheelPower == 0.1f)
		{
			wheelSpeed = 0f* wheelSpeedUpgrade;
		}

		else if (wheelPower > 0.1f && wheelPower < 100f) 
		{
			wheelSpeed = (wheelPower/15) * wheelSpeedUpgrade;
		}
		/**if (wheelPower > 0.1f && wheelPower < 30f) 
		{
			wheelSpeed = 2f *wheelSpeedUpgrade;
		}
		if (wheelPower >= 30f && wheelPower <80f ) 
		{
			wheelSpeed = 4f * wheelSpeedUpgrade;
		}

		if (wheelPower >= 80f)
		{
			wheelSpeed = 6f*wheelSpeedUpgrade;
		}**/
		if (wheelPower >= 100f)
		{
			wheelPower = 100f;
		}
	}
		

	IEnumerator spinWheelSystem()
	{
		wheelSpeed = 2f;
		while (wheelSpeed >0.1f) 
		{
			transform.Rotate (0, 0, wheelSpeed/2f);
			yield return new WaitForSeconds (0.05f);
		}
	}
					
	IEnumerator slowDown()
	{
		while (wheelPower > 0.1f) 
		{
				wheelPower -= 0.5f;
				yield return new WaitForSeconds (0.1f);
		}
	
	}


	private void reActivate()
	{

		if (wheelPower <= 0.1f) 
		{
			isWheelStop = true;
		}

	}




}