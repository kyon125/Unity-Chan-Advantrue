using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterStatus
{
    public ICharacterStatus(IMediatorServant Facade) { m_Facade = Facade; }
    protected IMediatorServant m_Facade;
    protected StatusGround m_characterStatusGround = new StatusGround();
    protected StatusBasic m_characterStatusBasic = new StatusBasic();
    protected StatusSide m_characterStatusSide = new StatusSide();

    public abstract void SetCharacterStatusGround(bool ground);
    public abstract void SetCharacterStatusBasic();
    public abstract void SetCharacterStatusSide(bool left, bool right);
    public abstract StatusGround GetCharacterStatusGround();
    public abstract StatusBasic GetCharacterStatusBasic();
    public abstract StatusSide GetCharacterStatusSide();
}
public class PlayerStatus : ICharacterStatus
{
    public PlayerStatus(CharacterStatusFacade Facade) : base(Facade)
    {
        Facade.SetCharater(this);
    }

    public override StatusBasic GetCharacterStatusBasic()
    {
        return m_characterStatusBasic;
    }

    public override StatusGround GetCharacterStatusGround()
    {
        return m_characterStatusGround;
    }

    public override StatusSide GetCharacterStatusSide()
    {
        return m_characterStatusSide;
    }


    public override void SetCharacterStatusBasic()
    {
        throw new System.NotImplementedException();
    }

    public override void SetCharacterStatusGround(bool ground)
    {
        if (ground)
            m_characterStatusGround = StatusGround.onGround;
        else
            m_characterStatusGround = StatusGround.onAir;
    }

    public override void SetCharacterStatusSide(bool left, bool right)
    {
        if (left && right)
            m_characterStatusSide = StatusSide.Both;
        else if (left)
            m_characterStatusSide = StatusSide.Left;
        else if (right)
            m_characterStatusSide = StatusSide.Right;
        else
            m_characterStatusSide = StatusSide.None;
    }
}
public enum StatusSide
{
    None,
    Left,
    Right,
    Both
}
//地面上(地面、空中)
public enum StatusGround
{
    onGround,
    onAir
}
//基本狀態(待命、移動)
public enum StatusBasic
{
    Idle,
    Move
}
//受傷(正常、僵直、無敵)
public enum StatusHurt
{
    Normal,
    Stark,
    Unbreakable
}


