using UnityEngine;
using System.Collections;

public class AnimateScale : MonoBehaviour {

    public float targetScale = 0.5f;
    public float currentScale = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        currentScale += (targetScale - currentScale) / 10f * Time.deltaTime;
        this.transform.localScale = Vector3.one * currentScale;

        if (currentScale > targetScale)
        {
            currentScale = targetScale;
            this.transform.localScale = Vector3.one * currentScale;
            GameObject.Destroy(this);
        }
	
	}
}
