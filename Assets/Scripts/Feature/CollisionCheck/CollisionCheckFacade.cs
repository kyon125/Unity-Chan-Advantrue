using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckFacade : IMediatorServant
{
    private GameObject m_character;
    private Collider2D m_characterCollider2D;
    private Rigidbody2D m_characterRigidbody2D;
    /// <summary>
    /// 每一個Vector3分別代表: 起始點的x , 起始點的y , 射線距離 ，每組射線為三條。
    /// </summary>
    private List<RaycastGroup> RayCast2DGroups;
    private List<ICollisionChecker> collisionCheckers;
    public bool DrawRaycastLine { get => _DrawRaycastLine; }
    private bool _DrawRaycastLine;

    public CollisionCheckFacade(ISystemMediator mediator) : base(mediator) { }

    public  void Initial(GameObject character, Collider2D characterCollider2D, Rigidbody2D characterRigidbody2D, List<RaycastGroup> raycastGroups)
    {
        InitialTarget(character, characterCollider2D, characterRigidbody2D);
        InitialRay(raycastGroups);
    }
    /// <summary>
    /// 設定射線附加目標
    /// </summary>
    private void InitialTarget(GameObject character, Collider2D characterCollider2D, Rigidbody2D characterRigidbody2D) {
        m_character = character;
        m_characterCollider2D = characterCollider2D;
        m_characterRigidbody2D = characterRigidbody2D;
    }
    /// <summary>
    /// 初始化射線組
    /// </summary>
    private void InitialRay(List<RaycastGroup> raycastGroups) {
        RayCast2DGroups = raycastGroups;
        collisionCheckers = new List<ICollisionChecker>();
        for (int i = 0; i < RayCast2DGroups.Count; i++)
        {
            CollisionCheckerBasic raycastCheck = new CollisionCheckerBasic(m_character, m_characterCollider2D, m_characterRigidbody2D, this);
            collisionCheckers.Add(raycastCheck);
        }
    }
    /// <summary>
    /// 回傳選擇的射線組檢測結果
    /// </summary>
    /// <param name="RaycastNum"></param>
    /// <returns></returns>
    public bool ReturnRayCastResult(int RaycastNum)
    {
        try
        {
            return collisionCheckers[RaycastNum].HitCheck(RayCast2DGroups[RaycastNum].raycastOne, RayCast2DGroups[RaycastNum].raycastTwo, RayCast2DGroups[RaycastNum].raycastThree, RayCast2DGroups[RaycastNum].direction);
        }
        catch
        {
            DebugTool.Instance.ShowLogWithColor("You choose 'RaycastNum' return null", Color.red);
            throw;
        }
    }
}
[System.Serializable]
public class RaycastGroup
{
    public string name;
    public Vector3 raycastOne;
    public Vector3 raycastTwo;
    public Vector3 raycastThree;
    public Vector2 direction;
}
