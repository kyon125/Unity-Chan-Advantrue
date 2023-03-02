using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(menuName = "CreateAttributes/CharaAttributes", fileName = "newCharaAttributes")]
public class CharacterAttributeSO : ScriptableObject
{
    [SerializeField]
    private CharacterAttribute initialCharacterAttribute;
    [SerializeField]
    private CharacterAttribute currentCharacterAttribute;

    public float GetMaxHP()
    {
        return currentCharacterAttribute.TargetMaxHP;
    }
        public float GetCurrentHP()
    {
        return currentCharacterAttribute.TargetHP;
    }
    public float GetValueATK()
    {
        return currentCharacterAttribute.TartgetATK; 
    }

    public void HpAlter(float value)
    {
        DebugTool.Instance.ShowLog("觸發扣寫");
        currentCharacterAttribute.TargetHP = Mathf.Clamp(currentCharacterAttribute.TargetHP + value, 0, 99999);
    }
    public void Initial()
    {
        currentCharacterAttribute = JsonConvert.DeserializeObject<CharacterAttribute>(JsonConvert.SerializeObject(initialCharacterAttribute));
    }
    public string GetData()
    {
        return JsonConvert.SerializeObject(currentCharacterAttribute);
    }
}
[System.Serializable]
public class CharacterAttribute
{
    public string TargetName = "DefaultName";
    public float TargetMaxHP = 0;
    public float TargetHP = 0;
    public float TartgetATK = 0;
}