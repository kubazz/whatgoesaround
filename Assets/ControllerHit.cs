using UnityEngine;
using System.Collections;

public class ControllerHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log("hit");
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles")) {
			Debug.Log("hit2");
			//Application.LoadLevel(Application.loadedLevel);
		}
		
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		   
	}
}
