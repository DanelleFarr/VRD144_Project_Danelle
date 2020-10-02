using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInput : MonoBehaviour
{
    [SerializeField]
    private GameObject receiver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (receiver != null)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<GameObject>() != null)
        {
            receiver = other.GetComponent<GameObject>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject target = other.GetComponent<GameObject>();
        if (target != null && target == receiver)
        {
            receiver = null;
        }
    }


}
