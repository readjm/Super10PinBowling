using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour
{
    public Text pinCounter;

    private GameManager gameManager;
    private bool ballLeftTrigger = false;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;
    private float lastChangeTime;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}

    void Update()
    {
        pinCounter.text = "Pins Remaining: " + CountStanding();

        if (ballLeftTrigger)
        {
            pinCounter.color = Color.red;
            UpdateStandingCountAndSettle();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballLeftTrigger = true;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    private void UpdateStandingCountAndSettle()
    {
        //update lastStanding count
        //Call PinsHaveSettled when they have

        if (lastStandingCount != CountStanding())
        {
            lastChangeTime = Time.time;
            lastStandingCount = CountStanding();
            return;
        }
        else if (Time.time - lastChangeTime >= 3f)
        {
            PinsHaveSettled();
        }
    }

    private int CountStanding()
    {
        int StandingPins = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                StandingPins++;
            }
        }
        return StandingPins;
    }

    private void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; //indicates new frame
        ballLeftTrigger = false;
        pinCounter.color = Color.green;
    }
}
