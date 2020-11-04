using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<NoteBluePrint>())
        {
            //Destroy(other.GetComponent<GameObject>());
            StartCoroutine(FadeOut(other.GetComponent<GameObject>(), 2f));
        }
    }//end OnTriggerEnter

    private IEnumerator FadeOut(GameObject target, float duration)
    {
        float elapsedTime = 0f;
        Color fadeColor = target.GetComponent<MeshRenderer>().material.color;
        float transp = 1f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("elapsedTime is " + elapsedTime);
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
