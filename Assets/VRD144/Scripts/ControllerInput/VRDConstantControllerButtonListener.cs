using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRDConstantControllerButtonListener : MonoBehaviour, IButtonListener
{

    [SerializeField]
    private OVRInput.Button targetButton;
    [SerializeField]
    private UnityEvent OnButtonPressed;
    [SerializeField]
    private VRDControllerInputHandler handler;

    public OVRInput.Button TargetButton
    {
        get { return targetButton; }
    }

    private void OnEnable()
    {
        if (handler != null)
        {
            handler.Subscribe(this);
        }

    }

    private void OnDisable()
    {
        if (handler != null)
        {
            handler.Unsubscribe(this);
        }
    }

    private void OnDestroy()
    {
        if (handler != null)
        {
            handler.Unsubscribe(this);
        }
    }

    public void ReceiveInput()
    {
        OnButtonPressed.Invoke();
    }
}
