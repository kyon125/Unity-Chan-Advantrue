using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : Singleton<GameConfig>
{
    public GameConfigSO gameConfig;

    /// <summary>
    /// 設定有關速度時，必須帶入公式
    /// </summary>
    public float ConvertSpeed(float initialSpeed)
    {
        return initialSpeed * gameConfig.parameter.DeltaX + gameConfig.parameter.DeltaY;
    }
}
[System.Serializable]
public class ConfigParameter
{
    [Header("環境參數")]
    public float DeltaX;
    public float DeltaY;
    [Header("玩家參數設定")]
    public float maxWalkSpeed;
    public float maxRunSpeed;
    public float addWalkSpeed;
    public float addRunSpeed;
    public float addJumpSpeed;
}
