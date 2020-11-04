using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    public float Speed { get { return speed; } set { speed = 10f - (speedModifier * value); } }
    private float speedModifier = 5f;
    protected Transform endPos;
    public Transform TargetPosition { get { return endPos; } set { endPos = value; } }
    [SerializeField]
    protected NoteType noteType;
    [SerializeField]
    private NoteManager noteManager;
    public NoteManager Manager { get { return noteManager; } set { noteManager = value; } }


    private void Start()
    {
        speed = 10f - (speedModifier * noteManager.Speed);

    }

    public void MoveForward()
    {
        this.transform.Translate(0, 0, -(speed * speedModifier * Time.deltaTime), Space.World);
    }//end MoveForward

    public IEnumerator MoveToTarget(Transform target, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startPos = this.transform.position;
        Vector3 endPos = target.position;
        //Quaternion startRot = this.transform.rotation;
        //Quaternion endRot = target.rotation;
        float earlyStart = 2f;

        while (elapsedTime < duration)
        {
            Debug.Log(elapsedTime);
            this.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            //this.transform.rotation = Quaternion.Lerp(startRot, target.rotation, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration - earlyStart)
            {
                StartCoroutine(FadeOut(this.gameObject, earlyStart));
            }

            yield return null;
        }

        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other == noteManager.KillZone)
    //    {
    //        //Destroy(this.gameObject);
    //        StartCoroutine(FadeOut(this.gameObject, .5f));
    //    }//end if IsAccepted
    //}

    private IEnumerator FadeOut(GameObject target, float duration)
    {
        float elapsedTime = 0f;
        Material mat = target.GetComponent<MeshRenderer>().material;
        Color startColor = mat.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            mat.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);

            yield return null;
        }//while duration
        Destroy(target);
    }//end FadeOut()





}
