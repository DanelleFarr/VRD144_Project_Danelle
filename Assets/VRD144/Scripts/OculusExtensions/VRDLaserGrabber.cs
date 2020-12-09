using UnityEngine;
using UnityEngine.EventSystems;

public class VRDLaserGrabber : MonoBehaviour
{
    /// <summary>
    /// The line renderer to manipulate
    /// </summary>
    [SerializeField]
    private LineRenderer line;
    /// <summary>
    /// Do you want to limit the distance
    /// an object can be grabbed from
    /// </summary>
    [SerializeField]
    private bool useEffectiveRange = false;
    /// <summary>
    /// How far away an object can
    /// be grabbed from
    /// </summary>
    [SerializeField]
    private float effectiveRange = 3f;
    /// <summary>
    /// The hand you want to work with
    /// </summary>
    [SerializeField]
    private OVRGrabber grabber;
    /// <summary>
    /// Button responsible for triggering the
    /// grab
    /// </summary>
    [SerializeField]
    private OVRInput.Button grabButton;
    /// <summary>
    /// Button responsible for triggering UI
    /// interactions
    /// </summary>
    [SerializeField]
    private OVRInput.Button uiInteractionButton;
    [SerializeField]
    private Color startColor;
    [SerializeField]
    private Color highlightColor;

    public OVRInput.Button UIInteractionButton
    {
        get { return uiInteractionButton; }
    }

    /// <summary>
    /// Object that is currently selected
    /// by the laser pointer
    /// </summary>
    [SerializeField]
    private GameObject selectedObject = null;

    private GameObject SelectedObject
    {
        get { return selectedObject; }
        set
        {
            if (value != selectedObject)
            {
                ClearAnySelectedUIElement();
            }
            selectedObject = value;                
        }
    }

    void Start()
    {
        if(line == null)
        {
            line = GetComponent<LineRenderer>();
        }
        line.startColor = line.endColor = Color.red;
        line.enabled = false;
    }

    public void TogglePointer()
    {
        line.enabled = !line.enabled;
    }

    private void Update()
    {
        UpdateLaser();

        if(TrySelectUIElement(SelectedObject))
        {
            TryClickUIElement(SelectedObject);
        }
        if (OVRInput.GetDown(grabButton))
        {
            TryGrabSelectedObject(SelectedObject);
        }
    }

    private void UpdateLaser()
    {
        if (line.enabled)
        {
            // Set the start position of the
            // line to the current position of 
            // the anchor on the hand
            line.SetPosition(0, transform.position);

            // Stored physics collision
            RaycastHit hitInfo;
            // Ray going forward from the local
            // position of the laser origin (controller)
            Ray ray = new Ray(transform.position, transform.forward);
            // Raycast to find a collider
            Physics.Raycast(ray, out hitInfo);
            // End our laser at the collision point
            if(hitInfo.point == null)
            {
                line.SetPosition(1, transform.forward * 10);
            }
            else
            {
                line.SetPosition(1, hitInfo.point);
            }
            

            float dist = Vector3.Distance(hitInfo.point, transform.position);

            // If we are within effective range
            // OR we don't care about effect range
            if (useEffectiveRange == false || dist <= effectiveRange)
            {
                SelectedObject = hitInfo.collider.gameObject;
                bool selectable = IsInteractable(SelectedObject);
                if (selectable)
                {
                    line.startColor = line.endColor = highlightColor;
                }

                else
                {
                    line.startColor = line.endColor = startColor;
                }
            } // End If effective Range

        }
        else
        {
            selectedObject = null;
        }
    }

    private bool IsInteractable(GameObject go)
    {
        return go.GetComponent<OVRGrabbable>() != null ||
            go.GetComponentInParent<OVRGrabbable>() != null ||
            go.GetComponent<VRD_UIInteractor>() != null;
    }

    private void TryGrabSelectedObject(GameObject go)
    {
        if(go == null)
        {
            return;
        }

        OVRGrabbable grabbable = go.GetComponent<OVRGrabbable>() ?? go.GetComponentInParent<OVRGrabbable>();        

        if (grabbable == null)
        {
            return;
        }

        line.startColor = line.endColor = highlightColor;
        // Toggle Off the pointer
        TogglePointer();
        // Instanly move the object to the hand
        grabbable.transform.position = grabber.transform.position;
        // Tell the grabber that the object
        // is in the trigger area
        grabber.SendMessage("OnTriggerEnter", grabbable.grabPoints[0]);
    }

    private void ClearAnySelectedUIElement()
    {
        if(SelectedObject == null)
        {
            return;
        }

        VRD_UIInteractor buttonTrigger = selectedObject.GetComponent<VRD_UIInteractor>();// ?? SelectedObject.GetComponentInParent<VRD_UIInteractor>();
        if(buttonTrigger == null)
        {
            return;
        }
        buttonTrigger.DoPointerExit(this.gameObject);
    }
    private bool TrySelectUIElement(GameObject go)
    {
        if(go == null)
        {
            return false;
        }

        VRD_UIInteractor buttonTrigger = go.GetComponent<VRD_UIInteractor>() ?? go.GetComponentInParent<VRD_UIInteractor>();
        

        if(buttonTrigger == null)
        { 
            return false;
        }
        buttonTrigger.TargetButton = UIInteractionButton;
        buttonTrigger.DoPointerEnter(this.gameObject);

        return true;
    }

    private void TryClickUIElement(GameObject go)
    {
        VRD_UIInteractor buttonTrigger = go.GetComponent<VRD_UIInteractor>() ?? go.GetComponentInParent<VRD_UIInteractor>();
        
        if(buttonTrigger == null)
        {
            return;
        }

        if (OVRInput.GetDown(buttonTrigger.TargetButton))
        {
            buttonTrigger.ReceiveInput();
        }
        
    }
}
