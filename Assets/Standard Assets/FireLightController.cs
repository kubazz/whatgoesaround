using UnityEngine;
using System.Collections;

public class FireLightController : MonoBehaviour {

	Color baseColor;
	float baseRange;
	float baseAngle;
	// Use this for initialization
	void Start () {
		baseColor = GetComponent<Light> ().color;
		baseRange = GetComponent<Light> ().range;
		baseAngle = GetComponent<Light> ().spotAngle;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Light> ().range = baseRange + Random.Range (0.0f, 4.1f);
		GetComponent<Light> ().spotAngle = baseAngle + Random.Range (0.0f, 10.1f);
		GetComponent<Light> ().color = baseColor + new Color(Random.Range(0.0f, 0.1f),Random.Range(0.0f, 0.1f),Random.Range(0.0f, 0.1f));
	}
}
