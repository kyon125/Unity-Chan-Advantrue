using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Rigidbody2D playerRigidbody2D;

    //¸I¼²ÀË´ú¤T®g½u ¥ª ÀÉ ¥k
    private RaycastHit2D raycastHitLeft;
    private RaycastHit2D raycastHitCenter;
    private RaycastHit2D raycastHitRight;

    //¥ª°¼¸I¼²ÀË´ú¤T®g½u 
    private RaycastHit2D raycastHitLeftHead;
    private RaycastHit2D raycastHitLeftCenter;
    private RaycastHit2D raycastHitLeftLeg;

    [Header ("¸I¼²ÀË´ú¤T®g½u ¥ª ÀÉ ¥k")]
    public Vector2 raycastLeftValue;
    public Vector2 raycastCenterValue;
    public Vector2 raycastRightValue;
    public float fDistance;
    public float fDistanceCenter;
    [Header("¥ª°¼¸I¼²ÀË´ú¤T®g½u ")]
    public Vector2 raycastHitLeftHeadValue;
    public Vector2 raycastHitLeftCenterValue;
    public Vector2 raycastHitLeftLegValue;
    public float fSideDistance;

    void Start()
    {
        Debug.Log(Physics2D.gravity);
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlayerCollisionRaycastHit();
        CreatePlayerSideCollisionRaycastHit();
        RaycastDrawDebug();
        RaycastDrawSideDebug();
    }
    private void CreatePlayerCollisionRaycastHit()
    {
        raycastHitLeft = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastLeftValue.x, player.transform.position.y + raycastLeftValue.y), Vector2.down, fDistance, 1 << 8);
        raycastHitCenter = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastCenterValue.x, player.transform.position.y + raycastCenterValue.y), Vector2.down, fDistanceCenter, 1 << 8);
        raycastHitRight = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastRightValue.x, player.transform.position.y + raycastRightValue.y), Vector2.down, fDistance, 1 << 8);
        if (raycastHitLeft || raycastHitCenter || raycastHitRight)
        {
            PlayerStatusMgr.instance.playerStatusGround = StatusGround.onGround;
            Debug.Log("onGround is true");
        }
        else if (!raycastHitLeft && !raycastHitCenter && !raycastHitRight)
        {
            PlayerStatusMgr.instance.playerStatusGround = StatusGround.onAir;
            Debug.Log("onGround is false");
        }
    }
    private void CreatePlayerSideCollisionRaycastHit()
    {
        raycastHitLeftHead = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastHitLeftHeadValue.x, player.transform.position.y + raycastHitLeftHeadValue.y), Vector2.left, fSideDistance, 1 << 8);
        raycastHitLeftCenter = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastHitLeftCenterValue.x, player.transform.position.y + raycastHitLeftCenterValue.y), Vector2.left, fSideDistance, 1 << 8);
        raycastHitLeftLeg = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastHitLeftLegValue.x, player.transform.position.y + raycastHitLeftLegValue.y), Vector2.left, fSideDistance, 1 << 8);
        if (raycastHitLeftHead || raycastHitLeftCenter || raycastHitLeftLeg)
        {
            PlayerStatusMgr.instance.playerStatusSide = StatusSide.Left;
            Debug.Log("Left is wall");
        }
        else if (!raycastHitLeftHead && !raycastHitLeftCenter && !raycastHitLeftLeg)
        {
            PlayerStatusMgr.instance.playerStatusSide = StatusSide.None;
            Debug.Log("Left is space");
        }
    }
    public void RaycastDrawDebug()
    {
        Color leftColor = new Color();
        Color centerColor = new Color();
        Color rightColor = new Color();
        if (raycastHitLeft == true)
            leftColor = Color.green;
        else if (raycastHitLeft == false)
            leftColor = Color.red;
        if (raycastHitCenter == true)
            centerColor = Color.green;
        else if (raycastHitCenter == false)
            centerColor = Color.red;
        if (raycastHitRight == true)
            rightColor = Color.green;
        else if (raycastHitRight == false)
            rightColor = Color.red;
        //Debug
        Debug.DrawLine(new Vector3(player.transform.position.x + raycastLeftValue.x, player.transform.position.y + raycastLeftValue.y, 0), new Vector3(player.transform.position.x + raycastLeftValue.x, (player.transform.position.y + raycastLeftValue.y) + fDistance, 0), leftColor);
        Debug.DrawLine(new Vector3(player.transform.position.x + raycastCenterValue.x, player.transform.position.y + raycastCenterValue.y, 0), new Vector3(player.transform.position.x + raycastCenterValue.x, (player.transform.position.y + raycastCenterValue.y) + fDistanceCenter, 0), centerColor);
        Debug.DrawLine(new Vector3(player.transform.position.x + raycastRightValue.x, player.transform.position.y + raycastRightValue.y, 0), new Vector3(player.transform.position.x + raycastRightValue.x, (player.transform.position.y + raycastRightValue.y) + fDistance, 0), rightColor);
    }
    public void RaycastDrawSideDebug()
    {
        Color leftColor = new Color();
        Color centerColor = new Color();
        Color rightColor = new Color();
        if (raycastHitLeftHead)
            leftColor = Color.green;
        else
            leftColor = Color.red;
        if (raycastHitLeftCenter)
            centerColor = Color.green;
        else
            centerColor = Color.red;
        if (raycastHitLeftLeg)
            rightColor = Color.green;
        else
            rightColor = Color.red;      
        //Debug
        Debug.DrawLine(new Vector3(player.transform.position.x + raycastHitLeftHeadValue.x, player.transform.position.y + raycastHitLeftHeadValue.y, 0), new Vector3((player.transform.position.x + raycastHitLeftHeadValue.x) + -fSideDistance, (player.transform.position.y + raycastHitLeftHeadValue.y), 0), leftColor);
        Debug.DrawLine(new Vector3(player.transform.position.x + raycastHitLeftCenterValue.x, player.transform.position.y + raycastHitLeftCenterValue.y, 0), new Vector3((player.transform.position.x + raycastHitLeftCenterValue.x) + -fSideDistance, (player.transform.position.y + raycastHitLeftCenterValue.y), 0), centerColor);
        Debug.DrawLine(new Vector3(player.transform.position.x + raycastHitLeftLegValue.x, player.transform.position.y + raycastHitLeftLegValue.y, 0), new Vector3((player.transform.position.x + raycastHitLeftLegValue.x) + -fSideDistance, (player.transform.position.y + raycastHitLeftLegValue.y), 0), rightColor);
    }
}
