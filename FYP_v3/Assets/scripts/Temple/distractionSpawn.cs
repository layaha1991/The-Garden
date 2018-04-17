using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distractionSpawn : MonoBehaviour {

	public GameObject distraction;

	public float counter;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find ("Self").GetComponent<Self> ().isMouseDrag == true) {
			counter += Time.deltaTime;
			if (counter >= Random.Range(6f,10f)) {
				if (CurrencyManager.Instance.water >= GameObject.Find ("Self").GetComponent<Self> ().zenPowerCost) {
					spawnDistraction ();
					counter = 0f;
				}
			}
		}else
			{
				counter = 0f;
			}

	}

	public static Vector3 RandomPointOnUnitCircle(float radius)
	{
		float angle = Random.Range (0f, Mathf.PI * 2);
		float x = Mathf.Sin (angle) * radius;
		float y = Mathf.Cos (angle) * radius;
		float z = 0;
		return new Vector3 (x, y,z);
	}
	private void spawnDistraction()
	{
		
		float randomRadius = Random.Range (10f,15f);
		Vector3 rpoc = transform.position + RandomPointOnUnitCircle (randomRadius);
		Instantiate (distraction,rpoc , Quaternion.identity);

	}
}
