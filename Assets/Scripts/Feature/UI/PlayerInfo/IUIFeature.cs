using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUIFeature :MonoBehaviour
{
    protected CharacterAttributeSO m_CharacterData;
    protected Transform m_UISystemParent;
    public IUIFeature(CharacterAttributeSO characterAttributeSO ,Transform parent)
    {
        m_CharacterData = characterAttributeSO;
        m_UISystemParent = parent;
    }
    public abstract void Show();
}

