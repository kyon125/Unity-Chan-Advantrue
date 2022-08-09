using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour , CharaterController
{
    public static ControllerPlayer instance;
    public float fMaxWalkHorizontalSpeed;
    public float fMaxRunHorizontalSpeed;
    public float fJumpSpeed;
    public float fGroundDistance;
    [HideInInspector]
    public float fCurrentLimitSpeed;
    private float fJumpStartPoint;
    public float fAttackInterval;
    public float fLightAttackJudge;
    public float fLightAttackJudge2;
    public float fBatterAttackJudge;
    public float fBatterAttackJudge2;
    public float fCancelAttackJudge;

    public float fAttackIntervalTimer;
    public bool attackInterval;
    public NormalAttackStatus attackStatus;
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
    }
    private void FixedUpdate()
    {
        
    }
    public void Jump()
    {
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
    }

    public void Move()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            AnimationPlayer.instance.ChangePlayerFaceRight(true);
            PlayerStatusMgr.instance.CheckPlayerStatusBasic(StatusBasic.Move);
            if (Input.GetButton("Run"))
                fCurrentLimitSpeed = fMaxRunHorizontalSpeed;
            else
                fCurrentLimitSpeed = fMaxWalkHorizontalSpeed;
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            AnimationPlayer.instance.ChangePlayerFaceRight(false);
            PlayerStatusMgr.instance.CheckPlayerStatusBasic(StatusBasic.Move);
            if (Input.GetButton("Run"))
                fCurrentLimitSpeed = -fMaxRunHorizontalSpeed;
            else
                fCurrentLimitSpeed = -fMaxWalkHorizontalSpeed;
        }
        else
        {
            PlayerStatusMgr.instance.CheckPlayerStatusBasic(StatusBasic.Idle);
            Debug.Log("Button was released");
            fCurrentLimitSpeed = 0;            
        }
    }
    public void Attack()
    {
        fAttackIntervalTimer += Time.deltaTime;
        if (fAttackIntervalTimer >= fAttackInterval)
        {
            attackInterval = false;
        }
        if (fAttackIntervalTimer > fBatterAttackJudge)
        {
            attackStatus = NormalAttackStatus.attackStep0;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (attackInterval == false)
            {
                switch (attackStatus)
                {
                    case NormalAttackStatus.attackStep0:
                        {
                            AnimationPlayer.instance.CallAttackAnimation("Attack1");
                            fAttackIntervalTimer = 0;
                            attackInterval = true;
                            attackStatus = NormalAttackStatus.attackStep1;
                            Debug.Log("Attack1!");
                        }
                        break;
                    case NormalAttackStatus.attackStep1:
                        {
                            if (fAttackIntervalTimer < fAttackInterval)
                            {
                                attackStatus = NormalAttackStatus.attackStep0;
                            }
                            else if (fAttackIntervalTimer >= fAttackInterval && fAttackIntervalTimer < fLightAttackJudge)
                            {
                                AnimationPlayer.instance.CancelAttackAnimation("Attack1");
                                AnimationPlayer.instance.CallAttackAnimation("Attack1");
                                attackStatus = NormalAttackStatus.attackStep1;
                                fAttackIntervalTimer = 0;
                                Debug.Log("stepAttack1!");
                            }
                            else if (fAttackIntervalTimer >= fLightAttackJudge && fAttackIntervalTimer < fBatterAttackJudge)
                            {
                                AnimationPlayer.instance.CancelAttackAnimation("Attack1");
                                AnimationPlayer.instance.CallAttackAnimation("Attack2");
                                attackStatus = NormalAttackStatus.attackStep2;
                                fAttackIntervalTimer = 0;
                                Debug.Log("stepAttack2!");
                            }
                        }
                        break;
                    case NormalAttackStatus.attackStep2:
                        {
                            if (fAttackIntervalTimer < fAttackInterval)
                            {
                                attackStatus = NormalAttackStatus.attackStep0;
                            }
                            else if (fAttackIntervalTimer >= fAttackInterval && fAttackIntervalTimer < fLightAttackJudge2)
                            {
                                AnimationPlayer.instance.CancelAttackAnimation("Attack1");
                                AnimationPlayer.instance.CallAttackAnimation("Attack1");
                                attackStatus = NormalAttackStatus.attackStep1;
                                fAttackIntervalTimer = 0;
                                Debug.Log("stepAttack1!");
                            }
                            else if (fAttackIntervalTimer >= fLightAttackJudge2 && fAttackIntervalTimer < fBatterAttackJudge2)
                            {                                
                                AnimationPlayer.instance.CallAttackAnimation("Attack3");
                                attackStatus = NormalAttackStatus.attackStep3;
                                fAttackIntervalTimer = 0;
                                Debug.Log("stepAttack3!");
                            }
                        }
                        break;
                    case NormalAttackStatus.attackStep3:
                        break;
                    default:
                        break;
                }
            }
           
        }
    }

}
public interface CharaterController
{
    //Player¤ô¥­²¾°Ê
    public void Move();

    //Player¸õÅD
    public void Jump();
}

public enum NormalAttackStatus
{
    attackStep0,
    attackStep1,
    attackStep2,
    attackStep3
}

