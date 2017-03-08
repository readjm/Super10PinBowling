using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{
    private const int BUFFER_SIZE = 600;

    private List<MyKeyFrame> keyFrames;
    //private MyKeyFrame[] keyFrames;
    private Rigidbody rigidBody;
    private Ball ball;
    private Pin[] pins;

    // Use this for initialization
    void Start()
    {
        keyFrames = new List<MyKeyFrame>();
        //pins = new Pin[10];
        //keyFrames = new MyKeyFrame[BUFFER_SIZE];
        rigidBody = GetComponent<Rigidbody>();
        ball = GameObject.FindObjectOfType<Ball>().GetComponent<Ball>();

        pins = GameObject.FindObjectsOfType<Pin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.inPlay)
        {
            Record();
        }
    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        transform.position = keyFrames[Time.frameCount % BUFFER_SIZE].position;
        transform.rotation = keyFrames[Time.frameCount % BUFFER_SIZE].rotation;
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        keyFrames[Time.frameCount % BUFFER_SIZE] = new MyKeyFrame(Time.time, rigidBody.transform.position, rigidBody.transform.rotation);
    }
}

public struct MyKeyFrame
{
    public float time;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float t, Vector3 pos, Quaternion rot)
    {
        time = t;
        position = pos;
        rotation = rot;
    }

    public void Set(float t, Vector3 pos, Quaternion rot)
    {
        time = t;
        position = pos;
        rotation = rot;
    }
}