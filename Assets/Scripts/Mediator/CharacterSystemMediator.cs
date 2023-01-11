using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystemMediator : ISystemMediator
{
    [SerializeField]
    private CollisionCheck collisionCheckSystem;
    public override void Initial()
    {
        collisionCheckSystem = new CollisionCheck(this);
    }
    #region CollisionCheck
    public void CollisionCheckInitial(GameObject character, Collider2D characterCollider2D, Rigidbody2D characterRigidbody2D) {
        collisionCheckSystem.Initial(character, characterCollider2D, characterRigidbody2D);
    }
    #endregion
}
