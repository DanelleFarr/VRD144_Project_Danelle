using System.Collections.Generic;
using UnityEngine;

public class VRDControllerInputHandler : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Controller controller;
    
    // A/X button Listeners
    private List<IButtonListener> buttonOneListeners = new List<IButtonListener>();
    // B/Y button Listeners
    private List<IButtonListener> buttonTwoListeners = new List<IButtonListener>();
    // Thumbstick press (not movement) Listeners
    private List<IButtonListener> thumbstickListeners = new List<IButtonListener>();
    // Trigger press (not movement) Listeners
    private List<IButtonListener> indexTriggerListeners = new List<IButtonListener>();
    // Grip press (not movement) Listeners
    private List<IButtonListener> gripTriggerListeners = new List<IButtonListener>();

    /// <summary>
    /// The current value of a controller's
    /// trigger. This will be between 0 and 1.
    /// Currently, no behavior is implemented
    /// for value change but it can be added.
    /// </summary>
    public float TriggerValue
    {
        get { return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller); }
    }

    /// <summary>
    /// The current value of a controller's
    /// grip. This will be between 0 and 1.
    /// Currently, no behavior is implemented
    /// for value change but it can be added.
    /// </summary>
    public float GripValue
    {
        get { return OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller); }
    }

    /// <summary>
    /// The current value of a controller's
    /// thumbstic. This will be a Vector2 coordinate.
    /// Currently, no behavior is implemented
    /// for value change but it can be added.
    /// </summary>
    public Vector2 JoystickPosition
    {
        get { return OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller); }
    }

    public void Subscribe(IButtonListener listener)
    {
        // Get the button(s) that the VRDControllerButtonListener
        // wants to get input from
        OVRInput.Button targetButton = listener.TargetButton;

        // Check to see if each of our
        // buttons should be listened to.
        // When one is found, add the
        // listener from the appropriate 
        // collection
        if (targetButton.HasFlag(OVRInput.Button.One))
        {
            Subscribe(listener, ref buttonOneListeners);
        }
        if(targetButton.HasFlag(OVRInput.Button.Two))
        {
            Subscribe(listener, ref buttonTwoListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.PrimaryThumbstick))
        {
            Subscribe(listener, ref thumbstickListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.PrimaryIndexTrigger))
        {
            Subscribe(listener, ref indexTriggerListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.PrimaryHandTrigger))
        {
            Subscribe(listener, ref gripTriggerListeners);
        }
        
    }

    /// <summary>
    /// Unsubscribe a given listener
    /// from the collection that it
    /// was assigned to
    /// </summary>
    /// <param name="listener">The listener to be removed</param>
    public void Unsubscribe(IButtonListener listener)
    {
        // Get the button(s) that the VRDControllerButtonListener
        // was getting input from
        OVRInput.Button targetButton = listener.TargetButton;

        // Check to see if each of our
        // buttons were being listened to.
        // When one is found, remove the
        // listener from the appropriate 
        // collection
        if (targetButton.HasFlag(OVRInput.Button.One))
        {
            Unsubscribe(listener, ref buttonOneListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.Two))
        {
            Unsubscribe(listener, ref buttonTwoListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.PrimaryThumbstick))
        {
            Unsubscribe(listener, ref thumbstickListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.PrimaryIndexTrigger))
        {
            Unsubscribe(listener, ref indexTriggerListeners);
        }
        if (targetButton.HasFlag(OVRInput.Button.PrimaryHandTrigger))
        {
            Unsubscribe(listener, ref gripTriggerListeners);
        }

    }

    /// <summary>
    /// This method is used to subscribe a
    /// VRDControllerButtonListener to an
    /// appropriate collection
    /// </summary>
    /// <param name="listener">The VRDControllerButtonListener
    /// will be receiving input feedback</param>
    /// <param name="targetList">The list of VRDControllerButtonListener
    /// components that this component should be assigned to</param>
    private void Subscribe(IButtonListener listener, ref List<IButtonListener> targetList)
    {
        // Check to see if the listener
        // is already in the list before adding
        if (!targetList.Contains(listener))
        {
            // Add the listener to the
            // collection
            targetList.Add(listener);
        }
    }

    /// <summary>
    /// This method is used to remove a
    /// VRDControllerButtonListener from an
    /// appropriate collection
    /// </summary>
    /// <param name="listener">The VRDControllerButtonListener
    /// will was receiving input feedback</param>
    /// <param name="targetList">The list of VRDControllerButtonListener
    /// components that this component should be removed from</param>
    public void Unsubscribe(IButtonListener listener, ref List<IButtonListener> targetList)
    {
        // Note that the method signature
        // above uses the ref keyword which
        // will allow us to manipulate the List
        // that is being used directly.
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref

        // Make sure the listener
        // is in the collection before
        // trying to remove it
        if (targetList.Contains(listener))
        {
            // Remove the listener that was
            // found
            targetList.Remove(listener);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // A or X depending on controller
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            for (int i = buttonOneListeners.Count - 1; i >= 0; i--)
            {            
                buttonOneListeners[i].ReceiveInput();
            }
        }

        // B or Y depending on controller
        if (OVRInput.GetDown(OVRInput.Button.Two, controller))
        {
            for (int i = buttonTwoListeners.Count - 1; i >= 0; i--)
            {
                buttonTwoListeners[i].ReceiveInput();
            }
        }

        // Pressing the thumbstick as a button
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, controller))
        {
            for (int i = thumbstickListeners.Count - 1; i >= 0; i--)
            {
                thumbstickListeners[i].ReceiveInput();
            }
        }

        // Trigger is fully pressed
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            for (int i = indexTriggerListeners.Count - 1; i >= 0; i--)
            {
                indexTriggerListeners[i].ReceiveInput();
            }
            
        }

        // GripButton is fully pressed
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            for (int i = gripTriggerListeners.Count - 1; i >= 0; i--)
            {
                gripTriggerListeners[i].ReceiveInput();
            }
        }
    }
}
