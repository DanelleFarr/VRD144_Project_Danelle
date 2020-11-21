using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRDStartButtonInput : MonoBehaviour
{
    [SerializeField]
    private OVRCameraRig cameraRig;
    // Start is called before the first frame update
    void Start()
    {
        if(cameraRig == null)
        {
            cameraRig = FindObjectOfType<OVRCameraRig>();
        }
        if(cameraRig == null)
        {
            Destroy(this);
        }
    }

    private bool doRecenter = false;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            doRecenter = true;
            
        }
    }

    private void LateUpdate()
    {
        if (doRecenter)
        {
            OVRManager.display.RecenterPose();
            doRecenter = false;
        }
    }
}
