using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socketable : MonoBehaviour
{
    [SerializeField]
    private SocketableType socketableType;

    public SocketableType Type
    {
        get { return socketableType; }
    }
}
