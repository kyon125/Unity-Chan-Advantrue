using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : Singleton<GameConfig>
{
    public GameConfigSO gameConfig;

    /// <summary>
    /// �]�w�����t�׮ɡA�����a�J����
    /// </summary>
    public float ConvertSpeed(float initialSpeed)
    {
        return initialSpeed * gameConfig.parameter.DeltaX + gameConfig.parameter.DeltaY;
    }
}
[System.Serializable]
public class ConfigParameter
{
    [Header("���ҰѼ�")]
    public float DeltaX;
    public float DeltaY;
    [Header("���a�ѼƳ]�w")]
    public float maxWalkSpeed;
    public float maxRunSpeed;
    public float addWalkSpeed;
    public float addRunSpeed;
    public float addJumpSpeed;
}
