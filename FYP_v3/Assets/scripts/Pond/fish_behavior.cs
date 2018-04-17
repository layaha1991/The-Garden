using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_behavior : MonoBehaviour {

	public float fishSpeed;
	public GameObject koi;
	public float fishSize;
	public float elapsed =0f;
	public float countFish;
	public GameObject fishEnergy;
	public GameObject fishFood;
	//private Vector3 _lookingPoint;
	public Vector2 fishFoodPosition;




	void Start () {
		StartCoroutine("fishSwimRoutine");
		fishSpeed = 6f;

		//Vector3 _lookingPoint = _fishPond.center - transform.position;
	
	}


	void Update () 
	{
		//transform.localRotation = Quaternion.Euler (0.01f,0f,0f);
		fishEnergySpawning ();
		if (countFish > 30f) 
		{
			countFish = 31f;
		}
	}


	private void fishEnergySpawning()
	{
		if (countFish == 30f)
		{
			StartCoroutine ("fishSpawnEnergyRoutine");
			countFish = 31f;
		}
		//after 30s it will be mature and spawn energy
		if (countFish < 30f) 
		{
			elapsed += Time.deltaTime;
			if (elapsed >= 5f) 
			{
				transform.localScale += new Vector3 (0.01f, 0.01f, 0f);
				elapsed = elapsed % 1f;
			
			}
		}
	}


		
	private IEnumerator fishSwimRoutine()
	{
		while (true) 
		{

				// rigidbody.addforce
				transform.Translate (0, Time.deltaTime * fishSpeed, 0);
				yield return new WaitForSeconds (0.05f);

		}
	}
		

	void OnTriggerEnter (Collider col)
	{
		if (col.tag =="fishPond")
		{
			float angle = Random.Range (160f, 200f);
			transform.Rotate (0f, 0f, angle);
			fishSpeed = Random.Range (1f, 2.5f);

			Debug.Log ("1");
			//transform.rotation = Quaternion.Slerp (transform.rotation , Quaternion.LookRotation (_lookingPoint), Time.deltaTime * 5);
		}
		if (col.tag== "FishFood" & countFish <= 30f) {
			transform.localScale += new Vector3 (0.01f, 0.01f, 0f);
			countFish++;
			Destroy (col.gameObject);
		}

			
	}
	private IEnumerator fishSpawnEnergyRoutine()
	{
		while(true)
		{
			CurrencyManager.Instance.water += 50f;
			fishManager.Instance.fishEnergyBoost++;
			Instantiate (fishEnergy , transform.position , Quaternion.Euler (0,0,Random.Range(0f,360f)));
			yield return new WaitForSeconds (5f);
		}
	}
	// transform.rotation = Quaternion.Slerp (

	/**private void eatFishFood()
	{
		if (_sff.fishFoodExist == true)
		{
			fishFoodPosition = new Vector2 (_sff.worldPoint.x, _sff.worldPoint.y);
			transform.position = Vector2.MoveTowards(transform.position,fishFoodPosition, speed * Time.deltaTime);

		}
	}**/



}
