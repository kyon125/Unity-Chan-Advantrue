using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterManager : MonoBehaviour
{
    [Header("產把计")]
    public CharacterBasicData basicData;
}
[System.Serializable]
public class CharacterBasicData
{
    [Header("產把计")]
    public GameObject character;
    public Collider2D characterCollider2D;
    public Rigidbody2D characterRigibody2D;
    public List<RaycastGroup> characterRaycastGroups;
    public Animator characterAnimator;
    public CharacterStatus characterStatus;
}

