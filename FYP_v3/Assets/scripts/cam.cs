using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {

	public float counter;
	// Use this for initialization
	void Start () {
		Camera.main.transform.position = new Vector3 (930f, 60f, 109f);
		Camera.main.orthographicSize = 100f;
		Camera.main.transform.rotation = Quaternion.Euler (50f, -180f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter < 4f) 
		{
			Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 50, Time.deltaTime/2 );
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (15f, -180f, 0f), Time.deltaTime/2 );
		} 
		if (counter > 4f && counter < 10f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (980f, 60f, 0f), Time.deltaTime/8);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (25f, -140f, 0f), Time.deltaTime/8 );
		}
		if (counter > 10f && counter < 16f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (1020f, 60f, 0f), Time.deltaTime/8);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (25f, -100f, 0f), Time.deltaTime/8);
		}
		if (counter > 16f && counter < 22f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (980f, 90f, -80f), Time.deltaTime/8);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (40f, -60f, 0f), Time.deltaTime/8 );
		}
		if (counter > 22f && counter < 28f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (920f, 120f, 0f), Time.deltaTime/8);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (60f, -20f, 0f), Time.deltaTime/8);
		}
		/**if (counter > 16f && counter < 19f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (920f, 150f, 0f), Time.deltaTime/4);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (80f, 20f, 0f), Time.deltaTime/4 );
		}
		if (counter > 19f && counter < 22f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (946f, 120f, 0f), Time.deltaTime/4);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (60f, 50f, 0f), Time.deltaTime/4 );
		}
		if (counter > 22f && counter < 25f) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (920f, 90f, 0f), Time.deltaTime/4);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (40f, 80f, 0f), Time.deltaTime/4 );
		}**/

	}
}
