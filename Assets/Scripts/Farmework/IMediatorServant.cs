using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMediatorServant 
{
    protected ISystemMediator m_SystemMediator;
    public IMediatorServant(ISystemMediator mediator) {
        m_SystemMediator = mediator;
    }
}
