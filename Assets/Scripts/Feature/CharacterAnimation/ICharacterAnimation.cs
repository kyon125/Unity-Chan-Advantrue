using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAnimation
{
    protected float speedX;
    protected float speedY;
    protected float groundY;

    protected CharacterBasicData m_basicData;
    public ICharacterAnimation(CharacterBasicData basicData)
    {
        m_basicData = basicData;
    }
    public abstract void AniUpdate(float groundDistance);
    public abstract void Idle();

    public abstract void Walk();
    public abstract void Jump(float groundDistance);
    public abstract void Attack(string attackName);
    public abstract void GetDamage();
}
public class PlayerAnimation : ICharacterAnimation
{
    public PlayerAnimation(CharacterBasicData basicData) : base(basicData)
    {
    }

    public override void AniUpdate(float groundDistance)
    {
        Jump(groundDistance);
        Walk();
    }

    public override void Attack(string attackName)
    {
        m_basicData.characterAnimator.SetBool(attackName, true);
    }

    public override void GetDamage()
    {
        m_basicData.characterAnimator.SetBool("Damage", true);
        if (m_basicData.characterAttributeSO.GetCurrentHP() <= 0)
            m_basicData.characterAnimator.SetBool("IsDead", true);
    }

    public override void Idle()
    {

    }

    public override void Jump(float groundDistance)
    {
        m_basicData.characterAnimator.SetFloat("GroundDistance", groundDistance);
        m_basicData.characterAnimator.SetFloat("FallSpeed", m_basicData.characterRigibody2D.velocity.y);
    }

    public override void Walk()
    {
        m_basicData.characterAnimator.SetFloat("Speed", Mathf.Abs(m_basicData.characterRigibody2D.velocity.x / GameConfig.Instance.gameConfig.parameter.maxRunSpeed / 2));
    }
}

