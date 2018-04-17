using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialManager : MonoBehaviour {

	public TutorialText[] tutText = new TutorialText[10];

	private int tutorialCount;

	public Text tutorial_textDisplay;

	//public Animator tutTextFadeIn;
	//public Animator tutTextFadeOut;

	//public GameObject tutTextFadeIn_animation;
	//public GameObject tutTextFadeOut_animation;

	void Start()
	{
		tutorialCount = 0;
		tutText [0] = new TutorialText ("Life is Beautiful!");
		tutText [1] = new TutorialText ("Love. Family. Friends.");
		tutText [2] = new TutorialText ("And the laughter..");
		tutText [3] = new TutorialText ("But sometimes... Life can also be stressful");
		tutText [4] = new TutorialText ("Often times.... it makes people suffering!");
		tutText [5] = new TutorialText ("It consumes your beautiful life.");
		tutText [6] = new TutorialText ("without your notice...");
		tutText [7] = new TutorialText ("Welcome to the Garden");
		tutText [8] = new TutorialText ("FIND yourself in here...");
		tutText [9] = new TutorialText ("KNOW yourself in the process");
		tutText [10] = new TutorialText ("Live your life....");
		tutText [11] = new TutorialText ("Beautifully!");


	}

	// Update is called once per fram
	void Update () {
		textDisplay ();
		tutorial_textDisplay.text = tutText[tutorialCount].content;
	}

	private void textDisplay()
	{
		if (Input.GetMouseButtonDown (0)&& Camera.main.transform.position.x == -120f)
		{
			if (tutorialCount <= 10) {
				//tutTextFadeIn.Play ("tutorialText_fadeIn");

				tutorialCount++;
			}
			if (tutorialCount == 11) 
			{
				tutorialCount = 11;
				Camera.main.transform.position = new Vector3 (900f,75f,105f);
				Camera.main.transform.rotation = Quaternion.Euler (150f, 0f, 180f);
				Camera.main.orthographicSize = 100f;
				cameraManager.Instance.isMainScene = true;

				Destroy (GameObject.Find ("Canvas_tutorial"));
			}
		}
	}

	//tutorialText.text = "Tips: " + "\n Each Koi will generate 50 Energy when they growu. \n Each well-grown bamboo will generate 50 energy.";
}
