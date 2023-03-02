using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSystemMediator : ISystemFacade
{
    [SerializeField]
    private CharacterBasicData characterData;
    private MonsterAction characterActionSystem;
    private CollisionCheckerBasic collisionCheckSystem;
    private PlayerAnimation characterAnimationSystem;
    private PlayerStatus characterStatusSystem;
    private UI_HpBar characterHpBar;


    public MonsterSystemMediator(ICharacterManager manager, CharacterBasicData characterBasicData) : base(manager)
    {
        characterData = characterBasicData;
        characterActionSystem = new MonsterAction(characterBasicData);
        collisionCheckSystem = new CollisionCheckerBasic(characterBasicData);
        characterAnimationSystem = new PlayerAnimation(characterBasicData);
        characterStatusSystem = new PlayerStatus(characterBasicData.characterStatus);
        characterHpBar = new UI_HpBar(characterBasicData.characterAttributeSO, manager.uiSystem);
        Initial();
    }

    public override void Initial()
    {
        Physics2D.IgnoreCollision(characterData.characterCollider2D, GameObject.FindWithTag("Player").GetComponent<Collider2D>());
    }
    public override void Update()
    {
        UpdateCharacterBasicalStatus();
        UpdateCharacterAni();
    }
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
        characterActionSystem.Move(type, GetCharacterStatus());
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
    public void CharacterGetHurt(float damage)
    {
        characterActionSystem.GetDamage(damage);
        characterAnimationSystem.GetDamage();
        characterHpBar.Show();
    }

    public IEnumerator IECharacterDead()
    {
        UnityEngine.Object.Destroy(characterData.characterRigibody2D);
        UnityEngine.Object.Destroy(characterData.characterCollider2D);
        yield return new WaitForSeconds(2f);
        DebugTool.Instance.ShowLog("清理屍體");
        UnityEngine.Object.Destroy(characterData.character);
    }
    #endregion

}
