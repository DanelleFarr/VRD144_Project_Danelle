using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<NoteBluePrint>())
        {
            Destroy(other.GetComponent<GameObject>());
        }
    }
}
