using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    // This list will hold all objects
    // that can be triggers
    [SerializeField]
    private List<UITriggerEvents> triggerables = new List<UITriggerEvents>();
    private static TouchInputManager manager;
    [SerializeField]
    private TextMeshProUGUI tmpro;

    public static void RegisterListener(UITriggerEvents listener)
    {
        if (!manager.triggerables.Contains(listener))
        {
            manager.triggerables.Add(listener);
        }
            
    }

    public static void DeregisterListener(UITriggerEvents listener)
    {
        if (manager.triggerables.Contains(listener))
        {
            manager.triggerables.Remove(listener);
        }
        
    }

    private void Start()
    {
        manager = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SendInput(OVRInput.Button.One);
           
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            SendInput(OVRInput.Button.Two);
            
        }
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            SendInput(OVRInput.Button.Three);
        }
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            SendInput(OVRInput.Button.Four);
        }
    }

    public void SendInput(OVRInput.Button button)
    {
        foreach (UITriggerEvents triggerable in triggerables)
        {
            triggerable.ReceiveInput(button);
        }
    }
}