using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISystemFacade
{
    protected ICharacterManager m_Manager;
    public ISystemFacade(ICharacterManager manager){
        m_Manager = manager;
    }
    public abstract void Initial();
    public abstract void Update();
}
