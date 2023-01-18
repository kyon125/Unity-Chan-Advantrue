using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystemMediator : ISystemMediator
{
    [SerializeField]
    private CollisionCheckFacade collisionCheckSystem;
    private CharacterStatusFacade characterStatusSystem;
    public CharacterSystemMediator(ICharacterManager manager) :base (manager)
    {
        Initial();
    }
    public override void Initial()
    {
        collisionCheckSystem = new CollisionCheckFacade(this);
        characterStatusSystem = new CharacterStatusFacade(this);
        collisionCheckSystem.Initial(m_Manager.character, m_Manager.characterCollider2D, m_Manager.characterRigibody2D, m_Manager.characterRaycastGroups);
        DebugTool.Instance.Show("collisionCheckSystem is initial", Color.blue);
    }
    public override void Update()
    {
        UpdateCharacterBasicalStatus();
    }
    #region CollisionCheck
    public void CollisionCheckInitial()
    {
        collisionCheckSystem.Initial(m_Manager.character, m_Manager.characterCollider2D, m_Manager.characterRigibody2D, m_Manager.characterRaycastGroups);
    }
    public bool ReturnRayCastResult(int RaycastNum)
    {
        return collisionCheckSystem.ReturnRayCastResult(RaycastNum);
    }
    #endregion
    #region CharacterStatusFacade
    public void UpdateCharacterBasicalStatus()
    {
        bool ground = ReturnRayCastResult(0);
        bool left = ReturnRayCastResult(1);
        bool right = ReturnRayCastResult(2);
        characterStatusSystem.UpdateCharacterEnvStatus(ground, left, right);
    }
    public CharacterStatusFacade.Status  GetCharacterStatus()
    {
        return characterStatusSystem.GetCharacterStatus();
    }
    #endregion
    #region ¥¼¤ÀÃþ

    #endregion
}

