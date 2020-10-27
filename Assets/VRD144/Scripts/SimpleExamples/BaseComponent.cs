using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    [SerializeField]
    protected float speed = 10f;
    [SerializeField]
    private int number = 2;

    public virtual float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Start()
    {
        speed = 5f;
    }

}
