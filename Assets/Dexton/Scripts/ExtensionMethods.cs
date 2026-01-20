using UnityEngine;

public static class ExtensionMethods
{
    public static T GetComponentInSibling<T>(this GameObject gO)
    {
        return gO.transform.parent.GetComponentInChildren<T>();
    }
}