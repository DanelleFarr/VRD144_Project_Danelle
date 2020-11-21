using UnityEngine;
using UnityEngine.Events;

public class VRDGrabbable : OVRGrabbable
{
    public UnityEvent onGrabBeginEvent;
    public UnityEvent onGrabEndEvent;

    public bool defaultKinematic { get { return m_grabbedKinematic; } set { m_grabbedKinematic = value; } }


    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        onGrabBeginEvent.Invoke();
        base.GrabBegin(hand, grabPoint);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        onGrabEndEvent.Invoke();
        base.GrabEnd(linearVelocity, angularVelocity);
    }
}
