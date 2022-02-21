using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public interface CharaterController
{
    //Player水平移動
    public void Move(float speed);

    //Player跳躍
    public void Jump(float speed);
}
public class CharaActionStatus
{
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
}
