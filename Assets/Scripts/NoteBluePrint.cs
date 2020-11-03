using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
    protected float speed;
    private float speedModifier = 2f;
    [SerializeField]
    protected NoteType noteType;
    [SerializeField]
    private NoteManager noteManager;
    public NoteManager Manager
    {
        get
        {
            return noteManager;
        }
        set
        {
            noteManager = value;
        }
    }


    private void Start()
    {
        speed = noteManager.Speed;
    }
    private void Update()
    {
        if (noteManager != null)
        {
            MoveForward();
        }
    }
    public void MoveForward()
    {
        this.transform.Translate(0, 0, -(speed * speedModifier * Time.deltaTime), Space.World);
    }//end MoveForward

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered a Collider");
        if (other == noteManager.KillZone)
        {
            Debug.Log("EnteredKillZone");
            Destroy(this.gameObject);
        }//end if IsAccepted
    }




}
