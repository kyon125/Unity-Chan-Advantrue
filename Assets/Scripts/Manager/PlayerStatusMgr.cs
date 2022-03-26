using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusMgr : MonoBehaviour
{
    public static PlayerStatusMgr playerStatusMgr;
    public PlayerAttributeSO playerAttributeSO;
    //public CreatePlayerAttributeSO
    private void Awake()
    {
        if (playerStatusMgr == null)
        {
            playerStatusMgr = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }
    void Start()
    {

    }
}
