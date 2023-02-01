using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer :MonoBehaviour
{
    public PlayerManager manager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        //Move();
        Attack();
    }
    public void FixedUpdate()
    {
        Move();
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            manager.Action_Move("Jump");       
        }
        else if (Input.GetButtonUp("Jump"))
        {
            manager.Action_MoveCancel("Jump");
            DebugTool.Instance.ShowLog("Jumping release");
        }
    }
    /*
            fGroundDistance = PlayerStatusMgr.instance.PlayerRigibody.transform.position.y - fJumpStartPoint;
        if (Input.GetButtonDown("Jump") && PlayerStatusMgr.instance.playerStatusGround == StatusGround.onGround)
        {
            fJumpStartPoint = PlayerStatusMgr.instance.PlayerRigibody.transform.position.y;
            Debug.Log("jumping");
            PlayerStatusMgr.instance.PlayerRigibody.velocity = new Vector2(PlayerStatusMgr.instance.PlayerRigibody.velocity.x, fJumpSpeed);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            PlayerStatusMgr.instance.PlayerRigibody.velocity = PlayerStatusMgr.instance.PlayerRigibody.velocity * new Vector2(1, .5f);
        }
        if (PlayerStatusMgr.instance.playerStatusGround == StatusGround.onGround)
            fGroundDistance = 0;        
    */

    public void Move()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            manager.character.transform.localEulerAngles = new Vector3(0, 0, 0 );
            if (Input.GetButton("Run"))
            {
                manager.Action_Move("Run");
                DebugTool.Instance.ShowLog("RunRight");
            }               
            else
            {
                manager.Action_Move("Walk");
                DebugTool.Instance.ShowLog("WalkRight");
            }
           
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            manager.character.transform.localEulerAngles = new Vector3(0, 180, 0);

            if (Input.GetButton("Run"))
            {
                manager.Action_Move("Run");
                DebugTool.Instance.ShowLog("RunLeft");
            }           
            else
            {
                manager.Action_Move("Walk");
                DebugTool.Instance.ShowLog("WalkLeft");
            }            
        }
        else
        {
            manager.Action_MoveCancel("Move");
            DebugTool.Instance.ShowLog("Move button was released");
        }
    }
    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DebugTool.Instance.ShowLogWithColor("fire" , Color.red);
        }
    }

}

