using UnityEngine;

public class VRDLinearDrive : MonoBehaviour
{
    [SerializeField]
    private VRDLinearMapping linearMap;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform endPosition;
    [SerializeField]
    private Transform driver;
    private OVRGrabbable grabbable = null;

    // Start is called before the first frame update
    void Start()
    {
        if(linearMap == null)
        {
            linearMap = gameObject.GetOrAddComponent<VRDLinearMapping>();
        }
        if(grabbable == null)
        {
            grabbable = driver.gameObject.GetOrAddComponent<OVRGrabbable>();
        }

        linearMap.Value = CalculateLinearMapping(driver);
    }

    void LateUpdate()
    {
        if (grabbable.isGrabbed)
        {
            linearMap.Value = Mathf.Clamp01(CalculateLinearMapping(driver));
        }

        driver.position = Vector3.Lerp(startPosition.position, endPosition.position, linearMap.Value);
        driver.eulerAngles = Vector3.Lerp(startPosition.eulerAngles, endPosition.eulerAngles, linearMap.Value);

    }

    private float CalculateLinearMapping(Transform updateTransform)
    {
        Vector3 direction = endPosition.position - startPosition.position;
        float length = direction.magnitude;
        direction.Normalize();

        Vector3 displacement = updateTransform.position - startPosition.position;

        return Vector3.Dot(displacement, direction) / length;
    }
}
