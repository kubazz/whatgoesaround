using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerHit : MonoBehaviour {
	public float score;
	public Text text;
	public Image image;

	private bool gameOver = false;
	// Use this for initialization
	void Start () 
	{
		score = 0f;
		gameOver = false;
		image.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (!gameOver) 
		{
			score += 0.05f;
		}
	
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log("hit");
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles")) 
		{
			Debug.Log("hit2");
			//Application.LoadLevel(Application.loadedLevel);
			image.enabled =true;
			text.text = "Scoreeee " + score;
			gameOver = true;
		}
		
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		   
	}
}
