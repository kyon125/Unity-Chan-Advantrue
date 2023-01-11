using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : IMediatorServant
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

    public CollisionCheck(ISystemMediator mediator) : base(mediator) { }

    public  void Initial(GameObject character, Collider2D characterCollider2D, Rigidbody2D characterRigidbody2D)
    {
        InitialTarget(character, characterCollider2D, characterRigidbody2D);
        InitialRay();
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
    private void InitialRay() {
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
            return collisionCheckers[RaycastNum].HitCheck(RayCast2DGroups[RaycastNum].RaycastOne, RayCast2DGroups[RaycastNum].RaycastTwo, RayCast2DGroups[RaycastNum].RaycastThree);
        }
        catch
        {
            DebugTool.Instance.Show("You choose 'RaycastNum' return null", Color.red);
            throw;
        }
    }
    //private void CreatePlayerCollisionRaycastHit()
    //{
    //    raycastHitLeft = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastLeftValue.x, player.transform.position.y + raycastLeftValue.y), Vector2.down, fDistance, 1 << 8);
    //    raycastHitCenter = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastCenterValue.x, player.transform.position.y + raycastCenterValue.y), Vector2.down, fDistanceCenter, 1 << 8);
    //    raycastHitRight = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastRightValue.x, player.transform.position.y + raycastRightValue.y), Vector2.down, fDistance, 1 << 8);
    //    if (raycastHitLeft || raycastHitCenter || raycastHitRight)
    //    {
    //        PlayerStatusMgr.instance.playerStatusGround = StatusGround.onGround;
    //        Debug.Log("onGround is true");
    //    }
    //    else if (!raycastHitLeft && !raycastHitCenter && !raycastHitRight)
    //    {
    //        PlayerStatusMgr.instance.playerStatusGround = StatusGround.onAir;
    //        Debug.Log("onGround is false");
    //    }
    //}

    //private void CheckPlayerSideCollision()
    //{
    //    if (CreateLeftSideRaycastHit() && CreateRightSideRaycastHit())
    //        PlayerStatusMgr.instance.playerStatusSide = StatusSide.Both;
    //    else if (!CreateLeftSideRaycastHit() && CreateRightSideRaycastHit())
    //        PlayerStatusMgr.instance.playerStatusSide = StatusSide.Right;
    //    else if (CreateLeftSideRaycastHit() && !CreateRightSideRaycastHit())
    //        PlayerStatusMgr.instance.playerStatusSide = StatusSide.Left;
    //    else
    //        PlayerStatusMgr.instance.playerStatusSide = StatusSide.None;
    //}

    //public void ConnerHitFix()
    //{
    //    switch (PlayerStatusMgr.instance.playerStatusGround)
    //    {
    //        case StatusGround.onGround:
    //            playerCollider2D.offset = new Vector2(playerCollider2D.offset.x, -0.03f);
    //            break;
    //        case StatusGround.onAir:
    //            playerCollider2D.offset = new Vector2(playerCollider2D.offset.x, 0.03F);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
[System.Serializable]
public class RaycastGroup
{
    public string Name;
    public Vector3 RaycastOne;
    public Vector3 RaycastTwo;
    public Vector3 RaycastThree;
}
