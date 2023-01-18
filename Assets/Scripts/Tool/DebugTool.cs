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

/// <summary>
/// 調用Log
/// </summary>
/// <param name="context">Log內容</param>
/// <param name="logColor">Log顏色</param>
    public void Show(string context, Color logColor) { 
        string colorNum = ColorUtility.ToHtmlStringRGB(logColor);
        Debug.Log("<color=#" + colorNum + ">" + context + "</color>");
    }
}
