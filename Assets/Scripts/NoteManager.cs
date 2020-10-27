using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float frequency;
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
    private NoteBluePrint testNote;


    public float Speed { get { return speed; } set { speed = Speed; } }
    public float Frequency{ get { return frequency; } set { frequency = Frequency; } }

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(testNote, spawnPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
