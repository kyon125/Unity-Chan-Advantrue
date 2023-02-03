using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAttack
{
    public ICharacterAttack(ISystemMediator SystemMediator)
    {
    }
    public abstract void AnimationPlay();
    public abstract void MusicPlay();
    public abstract void EffectPlay();
}
public class SwordAttack : ICharacterAttack
{
    private CharacterAttackFacade mediator;
    public SwordAttack(CharacterAttackFacade SystemMediator ) : base(SystemMediator)
    {
        mediator = SystemMediator;
    }

    public override void AnimationPlay()
    {
        
    }

    public override void EffectPlay()
    {
        throw new System.NotImplementedException();
    }

    public override void MusicPlay()
    {
        throw new System.NotImplementedException();
    }
}
