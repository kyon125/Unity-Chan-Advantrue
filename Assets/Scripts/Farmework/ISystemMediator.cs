using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISystemMediator
{
    protected ICharacterManager m_Manager;
    public ISystemMediator(ICharacterManager manager){
        m_Manager = manager;
    }
    public abstract void Initial();
    public abstract void Update();
}
