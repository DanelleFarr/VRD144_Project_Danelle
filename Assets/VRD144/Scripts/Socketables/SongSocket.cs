using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSocket : MonoBehaviour
{
    //[SerializeField]
    //private SocketableType acceptedSocketableType;
    [SerializeField]
    private bool doTween = false;
    [SerializeField]
    private float duration = 1f;
    private TestSong song; 
    private MeshRenderer meshRenderer;
    [SerializeField]
    private SongHandler handler;
    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Try to find a socketable
        song = other.GetComponent<TestSong>();

        // If there isn't one, exit the method
        if(song == null)
        {
            return;
        }

        handler.PlaySong(song.Song);

        // find the grabbable
        OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>();       

        if (grabbable != null && grabbable.isGrabbed)
        {
            // Whatever this grabbable is grabbed by
            // force it to release this grabbable
            grabbable.grabbedBy.ForceRelease(grabbable);
        }

        meshRenderer.enabled = false;
        song.GetComponent<Rigidbody>().isKinematic = true;

        if (doTween)
        {
            StartCoroutine(MoveIntoPlace(song.transform, duration));
        }
        else
        {
            song.transform.position = this.transform.position;
            song.transform.rotation = this.transform.rotation;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == song.gameObject)
        {
            meshRenderer.enabled = true;
            song = null;
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
