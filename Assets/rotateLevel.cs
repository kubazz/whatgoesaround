using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class rotateLevel : MonoBehaviour 
{
	public float speed = 10.0f;
	private float rotation = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (float.Equals (speed, 0.0f) && CrossPlatformInputManager.GetButtonDown ("Jump") && Logo.finished == true) {
			speed = 30.0f;
			ControllerHit.score = 0.0f;
		}

		float whatever = speed * Time.deltaTime;
		rotation += whatever;
		Debug.Log (speed);

		if (rotation > 360f) 
		{
			rotation = 0f;
			speed+=10;
		}
		this.gameObject.transform.Rotate(0.0f,0.0f,speed * Time.deltaTime);

	}
}
