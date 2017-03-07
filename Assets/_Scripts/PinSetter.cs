using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour
{
    public Pin[] pinPrefabs;

    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.GetComponent<Rigidbody>().isKinematic = true;
                pin.transform.rotation = Quaternion.Euler(270, 0, 0);   
            }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public void ResetPins()
    {
        foreach (Pin pin in pinPrefabs)
        {
            Pin newPin = Instantiate(pin);
            newPin.transform.position += transform.FindChild("Pins").position;
            newPin.transform.parent = transform.FindChild("Pins");
            newPin.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.TIDY)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.RESET)
        {
            GameObject.FindObjectOfType<PinCounter>().Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.ENDTURN)
        {
            GameObject.FindObjectOfType<PinCounter>().Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.ENDGAME)
        {
            throw new UnityException("Dont know how to end game!");
        }
    }

    public void EnableControls()
    {
        GameObject.FindObjectOfType<DragLaunch>().controlEnabled = true;
    }

    public void DisableControls()
    {
        GameObject.FindObjectOfType<DragLaunch>().controlEnabled = false;
    }
}
