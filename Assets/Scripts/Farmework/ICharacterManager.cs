using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterManager : MonoBehaviour
{
    [Header("ª±®a°Ñ¼Æ")]
    public GameObject character;
    public Collider2D characterCollider2D;
    public Rigidbody2D characterRigibody2D;
    public List<RaycastGroup> characterRaycastGroups;
    public Animator characterAnimator;
}
