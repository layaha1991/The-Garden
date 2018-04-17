using System.Collections;
using UnityEngine;

public class touchManager : MonoBehaviour {

	public GameObject energy;

	Ray ray;
	RaycastHit hit;

	void Update()
	{
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			if (Input.GetMouseButtonDown(0))
			{
				Instantiate (energy, hit.point, Quaternion.identity);
			}
		}
	}
}
