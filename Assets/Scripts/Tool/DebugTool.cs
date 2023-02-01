using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool 
{
    private DebugTool() { }
    private static DebugTool _instance;
    public static DebugTool Instance {
        get {
            if (_instance == null)
                return _instance = new DebugTool();
            else
                return _instance;
        }
    }

    public void ShowLog(string context)
    {
        Debug.Log(context);
    }
    public void ShowWarning(string context)
    {
        Debug.LogWarning(context);
    }
    public void ShowError(string context)
    {
        Debug.LogError(context);
    }
    /// <summary>
    /// �ե�Log
    /// </summary>
    /// <param name="context">Log���e</param>
    /// <param name="logColor">Log�C��</param>
    public void ShowLogWithColor(string context, Color logColor) { 
        string colorNum = ColorUtility.ToHtmlStringRGB(logColor);
        Debug.Log("<color=#" + colorNum + ">" + context + "</color>");
    }
}
