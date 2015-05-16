using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
