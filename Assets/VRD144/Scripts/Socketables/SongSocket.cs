using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongSocket : MonoBehaviour
{
    //[SerializeField]
    //private SocketableType acceptedSocketableType;
    [SerializeField]
    private bool doTween = false;
    [SerializeField]
    private float duration = 1f;
    private StoredSongInfo displayInfo; 
    private MeshRenderer meshRenderer;
    //[SerializeField]
    //public DisplayCanvasManager handler;
    [SerializeField]
    public TextMeshProUGUI songsCanvas;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // Try to find a socketable
        displayInfo = other.GetComponent<StoredSongInfo>();
        songsCanvas.text = displayInfo.SongName;

        // If there isn't one, exit the method
        if(displayInfo == null)
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

        displayInfo.GetComponent<Rigidbody>().isKinematic = true;

        if (doTween)
        {
            StartCoroutine(MoveIntoPlace(displayInfo.transform, duration));
        }
        else
        {
            displayInfo.transform.position = this.transform.position;
            displayInfo.transform.rotation = this.transform.rotation;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == displayInfo.gameObject)
        {
            meshRenderer.enabled = true;
            displayInfo = null;
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
