using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VRDGameObjectExtensions
{
    public static void ToggleActiveState(this GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();
        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }
        return component;
    }
}
