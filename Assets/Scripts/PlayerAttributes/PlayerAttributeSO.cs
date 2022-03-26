using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateAttributes/CharaAttributes", fileName = "newCharaAttributes")]
public class PlayerAttributeSO : ScriptableObject , CharaBasicalBehavior
{
    [SerializeField]
    private string sTargetName = "DefaultName";
    [SerializeField]
    private int iTargetHP;

    public void Attack(int value)
    {
        throw new System.NotImplementedException();
    }

    public void HpAlter(int value)
    {
        iTargetHP += value;
    }
}
public interface CharaBasicalBehavior
{
    public void Attack(int value);
    public void HpAlter(int value);
}