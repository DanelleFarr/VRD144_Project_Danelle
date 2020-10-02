using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ReturnToStartPos : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Vector3 startPos;
    [SerializeField]
    Vector3 startRot;
    void Start()
    {
        //set the start position and rotation based on where the object starts.
        startPos = this.transform.position;
        startRot = this.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   //reset the object to it's starting position and rotation
    public void ReturnToStart()
    {
        this.transform.position = startPos;
        this.transform.eulerAngles = startRot; 
    }//end ReturnToStart()
}
