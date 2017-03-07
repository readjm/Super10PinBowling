using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    public float dragXscale;
    public float dragZScale;
    public bool controlEnabled = true;

    private Ball ball;
    private Vector3 dragPosStart;
    private Vector3 dragPosEnd;
    private float dragTimeStart;
    private float dragTimeEnd;

	// Use this for initialization
	void Start ()
    {
        ball = this.GetComponent<Ball>();
	}

    public void FixedUpdate()
    {
        if (ball.inPlay)
        {
            //ball.transform.Translate(Mathf.Clamp(Input.acceleration.x * .05f, 0f, 1f), 0, 0);
            //ball.GetComponent<Rigidbody>().AddForce(Mathf.Clamp(Input.acceleration.x, -1000f, 1000f), 0, 0);
            ball.GetComponent<Rigidbody>().AddForce(Input.acceleration.x * 10, 0, 0);
            //Debug.Log("X acceleration: " + Input.acceleration.x * .05f);
            //Debug.Log(Input.deviceOrientation);
        }
    }

    public void DragStart()
    {
        //Capture time and position of mouse click
        if (!ball.inPlay && controlEnabled)
        {
            dragPosStart = Input.mousePosition;
            dragTimeStart = Time.time;
        }

    }

    public void DragEnd()
    {
        //launch ball: speed = distance/time
        if (!ball.inPlay && controlEnabled)
        {
            dragPosEnd = Input.mousePosition;
            dragTimeEnd = Time.time;

            Vector3 dragDistance = dragPosEnd - dragPosStart;
            float dragTime = dragTimeEnd - dragTimeStart;

            //dragDistance.x /dragTime*0.1f
            Vector3 velocity = new Vector3(dragDistance.x / dragTime * dragXscale, 0, Mathf.Clamp(dragDistance.y / dragTime * dragZScale, 1f, 17.5f));

            ball.Launch(velocity);
        }
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.inPlay && controlEnabled)
        {
            ball.transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x + xNudge, -.525f, .525f), ball.transform.position.y, ball.transform.position.z);
        }
    }

}
