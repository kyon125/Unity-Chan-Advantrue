using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionFacade : IMediatorServant
{
    private ICharacterAction characterAction;
    public CharacterActionFacade(ISystemMediator mediator, Rigidbody2D rigidbody2D) : base(mediator)
    {
        characterAction = new PlayerAction(rigidbody2D);
    }
    public void Move(string type, CharacterStatusFacade.Status status)
    {
        characterAction.Move(type , status);
    }
    public void MoveCancel(string type)
    {
        characterAction.MoveCancel(type);
    }
}
