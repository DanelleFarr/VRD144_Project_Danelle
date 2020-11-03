using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    //[SerializeField]
    private float speed = .5f;
    //[SerializeField]
    private float frequency = 3f;
    private float frequencyAdjustment = 10f;
    [SerializeField]
    private Transform[] SpawnPositions;
    [SerializeField]
    private Transform[] TargetPositions;
    [SerializeField]
    private GameObject percussionNote;
    [SerializeField]
    private GameObject stringNote;
    [SerializeField]
    private GameObject pluckedNote;
    [SerializeField]
    private GameObject brassNote;
    [SerializeField]
    private GameObject windNote;
    [SerializeField]
    private GameObject keyboardNote;
    [SerializeField]
    private GameObject vocalNote;
    [SerializeField]
    private GameObject testNote;
    [SerializeField]
    private Collider killZone;


    public float Speed { get { return speed; } set { speed = value; ; Debug.Log("Speed is now " + speed); } }
    public float Frequency { get { return frequency; } set { frequency = (frequencyAdjustment + (frequencyAdjustment * value)); Debug.Log("Freqeuncy is now " + frequency); } }
    public Collider KillZone { get { return killZone; } }

    // Start is called before the first frame update
    void Start()
    {

        /*foreach (Transform startPos in SpawnPositions)
        {
            GameObject go = Instantiate(testNote, startPos.position, startPos.rotation);
            go.GetComponent<NoteBluePrint>().Manager = this;
        }//end for each start posision*/
        StartCoroutine(NoteEmission(frequency));
    }

    private IEnumerator NoteEmission(float waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= waitTime)
            {
                
                GameObject go = Instantiate(testNote, SpawnPositions[3].position, SpawnPositions[3].rotation);
                go.GetComponent<NoteBluePrint>().Manager = this;
                go.GetComponent<NoteBluePrint>().TargetPosition = TargetPositions[3];
                elapsedTime = 0f;
            }
            yield return null;
        }
    }//end NoteEmission()

}
