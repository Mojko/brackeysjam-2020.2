using System;
using UnityEngine;
using System.Collections.Generic;

public class DropHelper : MonoBehaviour
{
    private static Dictionary<String, GameObject> objs = new Dictionary<String, GameObject>();

    public static void registerDropArea(string name, GameObject obj)
    {
        objs[name] = obj;
    }

    public static GameObject Drop(GameObject obj)
    {
        Timestamp stamp = SmoothSlider.Instance.getCurrentTimestamp();
        print("STAMP" + stamp.timestamp);
        Transform parent = objs[stamp.timestamp].transform;
        print("PARENT: " + parent);
        return Instantiate(obj, parent);
    }

    public static GameObject getTimestampObject(Timestamp t)
    {
        return objs[t.timestamp];
    }
}
