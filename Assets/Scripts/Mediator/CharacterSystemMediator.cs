using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystemMediator : ISystemMediator
{
    [SerializeField]
    private CollisionCheckFacade collisionCheckSystem;
    private CharacterStatusFacade characterStatusSystem;
    private CharacterAnimationFacade characterAnimationSystem;
    private CharacterActionFacade characterActionSystem;

    public CharacterSystemMediator(ICharacterManager manager) :base (manager)
    {
        Initial();
    }
    public override void Initial()
    {
        collisionCheckSystem = new CollisionCheckFacade(this);
        characterStatusSystem = new CharacterStatusFacade(this);
        characterAnimationSystem = new CharacterAnimationFacade(this , m_Manager.characterAnimator);
        characterActionSystem = new CharacterActionFacade(this, m_Manager.characterRigibody2D);

        collisionCheckSystem.Initial(m_Manager.character, m_Manager.characterCollider2D, m_Manager.characterRigibody2D, m_Manager.characterRaycastGroups);
        DebugTool.Instance.ShowLogWithColor("collisionCheckSystem is initial", Color.blue);
    }
    public override void Update()
    {
        UpdateCharacterBasicalStatus();
        UpdateCharacterAni();
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
    #region CharacterAnimationFacade
    public void SetJumpPosition(Vector3 pos)
    {
        characterAnimationSystem.SetJumpStartPos(pos);
    }
    public void UpdateCharacterAni()
    {
        if (characterStatusSystem.GetCharacterStatus().statusGround == StatusGround.onAir)
            if(m_Manager.characterRigibody2D.velocity.y >=0)
                characterAnimationSystem.SetGroundDistance(m_Manager.character.transform.position.y - characterAnimationSystem.GetJumpStartPos().y);
            else
                characterAnimationSystem.SetGroundDistance(0.2f);
        else
            characterAnimationSystem.SetGroundDistance(0);
        characterAnimationSystem.AniUpdate(m_Manager.characterRigibody2D.velocity);
    }
    #endregion
    #region CharacterActionFacade
    public void CharacterMove(string type)
    {
        CharacterStatusFacade.Status status = characterStatusSystem.GetCharacterStatus();
        characterActionSystem.Move(type, status);
    }
    public void CharacterMoveCancel(string type)
    {
        characterActionSystem.MoveCancel(type);
    }
    #endregion
    #region ¥¼¤ÀÃþ

    #endregion
}

