using TMPro;
using UnityEngine;

/// <summary>
/// The purpose of this class is
/// to determine if movment of 
/// a player using the VRDSmoothMovement
/// component is blocked. This component
/// should only be added to objects that
/// are part of the player rig hierarchy.
/// All physics objects in the scene will
/// be handled appropriately by this component.
/// 
/// This component will automatically
/// add a collider to any object it is
/// placed on if one does not exist
/// </summary>
[RequireComponent(typeof(Collider))]
public class VRDPhysicsTriggerStatus : MonoBehaviour
{
    /// <summary>
    /// This field is toggled
    /// between true/false upon
    /// a the trigger being entered
    /// and exited
    /// </summary>
    private bool isColliding = false;

    /// <summary>
    /// This property is used by the
    /// VRDSmoothMovement component to
    /// check if the player is blocked
    /// </summary>
    public bool IsColliding
    {
        get { return isColliding; }
        private set
        {
            isColliding = value;
        }
    }

    private void Start()
    {
        // This ensures that the collider
        // on the object is a trigger to
        // properly handle messaging
        this.GetComponent<Collider>().isTrigger = true;
    }

    /// The collider has a trigger
    /// collision volume, this will 
    /// cause the OnTriggerEnter
    /// to be called on this object
    /// This behavior is explained here:
    /// https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html    
    private void OnTriggerEnter(Collider col)
    {
        // Toggle true when an
        // object passes into the
        // the trigger
        IsColliding = true;
    }

    // The collider has a trigger
    /// collision volume, this will 
    /// cause the OnTriggerExit
    /// to be called on this object
    /// This behavior is explained here:
    /// https://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html
    private void OnTriggerExit(Collider col)
    {
        IsColliding = false;
    }
}
