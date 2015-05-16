using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class changingColors : MonoBehaviour {

	public List<Color> backGroundColors;
	public List<Color> obstaclesColors;
	public List<Color> fractalColors;

	public Material backGroundMaterial;
	public Material obstacleMaterial;
	public Material fractalMaterial;

	private float tempTime;
	int colorID = 0;

	public static float speed = 0.5f;

	Color oldColorBackGround;
	Color newcolorBackGround;
	Color oldcolorFractal;
	Color newcolorFractal;



	// Use this for initialization
	void Start () 
	{
		speed = 0.5f;
		oldColorBackGround = backGroundColors [0];
		newcolorBackGround = backGroundColors [1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempTime += Time.deltaTime * speed;

		//if (tempTime > 2f) {
		GetComponent<Camera>().backgroundColor = Color.Lerp (oldColorBackGround, newcolorBackGround, tempTime);
		//fractalMaterial.color = Color.Lerp (oldcolorFractal, newcolorFractal, tempTime);
		//}

		if (tempTime > 1) {
			colorID++;
			colorID %= 3;
			oldColorBackGround = newcolorBackGround;
			newcolorBackGround = backGroundColors[colorID];
			tempTime = 0f;
		}
	}
}
