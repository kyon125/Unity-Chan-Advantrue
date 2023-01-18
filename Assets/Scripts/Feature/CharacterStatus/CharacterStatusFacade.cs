using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusFacade : IMediatorServant
{
    private ICharacterStatus m_character;
    public CharacterStatusFacade(ISystemMediator mediator) : base(mediator)
    {
        m_character = new PlayerStatus(this);
    }
    public void SetCharater(ICharacterStatus character)
    {
        m_character = character;
    }
    /// <summary>
    /// 更新角色所處環境狀態變化
    /// </summary>
    /// <param name="ground"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    public void UpdateCharacterEnvStatus(bool ground, bool left, bool right)
    {
        m_character.SetCharacterStatusGround(ground);
        m_character.SetCharacterStatusSide(left, right);
    }
    public Status GetCharacterStatus()
    {
        return new Status(m_character);
    }
    public class Status
    {
        public StatusBasic statusBasic;
        public StatusGround statusGround;
        public StatusSide statusSide;
        public Status(ICharacterStatus character)
        {
            statusBasic = character.GetCharacterStatusBasic();
            statusGround = character.GetCharacterStatusGround();
            statusSide = character.GetCharacterStatusSide();
        }
    }
}
