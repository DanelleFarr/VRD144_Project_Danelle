using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;

public class TriggerControls : MonoBehaviour
{
    //Fields
    [SerializeField]
    UnityEvent TriggerEnter;
    [SerializeField]
    UnityEvent TriggerExit;
    [SerializeField]
    UnityEvent TriggerStay;

    private void OnTriggerEnter(Collider other)
    {
        TriggerExit.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExit.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStay.Invoke();
    }
}
