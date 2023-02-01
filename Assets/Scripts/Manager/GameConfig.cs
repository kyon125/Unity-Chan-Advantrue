using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : Singleton<GameConfig>
{
    public GameConfigSO gameConfig;

    /// <summary>
    /// 砞﹚Τ闽硉ゲ斗盿そΑ
    /// </summary>
    public float ConvertSpeed(float initialSpeed)
    {
        return initialSpeed * gameConfig.parameter.DeltaX + gameConfig.parameter.DeltaY;
    }
}
[System.Serializable]
public class ConfigParameter
{
    [Header("吏挂把计")]
    public float DeltaX;
    public float DeltaY;
    [Header("產把计砞﹚")]
    public float maxWalkSpeed;
    public float maxRunSpeed;
    public float addWalkSpeed;
    public float addRunSpeed;
    public float addJumpSpeed;
}
