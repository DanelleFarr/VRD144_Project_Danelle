using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    //[SerializeField]
    private float speed;
    //[SerializeField]
    private float frequency;
    private float frequencyAdjustment = 3f;
    [SerializeField]
    private Transform[] SpawnPositions;
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


    public float Speed { get { return speed; } set { speed = value; Debug.Log("Speed is now " + speed); } }
    public float Frequency{ get { return frequency; } set { frequency= value * frequencyAdjustment; Debug.Log("Freqeuncy is now " + frequency); } }

    // Start is called before the first frame update
    void Start()
    {

        //GameObject go = Instantiate(testNote, spawnPosition.position, spawnPosition.rotation);
        //go.GetComponent<NoteBluePrint>().Manager = this;

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
                    foreach (Transform startPos in SpawnPositions)
                    {
                        GameObject go = Instantiate(testNote, startPos.position, startPos.rotation);
                        go.GetComponent<NoteBluePrint>().Manager = this;
                    }//end for each start posision
                    elapsedTime = 0f;
                }
                yield return null;
        }
    }//end NoteEmission()

}
