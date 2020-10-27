using UnityEngine;
using UnityEngine.Events;

public class VRDGlobalTouchInputTracker : MonoBehaviour
{
    private static VRDGlobalTouchInputTracker instance;
    [SerializeField]
    private UnityEvent onMenuButton = new UnityEvent();

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // MenuButton
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            onMenuButton.Invoke();
        }

        // A Button
        if (OVRInput.GetDown(OVRInput.Button.One))
        {

        }

        // B Button
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {

        }

        // X Button
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {

        }

        // Y Button
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {

        }

        // Left Trigger
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {

        }

        // Right Trigger
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

        }

        // Left Grip
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {

        }

        // Right Grip
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {

        }
    }


}
