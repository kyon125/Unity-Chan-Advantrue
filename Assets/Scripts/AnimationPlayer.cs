using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    public Rigidbody2D playerRigibody;
    public Animator playerAnimator;
    private float fPlayerSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerStatus();
    }
    public void CheckPlayerStatus()
    {
        fPlayerSpeed = playerRigibody.velocity.x;
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

            

        //switch (PlayerStatusMgr.instance.playerStatusBasic)
        //{
        //    case StatusBasic.Idle:
        //        break;
        //    case StatusBasic.Move:
        //        break;
        //    default:
        //        break;
        //}
    }
}
