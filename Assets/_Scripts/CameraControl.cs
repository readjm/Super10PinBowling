using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public Ball ball;

    public Vector3 cameraOffset;

    // Use this for initialization
    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        if (ball != null && ball.transform.position.z < 18.1)
        {
            transform.position = ball.transform.position + cameraOffset;
        }
	}
}
