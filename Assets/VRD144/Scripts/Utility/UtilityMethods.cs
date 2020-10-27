using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityMethods : MonoBehaviour
{
    public void ToggleObject(GameObject gameObject)
    {
        gameObject.ToggleActiveState();
    }

    public void DebugMessage(string message)
    {
        Debug.Log(message);
    }

    public void InstantiateObject(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
    public void DestroyObject(GameObject target)
    {
        Destroy(target);
    }
}
