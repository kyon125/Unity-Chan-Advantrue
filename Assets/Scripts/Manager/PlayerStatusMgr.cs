using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusMgr : MonoBehaviour
{
    public static PlayerStatusMgr instance;
    public PlayerAttributeSO playerAttributeSO;
    public StatusGround playerStatusGround;
    public StatusBasic playerStatusBasic;
    
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
