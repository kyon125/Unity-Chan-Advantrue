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

    public void Attack(int value)
    {
        throw new System.NotImplementedException();
    }

    public void HpAlter(float value)
    {
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
    public float TargetHP = 0;
}