using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteBluePrint : MonoBehaviour
{
    [SerializeField]
    private NoteManager noteManager;
    protected float speed;
    private float speedModifier = .05f;

    public void Start()
    {
        speed = noteManager.Speed;
    }
    public void MoveForward()
    {
        this.transform.Translate(0, 0, -(speed * speedModifier), Space.World);
    }//end MoveForward





}
