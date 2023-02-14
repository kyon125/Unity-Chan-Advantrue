using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUISystemMediator : ISystemFacade
{
    private GameObject UIgroup;
    private UI_HpBar m_HpBar;
    public CharacterUISystemMediator(ICharacterManager manager) : base(manager)
    {
        
    }

    public override void Initial()
    {
        m_HpBar = UIgroup.transform.GetComponentInChildren<UI_HpBar>();
    }

    public override void Update()
    {
        
    }
}
