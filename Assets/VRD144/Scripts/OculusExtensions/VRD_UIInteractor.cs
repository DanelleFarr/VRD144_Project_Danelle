using UnityEngine;
using UnityEngine.UI;


public class VRD_UIInteractor : MonoBehaviour, IButtonListener
{

    [SerializeField]
    Button UI_Button;
    
    private OVRInput.Button targetButton;
    public OVRInput.Button TargetButton
    {
        get { return targetButton; }
        set { targetButton = value; }
    }

    public void DoPointerEnter(GameObject go)
    {
        VRDControllerInputHandler handler = go.GetComponent<VRDControllerInputHandler>() ?? go.GetComponentInParent<VRDControllerInputHandler>();

        if(handler != null)
        {
            handler.Subscribe(this);
        }
        
        UI_Button.OnPointerEnter(null);
    }

    public void DoPointerExit(GameObject go)
    {
        VRDControllerInputHandler handler = go.GetComponent<VRDControllerInputHandler>() ?? go.GetComponentInParent<VRDControllerInputHandler>();
        
        if(handler == null)
        {           
            return;
        }

        handler.Unsubscribe(this);
        UI_Button.OnPointerExit(null);
    }

    public void ReceiveInput()
    {
        UI_Button.onClick.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        DoPointerEnter(other.gameObject);

    }

    private void OnTriggerExit(Collider other)
    {
        DoPointerExit(other.gameObject);
    }
}
