using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float speed = 0;
    public bool inPlay = false;

    public AudioSource ballRoll;
    public AudioSource ballStrike;
    private Rigidbody rigidbody;
    private Vector3 startPosition;
    

    // Use this for initialization
    void Start ()
    {
        //ballRoll = GetComponent<AudioSource>();

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

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
        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;
        inPlay = true;
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;

        inPlay = false;
    }
}