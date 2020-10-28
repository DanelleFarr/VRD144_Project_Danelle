using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField]
    private float speed =7;
    [SerializeField]
    private float frequency = 3;
    [SerializeField]
    private Transform spawnPosition;
    /*[SerializeField]
    private Note percussionNote;
    [SerializeField]
    private Note stringNote;
    [SerializeField]
    private Note pluckedNote;
    [SerializeField]
    private Note brassNote;
    [SerializeField]
    private Note WindNote;
    [SerializeField]
    private Note keyboardNote;
    [SerializeField]
    private Note vocalNote;*/
    [SerializeField]
    private GameObject testNote;


    public float Speed { get { return speed; } set { speed = Speed; } }
    public float Frequency{ get { return frequency; } set { frequency = Frequency; } }

    // Start is called before the first frame update
    void Start()
    {

        GameObject go = Instantiate(testNote, spawnPosition.position, spawnPosition.rotation);
        go.GetComponent<NoteBluePrint>().Manager = this;

        StartCoroutine(NoteEmission(Frequency));
    }

    private IEnumerator NoteEmission(float waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= waitTime)
            {
                GameObject go = Instantiate(testNote, spawnPosition.position, spawnPosition.rotation);
                go.GetComponent<NoteBluePrint>().Manager = this;
                elapsedTime = 0f;
            }
            yield return null;
        }
    }

}
