using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
    protected float speed;
    private float speedModifier = 4f;
    protected Transform endPos;
    public Transform TargetPosition { get { return endPos; } set { endPos = value; } }
    [SerializeField]
    protected NoteType noteType;
    [SerializeField]
    private NoteManager noteManager;
    public NoteManager Manager {get { return noteManager;} set { noteManager = value;} }


    private void Start()
    {
        speed = (speedModifier * noteManager.Speed) +1f;
    }
    private void Update()
    {
        if (noteManager != null)
        {
            MoveForward();
           //StartCoroutine(MoveToTarget(endPos, speed));
        }
    }
    public void MoveForward()
    {
        this.transform.Translate(0, 0, -(speed * speedModifier * Time.deltaTime), Space.World);
    }//end MoveForward

    private IEnumerator MoveToTarget(Transform target, float duration)
    {
        float elapsedTime = 0f;
        Vector3 endPos = target.position;
        //Quaternion endRot = target.rotation;

        while (elapsedTime < duration)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, endPos, elapsedTime / duration);
            Debug.Log("time/duration = " + (elapsedTime / duration));
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, target.rotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == noteManager.KillZone)
        {
            Destroy(this.gameObject);
        }//end if IsAccepted
    }




}
