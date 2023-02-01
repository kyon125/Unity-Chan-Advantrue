using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationFacade : IMediatorServant
{
    private float groundDistance;
    private Vector3 jumpStartPos;
    private Animator m_Animator;
    private ICharacterAnimation m_CharacterAnimation;
    private CharacterSystemMediator m_CharacterSystem;
    public CharacterAnimationFacade(ISystemMediator mediator, Animator characterAnimator) : base(mediator)
    {
        m_Animator = characterAnimator;
        m_CharacterAnimation = new PlayerAnimation(m_Animator);
        m_CharacterSystem = mediator as CharacterSystemMediator;
    }
    public void AniUpdate(Vector2 rigiVelocity)
    {
        CharacterStatusFacade.Status status = m_CharacterSystem.GetCharacterStatus();
        if (status.statusGround == StatusGround.onGround)
        {
            DebugTool.Instance.ShowLogWithColor("¦³Ä²µo", Color.green);
            m_CharacterAnimation.Walk(rigiVelocity.x);
        }
        m_CharacterAnimation.Jump(groundDistance, rigiVelocity.y);
    }
    public void CallAttackAnimation(string attackName, bool active)
    {
        m_Animator.SetBool(attackName, active);
    }
    public void SetJumpStartPos(Vector3 pos)
    {
        jumpStartPos = pos;
    }
    public Vector3 GetJumpStartPos()
    {
        return jumpStartPos;
    }
    public void SetGroundDistance(float Distance)
    {
        groundDistance = Distance;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="groundDistance">ControllerPlayer.instance.fGroundDistance</param>
    /// <param name="fallSpeed">Rigibody.velocity.y</param>
    public void CheckPlayerJump(float fallSpeed)
    {
        m_CharacterAnimation.Jump(groundDistance, fallSpeed);
    }
    public void ChangePlayerFaceRight(bool isTrue)
    {
        if (isTrue)
            m_Animator.transform.localScale = new Vector3(1, 1, 1);
        else
            m_Animator.transform.localScale = new Vector3(-1, 1, 1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="speedX">Rigibody.velocity.x</param>
    public void SetCharacterWalkAnimation(float speedX)
    {
        m_CharacterAnimation.Walk(speedX);
        switch (m_CharacterSystem.GetCharacterStatus().statusGround)
        {
            case StatusGround.onGround:
                m_CharacterAnimation.Walk(speedX);
                break;
            case StatusGround.onAir:
                break;
            default:
                break;
        }
    }
}
