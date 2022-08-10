using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusMgr : MonoBehaviour
{
    public static PlayerStatusMgr instance;
    public Camera mainCamera;
    public Rigidbody2D PlayerRigibody;
    public PlayerAttributeSO playerAttributeSO;
    public StatusGround playerStatusGround;
    public StatusBasic playerStatusBasic;
    public StatusSide playerStatusSide;

    //public CreatePlayerAttributeSO
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
    void Start()
    {

    }
    private void FixedUpdate()
    {
        if(playerStatusSide == StatusSide.Left)
            PlayerRigibody.velocity = new Vector2(0, PlayerRigibody.velocity.y);
        else
            PlayerRigibody.velocity = new Vector2(ControllerPlayer.instance.fCurrentLimitSpeed, PlayerRigibody.velocity.y);

    }
    public float CheckMousePos()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float value = mousePos.x - PlayerRigibody.transform.position.x;
        return value;
    }
    public void CheckPlayerStatusBasic(StatusBasic status)
    {
        playerStatusBasic = status;
    }
}
public enum StatusSide
{
    None,
    Left,
    Right,
    Both
}
//�a���W(�a���B�Ť�)
public enum StatusGround
{
    onGround,
    onAir
}
//�򥻪��A(�ݩR�B����)
public enum StatusBasic
{
    Idle,
    Move
}
//����(���`�B�����B�L��)
public enum StatusHurt
{
    Normal,
    Stark,
    Unbreakable
}
