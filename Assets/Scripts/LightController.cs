using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    //Declare array of scene lights to turn on/off
    [SerializeField]
    public Light[] acceptedLights;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Turn Off All Lights
     public void TurnOffAllLights()
    {
        for( int light = 0; light < acceptedLights.Length; light ++)
        {
            acceptedLights[light].enabled = false;
        }//end for lights in accepted lights
    }//end TurnOffAllLights()

    public void TurnOnSelectedLight(Light givenLight)
    {
        foreach(Light light in acceptedLights)
        {
            if(light == givenLight)
            {
                light.enabled = true;
                break;
            }//end if accepted light
        }//end foreach light in acceptedLights

    }//end TurnOnSelectedLight
}
