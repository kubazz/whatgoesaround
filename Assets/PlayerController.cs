using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public int lane = 2;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
		//startPos = 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			lane--;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			lane++;
		}

		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		var pos = transform.position;
		pos.z += horizontal;

		pos.z = Mathf.Clamp(pos.z, 3.0f, 33.0f);
		transform.position = pos;
	}
}
