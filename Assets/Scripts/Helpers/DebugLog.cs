using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog : MonoBehaviour
{
    public static void LogGreen(string message)
    {
        print("<color=green>" + message + "</color>");
    }

    public static void LogNormal(string message)
    {
        print(message);
    }

    public static void LogWarning(string message)
    {
        print("<color=yellow>" + message + "</color>");
    }

    public static void LogError(string message)
    {
        print("<color=red>" + message + "</color>");
    }
}
