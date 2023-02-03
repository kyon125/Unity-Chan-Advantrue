using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterStatus
{
    protected CharacterStatus m_CharacterStatus;
    public ICharacterStatus(CharacterStatus characterStatus) { m_CharacterStatus = characterStatus; }
    public abstract void UpdateCharacterEnvStatus(bool ground, bool left, bool right);    
}
public class PlayerStatus : ICharacterStatus
{
    public PlayerStatus(CharacterStatus characterStatus) : base(characterStatus)
    {
    }
    /// <summary>
    /// ��s����ҳB���Ҫ��A�ܤ�
    /// </summary>
    /// <param name="ground"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    public override void UpdateCharacterEnvStatus(bool ground, bool left, bool right)
    {
        SetCharacterStatusGround(ground);
        SetCharacterStatusSide(left, right);
    }
    private void SetCharacterStatusBasic()
    {
        throw new System.NotImplementedException();
    }

    private void SetCharacterStatusGround(bool ground)
    {
        if (ground)
            m_CharacterStatus.statusGround = StatusGround.onGround;
        else
            m_CharacterStatus.statusGround = StatusGround.onAir;
    }

    private  void SetCharacterStatusSide(bool left, bool right)
    {
        if (left && right)
            m_CharacterStatus.statusSide = StatusSide.Both;
        else if (left)
            m_CharacterStatus.statusSide = StatusSide.Left;
        else if (right)
            m_CharacterStatus.statusSide = StatusSide.Right;
        else
            m_CharacterStatus.statusSide = StatusSide.None;
    }

 
}
public enum StatusSide
{
    None,
    Left,
    Right,
    Both
}
//�a���W(�a���B�Ť�)
public enum StatusGround
{
    onGround,
    onAir
}
//�򥻪��A(�ݩR�B����)
public enum StatusBasic
{
    Idle,
    Move
}
//����(���`�B�����B�L��)
public enum StatusHurt
{
    Normal,
    Stark,
    Unbreakable
}
[System.Serializable]
public class CharacterStatus
{
    public StatusBasic statusBasic;
    public StatusGround statusGround;
    public StatusSide statusSide;
}


