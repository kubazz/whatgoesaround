using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class Logo : MonoBehaviour {

	public Image background;
	public List<Sprite> logo;
	public List<Sprite> story;
	public static bool finished = false;

	// Use this for initialization
	void Start () {
	
	}

	int phase = 0;

	int counter = 0;
	int id = 0;
	// Update is called once per frame
	void Update () {
		if (finished) {
			GetComponent<Image> ().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			return;
		}
			
		if (phase == 0) {
			background.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			if (counter % 8 == 0) {
				GetComponent<Image> ().sprite = logo [id];
				id++;
				id %= 3;
			}

			counter++;
		} else {
			GetComponent<Image> ().sprite = story [phase - 1];
		}

		if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			phase++;
		}
		if (phase > 8) {
			GetComponent<Image> ().sprite = null;
			GetComponent<Image> ().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			background.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			finished = true;
			FindObjectOfType<rotateLevel>().speed = 30.0f;

		}
	}
}
