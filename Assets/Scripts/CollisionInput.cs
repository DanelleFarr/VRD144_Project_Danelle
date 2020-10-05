using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionInput : MonoBehaviour
{

    [SerializeField]
    UnityEvent CollisionEnter;
    [SerializeField]
    UnityEvent CollisionExit;
    [SerializeField]
    UnityEvent CollisionStay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        CollisionStay.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        CollisionExit.Invoke();
    }
}
