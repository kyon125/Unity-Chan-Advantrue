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
    public void Initial()
    {
        characterSystem = new CharacterSystemMediator(this);
    }
    public void SystemUpdate()
    {
        characterSystem.Update();
        DebugTool.Instance.ShowLogWithColor(characterSystem.ReturnRayCastResult(0).ToString(), Color.blue);
        DebugTool.Instance.ShowLogWithColor(characterSystem.GetCharacterStatus().statusGround.ToString(), Color.blue);
    }
    public void ManagerUpdate()
    {
        ConnerHitFix();
    }
    public void ManagerFixUpdate()
    {
        LimitCharacterSpeed();
    }

    #region ManagerUpdateMethod
    public void ConnerHitFix()
    {
        switch (characterSystem.GetCharacterStatus().statusGround)
        {
            case StatusGround.onGround:
                characterCollider2D.offset = new Vector2(characterCollider2D.offset.x, -0.03f);
                break;
            case StatusGround.onAir:
                characterCollider2D.offset = new Vector2(characterCollider2D.offset.x, 0.03F);
                break;
            default:
                break;
        }
    }
    public float CheckMousePos()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float value = mousePos.x - characterRigibody2D.transform.position.x;
        return value;
    }
    #endregion
    #region ManagerFixUpdateMethod
    public void LimitCharacterSpeed()
    {
        //    StatusSide characterSide = characterSystem.GetCharacterStatus().statusSide;
        //    if (characterSide == StatusSide.Left)
        //        characterRigibody2D.velocity = new Vector2(Mathf.Clamp(ControllerPlayer.instance.fCurrentLimitSpeed, 0, Mathf.Infinity), characterRigibody2D.velocity.y);
        //    else if (characterSide == StatusSide.Right)
        //        characterRigibody2D.velocity = new Vector2(Mathf.Clamp(ControllerPlayer.instance.fCurrentLimitSpeed, -Mathf.Infinity, 0), characterRigibody2D.velocity.y);
        //    else
        //        characterRigibody2D.velocity = new Vector2(ControllerPlayer.instance.fCurrentLimitSpeed, characterRigibody2D.velocity.y);
        //}
    }
    #endregion
    #region method
    public void Action_Move(string type)
    {
        characterSystem.CharacterMove(type);
        if(characterSystem.GetCharacterStatus().statusGround == StatusGround.onGround)
        {
            characterSystem.SetJumpPosition(character.transform.position);
        }
    }    
    public void Action_MoveCancel(string type)
    {
        characterSystem.CharacterMoveCancel(type);
    }
    #endregion
}
