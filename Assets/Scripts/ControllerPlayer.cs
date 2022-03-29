using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour , CharaterController
{
    public static ControllerPlayer instance;
    public Rigidbody2D PlayerRigibody;
    public Camera mainCamera;
    public float fMaxWalkHorizontalSpeed;
    public float fMaxRunHorizontalSpeed;
    public float fJumpSpeed;
    public float fGroundDistance;
    private float fCurrentLimitSpeed;
    private float fJumpStartPoint;
    public float fAttackInterval;
    private float fAttackIntervalTimer;
    public bool attackInterval;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        Attack();
        PlayerFaceDirection();
    }
    private void FixedUpdate()
    {
        PlayerRigibody.velocity = new Vector2(fCurrentLimitSpeed, PlayerRigibody.velocity.y);
    }
    public void Jump()
    {
        fGroundDistance = PlayerRigibody.transform.position.y - fJumpStartPoint;
        if (Input.GetButtonDown("Jump") && PlayerStatusMgr.instance.playerStatusGround == StatusGround.onGround)
        {
            fJumpStartPoint = PlayerRigibody.transform.position.y;
            Debug.Log("jumping");
            PlayerRigibody.velocity = new Vector2(PlayerRigibody.velocity.x, fJumpSpeed);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            PlayerRigibody.velocity = PlayerRigibody.velocity * new Vector2(1, .5f);
        }
        if (PlayerStatusMgr.instance.playerStatusGround == StatusGround.onGround)
            fGroundDistance = 0;        
    }

    public void Move()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            //PlayerRigibody.transform.localScale = new Vector3(1, 1, 1);
            if (Input.GetButton("Run"))
                fCurrentLimitSpeed = fMaxRunHorizontalSpeed;
            else
                fCurrentLimitSpeed = fMaxWalkHorizontalSpeed;
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            //PlayerRigibody.transform.localScale = new Vector3(-1, 1, 1);
            if (Input.GetButton("Run"))
                fCurrentLimitSpeed = -fMaxRunHorizontalSpeed;
            else
                fCurrentLimitSpeed = -fMaxWalkHorizontalSpeed;
        }
        else
        {
            Debug.Log("Button was released");
            fCurrentLimitSpeed = 0;            
        }
    }
    public void Attack()
    {        
        if (Input.GetButtonDown("Fire1")&& attackInterval == false)
        {
            AnimationPlayer.instance.CallAttackAnimation("Attack1");
            fAttackIntervalTimer = 0;
            attackInterval = true;
            Debug.Log("Attack!");
        }
        //設定攻擊間隔
        if (attackInterval == true)
        {
            fAttackIntervalTimer += Time.deltaTime;
            if (fAttackIntervalTimer >= fAttackInterval)
            {
                attackInterval = false;
            }
        }
    }
    public void PlayerFaceDirection()
    {
        if (CheckMousePos() >= 0)
        {
            Debug.Log("滑鼠在右邊");
            PlayerRigibody.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (CheckMousePos() < 0)
        {
            Debug.Log("滑鼠在左邊");
            PlayerRigibody.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public float CheckMousePos()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float value = mousePos.x - PlayerRigibody.transform.position.x;
        return value;
    }
}
public interface CharaterController
{
    //Player水平移動
    public void Move();

    //Player跳躍
    public void Jump();
}


