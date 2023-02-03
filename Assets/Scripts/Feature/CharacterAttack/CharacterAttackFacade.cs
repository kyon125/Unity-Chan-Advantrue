using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackFacade : ISystemMediator
{
    private ICharacterAttack characterAttack;
    public CharacterAttackFacade(CharacterSystemMediator mediator , ICharacterAttack Attack) : base(mediator)
    {
        characterAttack = Attack;
    }
}
