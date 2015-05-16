using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour 
{
    public Mesh[] meshes;
    public Material material;
    public int maxDepth;
    public float childScale;
    public float spawProbability;
    public float maxRotationSpeed;

    private int depth;
    private float rotationSpeed;
    private Vector3 startPosition;

    private static Vector3[] childDirections = {
                                                   Vector3.up,
                                                   Vector3.right,
                                                   Vector3.left,
                                                   Vector3.forward,
                                                   Vector3.back,
                                                   -Vector3.up
                                               };

    private static Quaternion[] childOrientations = {
                                                        Quaternion.identity,
                                                        Quaternion.Euler(10f,0f,-90f),
                                                        Quaternion.Euler(0f,0f,90f),
                                                        Quaternion.Euler(90f,0f,0f),
                                                        Quaternion.Euler(-90f,0f,10f),
                                                        Quaternion.Euler(-90f,0f,-10f)

                                                    };

	// Use this for initialization
	void Start () 
    {
        //Set random rotation Speed
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);

        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0,meshes.Length)];
        gameObject.AddComponent<MeshRenderer>().material = material;

        if(depth < maxDepth)
        {
            //new GameObject("Fractal Child").AddComponent<Fractal>().Init(this, Vector3.up);
            //new GameObject("Fractal Child").AddComponent<Fractal>().Init(this, Vector3.right);
            StartCoroutine(CreateChildren());

        }

        //Sinus movement
        startPosition = transform.position;
	}
	
    private void Init(Fractal parent, int childIndex)
    {
        maxRotationSpeed = parent.maxRotationSpeed;
        spawProbability = parent.spawProbability;
        meshes = parent.meshes;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        childScale = parent.childScale;
        transform.localScale = Vector3.one * childScale;
        //  transform.localPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)) + childDirections[childIndex] * (1f + 1f * childScale);
        transform.localPosition = childDirections[childIndex] * (1f + 1f * childScale);

        transform.localRotation = childOrientations[childIndex];

       // transform.localScale = Vector3.zero;
        if (transform.gameObject.GetComponent<AnimateScale>() != null)
          transform.gameObject.GetComponent<AnimateScale>().targetScale = childScale;


    }

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
        {
            if (Random.value < spawProbability)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                GameObject g = new GameObject("Fractal Child");
                g.AddComponent<Fractal>().Init(this, i);
                g.AddComponent<AnimateScale>();
            }
        }

    }

	// Update is called once per frame
	void Update () {

        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
       // transform.position = startPosition + new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), 0f);
	}
}
