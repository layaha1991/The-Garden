using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_fishfood : MonoBehaviour {

	public GameObject fishFoodPrefab;
	//public bool fishFoodExist;

	void Start()
	{
	}
	void Update()
	{
		
		//spawnFishFood ();
	}











	/**private void spawnFishFood()
	{
		if (Input.GetMouseButtonDown (0)) {
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {
				if (hit.collider.name == "FishPond") {
					if (>= 5f)
					{
					Instantiate (fishFoodPrefab, worldPoint, Quaternion.identity);
						UIManager.Instance._newEnergy -= 5f;
					//fishFoodExist = true;
						Destroy(fishFoodPrefab,20f);
					}
				}
			}
		}
	}**/
		
}
