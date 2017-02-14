using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{
    public float standingThreshold;

    private AudioSource audioSource;
    private Ball ball;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<Pin>() || collision.gameObject.name == "Floor") && ball.inPlay)
        {
            audioSource.Play();
        }
    }

    public bool IsStanding()
    {
        if (Mathf.Abs(270.0f - this.transform.rotation.eulerAngles.x) < standingThreshold)
        {
            return true;
        }
        return false;
    }
}