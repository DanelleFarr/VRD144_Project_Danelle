using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabbableBtnInput : MonoBehaviour
{
    [SerializeField]
    public bool acceptInput;
    [SerializeField]
    UnityEvent BtnADown;



    // Start is called before the first frame update
    void Start()
    {
        acceptInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (acceptInput == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Debug.Log("Button A");
                BtnADown.Invoke();
            }
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                Debug.Log("Button B");
            }
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                Debug.Log("Button X");
            }
            if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                Debug.Log("Button Y");
            }
        }//end if acceptInput==true
    } //end  Update()

    public void AcceptInput()
    {
        acceptInput = true;
    }//end AcceptInput()

    public void RejectInput()
    {
        acceptInput = false;
    }//end RejectInput()
}
