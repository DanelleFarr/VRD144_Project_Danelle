using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is responsible for
/// allowing an object to listen to
/// Input from a controller. This
/// implementation requires the object
/// to be within the trigger volume of
/// the controller.
/// </summary>
public class VRDControllerButtonListener : MonoBehaviour, IButtonListener
{
    //[SerializeField]
    //OVRInput.Controller targetController = OVRInput.Controller.LTouch;
    /// <summary>
    /// The button(s) to listen for
    /// </summary>
    [SerializeField]
    OVRInput.Button targetButton = OVRInput.Button.None;
    
    /// <summary>
    /// A public property used by
    /// the subscription system
    /// </summary>
    public OVRInput.Button TargetButton
    {
        get { return targetButton; }
    }

    /// <summary>
    /// The methods to call when the
    /// target button(s) are pressed
    /// </summary>
    [SerializeField]
    private UnityEvent OnTargetButtonPressed;

    /// <summary>
    /// A reference to the currently used
    /// handler. This must be cached to ensure
    /// the listener is unsubscribed is destroyed
    /// or disabled
    /// </summary>
    private VRDControllerInputHandler handler;

    /// <summary>
    /// This method is called by the
    /// event dispatcher (VRDControllerInputHandler)
    /// </summary>
    public void ReceiveInput()
    {
        OnTargetButtonPressed.Invoke();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Attempt to find an input handler
        // on the colliding object
        VRDControllerInputHandler controller = 
            other.GetComponent<VRDControllerInputHandler>();

        // If an input handler is found
        // subscribe to it so input can
        // be reacted to
        if(controller != null)
        {
            handler = controller;
            handler.Subscribe(this);
            
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        // Attempt to find an input handler on
        // the exiting object
        VRDControllerInputHandler controller = 
            other.GetComponent<VRDControllerInputHandler>();

        // If a handler was found,
        // unsubscribe from to stop
        // receiving input
        if (controller != null)
        {
            controller.Unsubscribe(this);
            if(controller == handler)
            {
                handler = null;
            }
        }
    }

    // If this component is disabled
    // or the owning GameObject is
    // set to be inactive unsubscribe
    // to input.
    private void OnDisable()
    {
        if (handler != null)
        {
            handler.Unsubscribe(this);
        }
        
    }

    // If this component/GameObject is destroyed
    // unsubscribe to input
    private void OnDestroy()
    {
        if (handler != null)
        {
            handler.Unsubscribe(this);
        }
        
    }
}
