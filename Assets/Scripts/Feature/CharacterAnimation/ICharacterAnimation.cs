using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAnimation
{
    protected float speedX;
    protected float speedY;

    protected Animator m_CharacterAnimator;
    public ICharacterAnimation(Animator animator)
    {
        m_CharacterAnimator = animator;
    }
    public abstract void Idle();

    public abstract void Walk(float speedX);
    public abstract void Jump(float groundDistance, float fallSpeed);
    public abstract void Attack();
}
public class PlayerAnimation : ICharacterAnimation
{
    public PlayerAnimation(Animator animator) : base(animator)
    {
    }

    public override void Attack()
    {
        m_CharacterAnimator.SetBool("Attack1", true);
    }

    public override void Idle()
    {

    }

    public override void Jump(float groundDistance, float fallSpeed)
    {
        m_CharacterAnimator.SetFloat("GroundDistance", groundDistance);
        m_CharacterAnimator.SetFloat("FallSpeed", fallSpeed);
    }

    public override void Walk(float speedX)
    {       
        m_CharacterAnimator.SetFloat("Speed", Mathf.Abs(speedX / GameConfig.Instance.gameConfig.parameter.maxRunSpeed / 2));
    }
}

