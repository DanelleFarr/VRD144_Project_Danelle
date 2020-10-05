using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveNote : MonoBehaviour
{
    [SerializeField]
    float speed = .01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        this.transform.Translate(speed, 0, 0, Space.World);
    }
}
