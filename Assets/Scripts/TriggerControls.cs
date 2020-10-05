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

    
    //Perform whatever is assigned in the unity field when entering a collider
    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter.Invoke();
        Debug.Log("Triggered");
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
}
