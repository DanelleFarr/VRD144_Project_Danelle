using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField]
    private SocketableType acceptedSocketableType;
    [SerializeField]
    private bool doTween = false;
    [SerializeField]
    private float duration = 2f;
    private Socketable socketable; 
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Try to find a socketable
        socketable = other.GetComponent<Socketable>();

        // If there isn't one, exit the method
        if(socketable == null)
        {
            return;
        }

        // If this isn't a type we accept, exit the method
        if(socketable.Type != acceptedSocketableType)
        {
            return;
        }

        // find the grabbable
        OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>();       

        if (grabbable != null && grabbable.isGrabbed)
        {
            // Whatever this grabbable is grabbed by
            // force it to release this grabbable
            grabbable.grabbedBy.ForceRelease(grabbable);
        }

        meshRenderer.enabled = false;
        socketable.GetComponent<Rigidbody>().isKinematic = true;

        if (doTween)
        {
            StartCoroutine(MoveIntoPlace(socketable.transform, duration));
        }
        else
        {
            socketable.transform.position = this.transform.position;
            socketable.transform.rotation = this.transform.rotation;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == socketable.gameObject)
        {
            meshRenderer.enabled = true;
            socketable = null;
        }
        
    }

    private IEnumerator MoveIntoPlace(Transform target, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startPos = target.position;
        Quaternion startRot = target.rotation;

        while(elapsedTime < duration)
        {
            target.position = Vector3.Lerp(startPos, this.transform.position, elapsedTime / duration);
            target.rotation = Quaternion.Lerp(startRot, this.transform.rotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
