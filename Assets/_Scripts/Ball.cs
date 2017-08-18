using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    //public float speed = 0;
    public float launchVelocityModifier = 1f;
    public bool inPlay = false;

    public AudioSource ballRoll;
    public AudioSource ballStrike;
    public Material[] ballMaterials;

    private Rigidbody rb;
    private Vector3 startPosition;

    // Use this for initialization
    void Start ()
    {
        //ballRoll = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        startPosition = transform.position;
	}
	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            ballRoll.Play();
        }
        if (collision.gameObject.GetComponent<Pin>())
        {
            ballStrike.Play();
        }
    }
    
    public void Launch(Vector3 velocity)
    {
        rb.useGravity = true;
        rb.velocity = velocity*launchVelocityModifier;
        inPlay = true;
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        inPlay = false;
    }

    public void SetMaterial(int ballIndex)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && ballIndex < ballMaterials.Length)
        {
            renderer.material = ballMaterials[ballIndex];
        }

    }

    public void SetMaterial(Material newBallMaterial)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newBallMaterial;
        }

    }
}