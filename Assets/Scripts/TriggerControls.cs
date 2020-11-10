using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerControls : MonoBehaviour
{
    //Fields, placing them in the Unity Editor where I can assign them
    [SerializeField]
    UnityEvent TriggerEnter;
    [SerializeField]
    UnityEvent TriggerExit;
    [SerializeField]
    UnityEvent TriggerStay;

    [SerializeField]
    private Collider[] acceptedColliders;

    
    //Perform whatever is assigned in the unity field when entering a collider
    private void OnTriggerEnter(Collider other)
    {
        if (IsAccepted(other))
        {
            TriggerEnter.Invoke();
        }//end if IsAccepted
    }

    //Perform whatever is assigned in the unity field when exiting a collider
    private void OnTriggerExit(Collider other)
    {
        TriggerExit.Invoke();
    }

    ////Perform whatever is assigned in the unity field when staying within a collider
    private void OnTriggerStay(Collider other)
    {
        TriggerStay.Invoke();
    }

    private bool IsAccepted(Collider other)
    {
        if (acceptedColliders.Length < 1)
        {
            return other.GetComponent<VRDControllerInputHandler>() != null;
        }

        foreach (Collider item in acceptedColliders)
        {
            if (other == item)
            {
                return true;
            }//end if ==
        }//end foreach
        return false;
    }//end IsAccepted()
}
