using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {

	public static cameraManager Instance;
	public Animator fadeIn;

	public GameObject fade_animation;

	//zooming
	private bool isZoomedWaterWheel = false;
	private bool isZoomedBamboo = false;
	private bool isZoomedFishPond = false;
	private bool isZoomedTemple = false;

	public bool isMainScene = false;

	//triggerUI
	public bool shouldTriggerWaterWheelUI;


	private Vector3 waterWheelPos;
	private Vector3 bambooPos;
	private Vector3 fishPondPos;
	private Vector3 templePos;

	private float counter1;
	private float counter2;
	private float counter3;
	private float counter_IsMainScene;


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
		Camera.main.transform.position = new Vector3 (-120f, 1f, -10f);
		Camera.main.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		Camera.main.orthographicSize = 12f;
		waterWheelPos = new Vector3 (870f,53.5f,84.5f);
		templePos = new Vector3 (929.85f, 28.7f, 104f);
		fishPondPos = new Vector3 (934f, 57f, 100f);
		bambooPos = new Vector3 (-5.5f, -2.8f, -10f);
	}



	void Update()
	{
		mainSceneTrigger ();
		waterWheelZoomFunction ();
		bambooZoomFunction ();
		fishPondZoomFunction ();
		templeZoomFunction ();
		mainSceneAni ();


	}
		

   	private void mainSceneTrigger()
	{
		if (Input.GetMouseButtonDown (0)) {
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				//If something was hit, the RaycastHit2D.collider will not be null.
				if (hit.collider != null) {
					if (hit.collider.tag == "waterWheel") {
						if (isZoomedWaterWheel == false) {
							isZoomedWaterWheel = true;
							shouldTriggerWaterWheelUI = true;

						}

					} else if (hit.collider.tag == "bambooGround") {
						if (isZoomedBamboo == false) {
							isZoomedBamboo = true;
						}

			
					} else if (hit.collider.tag == "fishPond") 
					{
						if (isZoomedFishPond == false) {
							isZoomedFishPond = true;
						}
					}

					if (hit.collider.tag == "temple") 
					{
						if (isZoomedTemple == false)
						{
							isZoomedTemple = true;
							
						}

					}
				}

			}
		}
	}




	private void fading()
	{
		var fade = Instantiate (fade_animation, GameObject.Find("Canvas_game").transform.position, Quaternion.identity);
		fade.transform.parent = GameObject.Find("Canvas_game").transform;
		fadeIn.Play ("fade_animation");
		Destroy (GameObject.FindGameObjectWithTag ("fade_animation"), 1f);
	}


	private void waterWheelZoomFunction()
	{
		if (isZoomedWaterWheel == true) 
		{
			waterWheelZoom ();

			counter1 += Time.deltaTime;
			if (counter1 > 1.2f) 
			{
				isZoomedWaterWheel = false;
				counter1 = 0f;
			}

		}
	}
	private void bambooZoomFunction()
	{
		if (isZoomedBamboo == true) 
		{
			bambooZoom();
			counter2 += Time.deltaTime;
			if (counter2 > 1.2f) 
			{
				isZoomedBamboo = false;
				counter2 = 0f;
			}

		}
	}
	private void fishPondZoomFunction()
	{
		if (isZoomedFishPond== true) 
		{
			fishPondZoom ();
			counter3 += Time.deltaTime;
			if (counter3 > 1.2f) 
			{
				isZoomedFishPond = false;
				counter3 = 0f;
			}

		}
	}

	private void templeZoomFunction()
	{
		if (isZoomedTemple== true) 
		{
			templeZoom();
			counter3 += Time.deltaTime;
			if (counter3 > 2.5f) 
			{
				isZoomedTemple = false;
				counter3 = 0f;
				//fading ();
				Camera.main.orthographicSize = 12f;
				Camera.main.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
				Camera.main.transform.position = new Vector3 (-180f, 1f, -10f);
			}

		}
	}

	private void waterWheelZoom()
	{
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 15 , Time.deltaTime * 4f);
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, waterWheelPos, Time.deltaTime * 4f);
		Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (30f, -180f, 0f), Time.deltaTime * 4f);
	}
	private void bambooZoom()
	{
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 15 , Time.deltaTime * 4f);
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, bambooPos, Time.deltaTime * 4f);
	}
	private void fishPondZoom()
	{
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 36f , Time.deltaTime * 4f);
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, fishPondPos, Time.deltaTime * 4f);
		Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (50f, -180f, 0f), Time.deltaTime * 4f);
	}

	private void templeZoom()
	{
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 0 , Time.deltaTime * 2f);
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, templePos, Time.deltaTime * 2f);
		Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.Euler (0f, -180f, 0f), Time.deltaTime * 2f);
	}

	private void mainSceneAni()
	{
		if (isMainScene ==true)
		{
			Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 80 , Time.deltaTime * 1.5f);
			counter_IsMainScene += Time.deltaTime;
			if (counter_IsMainScene > 1.2f) 
			{
				isMainScene = false;
			}
		}
	}
}

