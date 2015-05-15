using UnityEngine;
using System.Collections;

public class rotateLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.Rotate(0.0f,0.0f,10.0f * Time.deltaTime);
	}
}
