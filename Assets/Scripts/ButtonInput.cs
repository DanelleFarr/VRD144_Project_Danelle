using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public bool acceptBtnInput = false;

    [SerializeField]
    GameObject[] instrumentsArray = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {
        acceptBtnInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(acceptBtnInput == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Debug.Log("Button A");
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
        }//end update
    }

    public void AcceptInput()
    {
        acceptBtnInput = true;
    }//end AcceptInput()

    public void RejectInput()
    {
        acceptBtnInput = false;
    }//end RejectInput()
}
