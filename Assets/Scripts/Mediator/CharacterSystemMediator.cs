using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystemMediator : ISystemFacade
{
    [SerializeField]
    private CharacterBasicData characterData;
    private PlayerAction characterActionSystem;
    private CollisionCheckerBasic collisionCheckSystem;
    private PlayerAnimation characterAnimationSystem;
    private PlayerStatus characterStatusSystem;


    public CharacterSystemMediator(ICharacterManager manager , CharacterBasicData characterBasicData) :base (manager)
    {
        characterData = characterBasicData;
        characterActionSystem = new PlayerAction(characterBasicData.characterRigibody2D);
        collisionCheckSystem = new CollisionCheckerBasic(characterBasicData);
        characterAnimationSystem = new PlayerAnimation(characterBasicData);
        characterStatusSystem = new PlayerStatus(characterBasicData.characterStatus);

        Initial();
    }
    public override void Initial()
    { 
      
    }
    public override void Update()
    {
        UpdateCharacterBasicalStatus();
        UpdateCharacterAni();
    }
    #region CollisionCheck
    #endregion
    #region CharacterStatusFacade
    public void UpdateCharacterBasicalStatus()
    {
        bool ground = collisionCheckSystem.ReturnRayCastResult(characterData.characterRaycastGroups[0]);
        bool left = collisionCheckSystem.ReturnRayCastResult(characterData.characterRaycastGroups[1]);
        bool right = collisionCheckSystem.ReturnRayCastResult(characterData.characterRaycastGroups[2]);
        characterStatusSystem.UpdateCharacterEnvStatus(ground, left, right);
    }
    public CharacterStatus GetCharacterStatus()
    {
        return characterData.characterStatus;
    }
    #endregion
    #region CharacterAnimationFacade
    public void UpdateCharacterAni()
    {
        characterAnimationSystem.AniUpdate(collisionCheckSystem.GetGroundDistance());
    }
    #endregion
    #region CharacterActionFacade
    public void CharacterMove(string type)
    {
        characterActionSystem.Move(type , GetCharacterStatus());
    }
    public void CharacterMoveCancel(string type)
    {
        characterActionSystem.MoveCancel(type);
    }
    public void CharacterAttack(string type)
    {
        characterActionSystem.Attack(type);
        characterAnimationSystem.Attack("Attack2");
    }
    #endregion
    #region ������

    #endregion
}

