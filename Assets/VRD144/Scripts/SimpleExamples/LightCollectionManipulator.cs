using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollectionManipulator : MonoBehaviour
{
    [SerializeField]
    private Light[] lights;
    [SerializeField]
    private float intensity = 1f;
    [SerializeField]
    private float red = 1f;
    [SerializeField]
    private float green = 1f;
    [SerializeField]
    private float blue = 1f;


    public float Intesity
    {
        get { return intensity; }
        set
        {
            intensity = value;

            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].intensity = intensity;
            }
        }
    }

    public float Red
    {
        get { return red; }
        set { red = value;
            DoColorChange();
        }
    }

    public float Green
    {
        get { return green; }
        set
        {
            green = value;
            DoColorChange();
        }
    }
    public float Blue
    {
        get { return blue; }
        set
        {
            blue = value;
            DoColorChange();
        }
    }

    private void DoColorChange()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = new Color(red, green, blue);
        }
    }
}
