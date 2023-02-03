using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterManager : MonoBehaviour
{
    [Header("玩家參數")]
    public CharacterBasicData basicData;
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
}

