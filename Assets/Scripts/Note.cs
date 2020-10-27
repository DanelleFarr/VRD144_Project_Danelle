using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : NoteBluePrint
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("New Note Created");
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
}
