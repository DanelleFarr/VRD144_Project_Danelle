using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtonListener
{
    OVRInput.Button TargetButton { get; }
    void ReceiveInput();
}
