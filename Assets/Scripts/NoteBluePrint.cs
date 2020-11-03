using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
    protected float speed;
    private float speedModifier = 5f;
    protected Transform endPos;
    public Transform TargetPosition { get { return endPos; } set { endPos = TargetPosition; } }
    [SerializeField]
    protected NoteType noteType;
    [SerializeField]
    private NoteManager noteManager;
    public NoteManager Manager {get { return noteManager;} set { noteManager = value;} }


    private void Start()
    {
        speed = noteManager.Speed;
    }
    private void Update()
    {
        if (noteManager != null)
        {
            MoveForward();
           //StartCoroutine(MoveToTarget(endPos, speed * speedModifier));
        }
    }
    public void MoveForward()
    {
        this.transform.Translate(0, 0, -(speed * speedModifier * Time.deltaTime), Space.World);
    }//end MoveForward

    private IEnumerator MoveToTarget(Transform target, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startPos = target.position;
        Quaternion startRot = target.rotation;

        while (elapsedTime < duration)
        {
            target.position = Vector3.Lerp(startPos, this.transform.position, elapsedTime / duration);
            target.rotation = Quaternion.Lerp(startRot, this.transform.rotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            Debug.Log("ElapsedTime = " + elapsedTime);
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
