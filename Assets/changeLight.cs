using UnityEngine;
using System.Collections;

public class changeLight : MonoBehaviour 
{
	private Color testLight = new Color();
	private float r,g,b ;
	// Use this for initialization
	void Start () 
	{
		testLight = this.gameObject.GetComponent<Light>().color;
		Debug.Log(testLight.r);

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<Light>().color = Color.magenta;
		Debug.Log(this.gameObject.GetComponent<Light>().color.g);
	}
}
