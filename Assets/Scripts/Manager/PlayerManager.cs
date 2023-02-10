using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ICharacterManager
{
    public Camera mainCamera;
    #region ¨t²Î²Õ
    private CharacterSystemMediator characterSystem;
   
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        Initial();
    }
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        SystemUpdate();
        ManagerUpdate();
    }
    private void FixedUpdate()
    {
        ManagerFixUpdate();
    }
    public override void Initial()
    {
        characterSystem = new CharacterSystemMediator(this ,basicData);
        basicData.characterAttributeSO.Initial();
    }
    public void SystemUpdate()
    {
        characterSystem.Update();
        DebugTool.Instance.ShowLogWithColor(characterSystem.GetCharacterStatus().statusGround.ToString(), Color.blue);
    }
    public void ManagerUpdate()
    {
        ConnerHitFix();
    }
    public void ManagerFixUpdate()
    {

    }

    #region ManagerUpdateMethod
    public void ConnerHitFix()
    {
        switch (characterSystem.GetCharacterStatus().statusGround)
        {
            case StatusGround.onGround:
                basicData.characterCollider2D.offset = new Vector2(basicData.characterCollider2D.offset.x, -0.03f);
                break;
            case StatusGround.onAir:
                basicData.characterCollider2D.offset = new Vector2(basicData.characterCollider2D.offset.x, 0.03F);
                break;
            default:
                break;
        }
    }
    public float CheckMousePos()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float value = mousePos.x - basicData.characterRigibody2D.transform.position.x;
        return value;
    }
    #endregion
    #region ManagerFixUpdateMethod
    #endregion
    #region method
    public void Action_Move(string type)
    {
        characterSystem.CharacterMove(type);
    }    
    public void Action_MoveCancel(string type)
    {
        characterSystem.CharacterMoveCancel(type);
    }
    public void Action_Attack(string type)
    {
        characterSystem.CharacterAttack(type);
    }
    #endregion
}
