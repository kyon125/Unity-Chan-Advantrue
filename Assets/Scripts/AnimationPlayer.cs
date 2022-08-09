using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    public static AnimationPlayer instance;
    public Animator playerAnimator;
    private float fPlayerSpeed;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerWalk();
        CheckPlayerJump();
        PlayerFaceDirection();
    }
    public void ChangePlayerFaceRight(bool isTrue)
    {
        if(isTrue)
            playerAnimator.transform.localScale = new Vector3(1, 1, 1);
        else
            playerAnimator.transform.localScale = new Vector3(-1, 1, 1);
    }
    public void CheckPlayerWalk()
    {
        fPlayerSpeed = PlayerStatusMgr.instance.PlayerRigibody.velocity.x;
        if (fPlayerSpeed != 0)
        {
            switch (PlayerStatusMgr.instance.playerStatusGround)
            {
                case StatusGround.onGround:
                    playerAnimator.SetFloat("Speed", Mathf.Abs(fPlayerSpeed / (ControllerPlayer.instance.fMaxWalkHorizontalSpeed * 4)));
                    break;
                case StatusGround.onAir:
                    break;
                default:
                    break;
            }
        }
        else if (fPlayerSpeed == 0)
        {
            switch (PlayerStatusMgr.instance.playerStatusGround)
            {
                case StatusGround.onGround:
                    playerAnimator.SetFloat("Speed", 0);
                    break;
                case StatusGround.onAir:
                    break;
                default:
                    break;
            }
        }
    }
    public void CallAttackAnimation(string attackname)
    {
        playerAnimator.SetBool(attackname, true);
    }
    public void CancelAttackAnimation(string attackname)
    {
        playerAnimator.SetBool(attackname, false);
    }
    public void CheckPlayerJump()
    {
        playerAnimator.SetFloat("GroundDistance", ControllerPlayer.instance.fGroundDistance);
        playerAnimator.SetFloat("FallSpeed", PlayerStatusMgr.instance.PlayerRigibody.velocity.y);
    }
    public void PlayerFaceDirection()
    {
        if (PlayerStatusMgr.instance.playerStatusBasic != StatusBasic.Move)
        {
            if (PlayerStatusMgr.instance.CheckMousePos() >= 0)
            {
                playerAnimator.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("滑鼠在右邊");                
            }
            else if (PlayerStatusMgr.instance.CheckMousePos() < 0)
            {
                playerAnimator.transform.localScale = new Vector3(-1, 1, 1);
                Debug.Log("滑鼠在左邊");                
            }
        }
    }
}
