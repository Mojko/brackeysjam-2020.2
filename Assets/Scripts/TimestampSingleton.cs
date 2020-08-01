using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimestampSingleton
{
    private static TimestampSingleton instance;

    public int currentTime;

    public TimestampSingleton()
    {
        instance = new TimestampSingleton();
    }

    public static TimestampSingleton Instance => instance;
}
