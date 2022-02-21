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
    //Player��������
    public void Move(float speed);

    //Player���D
    public void Jump(float speed);
}
public class CharaActionStatus
{
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
}
