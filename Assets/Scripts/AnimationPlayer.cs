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
public class CharacterAnimator : IMediatorServant
{
    private Animator m_Animator;
    private ICharacterAnimation m_CharacterAnimation;
    public CharacterAnimator(ISystemMediator mediator , Animator characterAnimator) : base(mediator)
    {
        m_Animator = characterAnimator;       
    }
    public void SetPlayerCharacter()
    {
        m_CharacterAnimation = new PlayerAnimation(m_Animator);
    }
    public void CallAttackAnimation(string attackName, bool active)
    {
        m_Animator.SetBool(attackName, active);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="groundDistance">ControllerPlayer.instance.fGroundDistance</param>
    /// <param name="fallSpeed">Rigibody.velocity.y</param>
    public void CheckPlayerJump(float groundDistance , float fallSpeed)
    {
        m_Animator.SetFloat("GroundDistance", groundDistance);
        m_Animator.SetFloat("FallSpeed", fallSpeed);
    }
    public void ChangePlayerFaceRight(bool isTrue)
    {
        if (isTrue)
            m_Animator.transform.localScale = new Vector3(1, 1, 1);
        else
            m_Animator.transform.localScale = new Vector3(-1, 1, 1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="speedX">Rigibody.velocity.x</param>
    public void SetCharacterWalkAnimation(float speedX)
    {
        if (speedX != 0)
        {
            switch (PlayerStatusMgr.instance.playerStatusGround)
            {
                case StatusGround.onGround:
                    playerAnimator.SetFloat("Speed", Mathf.Abs(speedX / (ControllerPlayer.instance.fMaxWalkHorizontalSpeed * 4)));
                    break;
                case StatusGround.onAir:
                    break;
                default:
                    break;
            }
        }
        else if (speedX == 0)
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
}
public abstract class ICharacterAnimation
{
    protected Animator m_CharacterAnimator;
    public ICharacterAnimation(Animator animator)
    {
        m_CharacterAnimator = animator;
    }
    public abstract void Idle();

    public abstract void Walk();
    public abstract void Jump();
    public abstract void Attack();
}
public class PlayerAnimation : ICharacterAnimation
{
    public PlayerAnimation(Animator animator) : base(animator)
    {
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Idle()
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void Walk()
    {
        throw new System.NotImplementedException();
    }
}
