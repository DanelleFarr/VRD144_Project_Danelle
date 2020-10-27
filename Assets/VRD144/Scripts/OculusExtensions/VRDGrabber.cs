using System.Collections.Generic;
using UnityEngine;

public class VRDGrabber : OVRGrabber
{
    protected override void MoveGrabbedObject(Vector3 pos, Quaternion rot, bool forceTeleport = false)
    {
        if (m_grabbedObj == null)
        {
            return;
        }

        Rigidbody grabbedRigidbody = m_grabbedObj.grabbedRigidbody;
        Vector3 grabbablePosition = pos + rot * m_grabbedObjectPosOff;
        Quaternion grabbableRotation = rot * m_grabbedObjectRotOff;

        float xRot = grabbableRotation.eulerAngles.x;
        float yRot = grabbableRotation.eulerAngles.y;
        float zRot = grabbableRotation.eulerAngles.z;

        if ((grabbedRigidbody.constraints & RigidbodyConstraints.FreezeRotationX) != RigidbodyConstraints.None)
        {
            xRot = grabbedRigidbody.rotation.x;
        }

        if ((grabbedRigidbody.constraints & RigidbodyConstraints.FreezeRotationY) != RigidbodyConstraints.None)
        {
            yRot = grabbedRigidbody.rotation.y;
        }

        if ((grabbedRigidbody.constraints & RigidbodyConstraints.FreezeRotationZ) != RigidbodyConstraints.None)
        {
            zRot = grabbedRigidbody.rotation.z;
        }

        grabbableRotation = Quaternion.Euler(xRot, yRot, zRot);

        if (forceTeleport)
        {
            grabbedRigidbody.transform.position = grabbablePosition;
            grabbedRigidbody.transform.rotation = grabbableRotation;
        }
        else
        {
            grabbedRigidbody.MovePosition(grabbablePosition);
            grabbedRigidbody.MoveRotation(grabbableRotation);
        }
    }
}

