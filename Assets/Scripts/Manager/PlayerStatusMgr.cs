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
//地面上(地面、空中)
public enum StatusGround
{
    onGround,
    onAir
}
//基本狀態(待命、移動)
public enum StatusBasic
{
    Idle,
    Move
}
//受傷(正常、僵直、無敵)
public enum StatusHurt
{
    Normal,
    Stark,
    Unbreakable
}
