using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterManager : MonoBehaviour
{
    [Header("玩家參數")]
    public CharacterBasicData basicData;
    public Transform uiSystem;
    public abstract void Initial();
    public abstract void Action_Move(string type);
    public abstract void Action_MoveCancel(string type);
    public abstract void Action_Attack(string type);
    public abstract void Action_GetDamage(float damage);
    public abstract void Action_Dead();
}
[System.Serializable]
public class CharacterBasicData
{
    [Header("玩家參數")]
    public GameObject character;
    public Collider2D characterCollider2D;
    public Rigidbody2D characterRigibody2D;
    public List<RaycastGroup> characterRaycastGroups;
    public Animator characterAnimator;
    public CharacterStatus characterStatus;
    public List<Collider2D> characterAttackRange;
    public CharacterAttributeSO characterAttributeSO;
}

