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

    public Vector2 raycastLeftValue;
    public Vector2 raycastCenterValue;
    public Vector2 raycastRightValue;
    public float fDistance;
    public float fDistanceCenter;

    void Start()
    {
        Debug.Log(Physics2D.gravity);
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlayerCollisionRaycastHit();
        RaycastDrawDebug();
    }
    private void CreatePlayerCollisionRaycastHit()
    {
        raycastHitLeft = Physics2D.Raycast(new Vector2(player.transform.position.x +raycastLeftValue.x , player.transform.position.y + raycastLeftValue.y), Vector2.down , fDistance , 1<<8);
        raycastHitCenter = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastCenterValue.x, player.transform.position.y + raycastCenterValue.y), Vector2.down, fDistanceCenter, 1 << 8);
        raycastHitRight = Physics2D.Raycast(new Vector2(player.transform.position.x + raycastRightValue.x, player.transform.position.y + raycastRightValue.y), Vector2.down, fDistance, 1 << 8);
        if (raycastHitLeft == true || raycastHitCenter == true || raycastHitRight == true)
        {
            PlayerStatusMgr.instance.playerStatusGround = StatusGround.onGround;
            Debug.Log("onGround is true");
        }
        else if (raycastHitLeft == false && raycastHitCenter == false && raycastHitRight == false)
        {
            PlayerStatusMgr.instance.playerStatusGround = StatusGround.onAir;
            Debug.Log("onGround is false");
        }

    }
    public void RaycastDrawDebug()
    {
        Color leftColor = new Color();
        Color centerColor = new Color();
        Color rightColor = new Color(); 
        if (raycastHitLeft == true)
            leftColor = Color.green;
        else if(raycastHitLeft == false)
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
}
