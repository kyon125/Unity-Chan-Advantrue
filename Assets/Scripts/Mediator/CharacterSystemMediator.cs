using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystemMediator : ISystemMediator
{
    [SerializeField]
    private CollisionCheck collisionCheckSystem;
    public CharacterSystemMediator(ICharacterManager manager) :base (manager)
    {
        Initial();
    }
    public override void Initial()
    {
        collisionCheckSystem = new CollisionCheck(this);
        collisionCheckSystem.Initial(m_Manager.character, m_Manager.characterCollider2D, m_Manager.characterRigibody2D, m_Manager.characterRaycastGroups);
        DebugTool.Instance.Show("collisionCheckSystem is initial", Color.blue);
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
}

