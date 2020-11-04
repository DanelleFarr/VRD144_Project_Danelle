using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
    protected float speed;
    private float speedModifier = 5f;
    protected Transform endPos;
    public Transform TargetPosition { get { return endPos; } set { endPos = value; } }
    [SerializeField]
    protected NoteType noteType;
    [SerializeField]
    private NoteManager noteManager;
    public NoteManager Manager {get { return noteManager;} set { noteManager = value;} }


    private void Start()
    {
        speed = 10f -(speedModifier * noteManager.Speed);
    }
    private void Update()
    {
        if (noteManager != null)
        {
            //MoveForward();
           StartCoroutine(MoveToTarget(endPos, speed));
        }
    }
    public void MoveForward()
    {
        this.transform.Translate(0, 0, -(speed * speedModifier * Time.deltaTime), Space.World);
    }//end MoveForward

    private IEnumerator MoveToTarget(Transform target, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startPos = this.transform.position;
        Vector3 endPos = target.position;
        //Quaternion startRot = this.transform.rotation;
        //Quaternion endRot = target.rotation;

        while (elapsedTime < duration)
        {
            this.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            //this.transform.rotation = Quaternion.Lerp(startRot, target.rotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == noteManager.KillZone)
        {
            //Destroy(this.gameObject);
            StartCoroutine(FadeOut(this.gameObject, .5f));
        }//end if IsAccepted
    }

    private IEnumerator FadeOut(GameObject target, float duration)
    {
        float elapsedTime = 0f;
        Color fadeColor = target.GetComponent<MeshRenderer>().material.color;
        float transp = 1f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration) //destroy object if time elapsed
            {
                Destroy(target);
            }//end if duration up
            else //fade Material alpha over time
            {
                transp = (1 - elapsedTime / duration);
                fadeColor.a = transp;
                target.GetComponent<MeshRenderer>().material.color = fadeColor;
            }//end else
            yield return null;
        }//while duration
    }//end FadeOut()





}
