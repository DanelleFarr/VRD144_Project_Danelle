using UnityEngine;

/// <summary>
/// The purpose of this class is to solve
///  a series of issues surrounding the
///  default Oculus player rig. Particularly,
///  character controller collision volume not
///  following the HMD. This avoids that problem
///  by implementing a non-physics based movement.
///  The downside is that the player will be forced
///  to stay on a single plane (y-axis) during play
/// </summary>
public class VRDSmoothMovement : MonoBehaviour
{
    /// <summary>
    /// This field determines the controller
    /// that will be used to drive the movement
    /// of the player rig. By default it is set
    /// to the right hand
    /// </summary>
    [SerializeField]
    private OVRInput.Controller movementController = 
        OVRInput.Controller.RTouch;
    /// <summary>
    /// This boolean determines if the value
    /// of the joystick will be used to modify
    /// the speed. i.e. pushing further forward
    /// will add speed
    /// </summary>
    [SerializeField]
    private bool useJoystickModifier = true;
    /// <summary>
    /// The speed modifier is used to
    /// ensure a good movement speed and
    /// is used to multiply time.deltaTime
    /// value during that movement
    /// </summary>
    [SerializeField]
    float speedModifier = 10f;
    /// <summary>
    /// This is reference to the
    /// OVRCameraRig that will be
    /// used for tracking the HMD
    /// in the scene
    /// </summary>
    [SerializeField]
    private OVRCameraRig cameraRig;
    /// <summary>
    /// If set to true, the user will
    /// not be able to move using the
    /// joystick while colliding with
    /// one or more GameObjects that
    /// have the VRDPhysicsTrigger status
    /// component present
    /// </summary>
    [SerializeField]
    private bool stopOnCollision = true;
    /// <summary>
    /// This array holds all the colliders
    /// that will influence movement
    /// </summary>
    [SerializeField]
    private VRDPhysicsTriggerStatus[] collisionTrackers = { };

    private bool isBlocked
    {
        get
        {
            // Return true as soon
            // as a VRDTriggerStateTracker
            // is found to be colliding
            // with another object
            foreach (VRDPhysicsTriggerStatus tracker in collisionTrackers)
            {
                if (tracker.IsColliding)
                {
                    return true;
                }
            }
            return false;
        }
    }

    void Start()
    {
        // This checks to see if there is
        // an OVRCameraRig assigned to the
        // camera rig variable. If one is
        // not assigned, the first one found
        // is going to be used.
        if (!cameraRig)
        {
            cameraRig = FindObjectOfType<OVRCameraRig>();
        }
    }

    void Update()
    {
        RotateWithHMD();
        PrimaryThumbstickMovement();
    }

    // This is all controlled using the
    // controller thumbstick
    private void PrimaryThumbstickMovement()
    {
        // If the user is colliding with an
        // object, no movement will be allowed
        if (stopOnCollision && isBlocked)
        {
            // This exits PrimaryThumbstickMovment
            // immediately
            return;
        }

        // Our baseSpeed is calculated using
        // the time between frames and our
        // modifier
        //
        // Final speed is determined based on
        // the influence of the joystick axis
        float baseSpeed = speedModifier * Time.deltaTime;

        // For each of these checks, the controller that was
        // assigned to will be used as the input device.
        //
        // Checks are being made for the direction the Thumbstick
        // is being held in (Up, Down, Left, Right)
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, movementController))
        {
            // Here a conditional operator (also called a
            // ternary operator) is use to set the value
            // of final speed based on a condition.
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
            //
            // Additionally, the Absolute value to the
            // thumbstick input is used to ensure
            // there are no negative values calculated.
            // This leverages Unity's Mathf libary for
            // floating point math. More information on
            // the Abs method is found here:
            // https://docs.unity3d.com/ScriptReference/Mathf.Abs.html
            float finalSpeed = useJoystickModifier ?
                baseSpeed * Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, movementController).y) : baseSpeed;
            transform.Translate(Vector3.forward * finalSpeed);
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, movementController))
        {
            float finalSpeed = useJoystickModifier ?
                baseSpeed * Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, movementController).y) : baseSpeed;
            transform.Translate(Vector3.back * finalSpeed);
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, movementController))
        {
            float finalSpeed = useJoystickModifier ?
                baseSpeed * Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, movementController).x) : baseSpeed;
            transform.Translate(Vector3.left * finalSpeed);
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, movementController))
        {
            float finalSpeed = useJoystickModifier ?
                baseSpeed * Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, movementController).x) : baseSpeed;
            transform.Translate(Vector3.right * finalSpeed);
        }

    }

    private void RotateWithHMD()
    {
        Transform root = cameraRig.trackingSpace;
        Vector3 prevPos = root.position;
        Quaternion prevRot = root.rotation;
        // All rotation is based on the center
        // eye of the camera rig
        transform.rotation = Quaternion.Euler(0f, cameraRig.centerEyeAnchor.eulerAngles.y, 0f);
        // We have to make sure that the tracking 
        // root is reset after we have made
        // adjustments to the parent object
        root.position = prevPos;
        root.rotation = prevRot;
    }


}
