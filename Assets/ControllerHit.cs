using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerHit : MonoBehaviour {
	public static float score;
	public Text text;
	public Image image;

	public Image background;

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
			score += Time.deltaTime;
			changingColors.speed +=0.001f;
		}
	
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log("hit");
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles")) 
		{
			Debug.Log("hit2");
			//Application.LoadLevel(Application.loadedLevel);
			image.enabled = true;
			background.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			text.text = score.ToString("F0") + " seconds";
			gameOver = true;
		}
		
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		   
	}
}
