using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameConfig/New ConfigSO", fileName = "New ConfigSO")]
public class GameConfigSO : ScriptableObject
{
    public ConfigParameter parameter;
}
