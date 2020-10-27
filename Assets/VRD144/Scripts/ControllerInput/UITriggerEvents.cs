using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UITriggerEvents : MonoBehaviour
{
    [SerializeField]
    Button myButton;
    [SerializeField]
    private OVRInput.Button acceptedButtons;
    [SerializeField]
    private UnityEvent OnClick;

    // Start is called before the first frame update
    void Start()
    {
        myButton = this.GetComponent<Button>();
    }

    public void ReceiveInput(OVRInput.Button button)
    {
        if (acceptedButtons.HasFlag(button))
        {
            TriggerEvents();
        }
    }

    private void TriggerEvents()
    {
        OnClick.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        myButton.OnPointerEnter(null);
        TouchInputManager.RegisterListener(this);
    }

    private void OnTriggerExit(Collider other)
    {
        myButton.OnPointerExit(null);
        TouchInputManager.DeregisterListener(this);
    }


    private void OnDisable()
    {
        TouchInputManager.DeregisterListener(this);
    }

    private void OnDestroy()
    {
        TouchInputManager.DeregisterListener(this);
    }


}