using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
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
    protected float speed;
    private float speedModifier = 2f;

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
        Debug.Log("Moving");
    }//end MoveForward

    




}
