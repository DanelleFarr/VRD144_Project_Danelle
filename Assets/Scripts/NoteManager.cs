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
    private float frequency = 5f;
    private float frequencyAdjustment = 2f;
    private GameObject notetoMake;
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


    public float Speed { get { return speed; } set { speed = value;} }
    public float Frequency { get { return frequency; } 
        set { frequency = (frequencyAdjustment + (frequencyAdjustment * value)); } }
    public Collider KillZone { get { return killZone; } }

    // Start is called before the first frame update
    void Start()
    {

        notetoMake = testNote;
        StartCoroutine(NoteEmission(frequency));
    }

    public void SwitchNotes(int note)
    {
        switch(note)
        {
            case 1: notetoMake = percussionNote; return;
            case 2: notetoMake = stringNote; return;
            case 3: notetoMake = pluckedNote; return;
            case 4: notetoMake = brassNote; return;
            case 5: notetoMake = windNote; return;
            case 6: notetoMake = keyboardNote; return;
            case 7: notetoMake = vocalNote; return;
            default: notetoMake = testNote; return;
        }
    }//end SwitchNotes

    private IEnumerator NoteEmission(float waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= waitTime)
            {
                
                GameObject go = Instantiate(notetoMake, SpawnPositions[3].position, SpawnPositions[3].rotation);
                NoteBluePrint noteBluePrint = go.GetComponent<NoteBluePrint>();
                noteBluePrint.Manager = this;
                noteBluePrint.TargetPosition = TargetPositions[3];
                noteBluePrint.Speed = speed;
                StartCoroutine(noteBluePrint.MoveToTarget(TargetPositions[3], noteBluePrint.Speed));
                elapsedTime = 0f;
            }
            yield return null;
        }
    }//end NoteEmission()

}
