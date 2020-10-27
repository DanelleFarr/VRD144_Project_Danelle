using UnityEngine;

public class VRDLinearMapping : MonoBehaviour
{
    private float value;
    [SerializeField]
    private FloatUnityEvent onValueChanged;

    public float Value
    {
        get { return value; }
        set
        {
            if (value != this.value)
            {
                this.value = value;
                onValueChanged.Invoke(this.value);
            }
        }
    }

    private void Start()
    {
        onValueChanged.Invoke(Value);
    }


}
