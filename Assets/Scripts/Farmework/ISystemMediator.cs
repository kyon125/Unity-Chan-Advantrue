using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISystemMediator 
{
    protected ISystemFacade m_SystemMediator;
    public ISystemMediator(ISystemFacade Facade) {
        m_SystemMediator = Facade;
    }
}
