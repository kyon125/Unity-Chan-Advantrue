using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICollisionChecker
{
    protected CharacterBasicData m_BasicData;
    protected RaycastHit2D raycastHitOne;
    protected RaycastHit2D raycastHitTwo;
    protected RaycastHit2D raycastHitThree;
    /// <summary>
    /// 每一個Vector3分別代表: 起始點的x , 起始點的y , 射線距離 ，每組射線為三條。
    /// </summary>
    protected List<RaycastGroup> RayCast2DGroups;
    protected List<ICollisionChecker> collisionCheckers;
    public bool DrawRaycastLine { get => _DrawRaycastLine; }
    protected bool _DrawRaycastLine;
    public ICollisionChecker(CharacterBasicData basicData) {
        m_BasicData = basicData;
    }
    public abstract bool HitCheck(Vector3 rayParameterOne , Vector3 rayParameterTwo, Vector3 rayParameterThree, Vector2 direction);
    public abstract void DrawDebugLine(bool show , Vector3 rayParameterOne, Vector3 rayParameterTwo, Vector3 rayParameterThree);
}
public class CollisionCheckerBasic : ICollisionChecker
{
    /// <summary>
    /// 設定射線附加目標
    /// </summary>
    /// <summary>
    /// 初始化射線組
    /// </summary>
    public CollisionCheckerBasic(CharacterBasicData basicData) : base(basicData)
    {
    }
    /// <summary>
    /// 回傳選擇的射線組檢測結果
    /// </summary>
    /// <param name="RaycastNum"></param>
    /// <returns></returns>
    public bool ReturnRayCastResult(RaycastGroup raycastGroup)
    {
        try
        {
            return HitCheck(raycastGroup.raycastOne, raycastGroup.raycastTwo, raycastGroup.raycastThree, raycastGroup.direction);
        }
        catch
        {
            DebugTool.Instance.ShowLogWithColor("You choose 'RaycastNum' return null", Color.red);
            throw;
        }
    }
    public override bool HitCheck(Vector3 rayParameterOne, Vector3 rayParameterTwo, Vector3 rayParameterThree , Vector2 direction)
    {
        Vector3 characterPos = m_BasicData.character.transform.position;
        raycastHitOne = Physics2D.Raycast(new Vector2(characterPos.x + rayParameterOne.x, characterPos.y + rayParameterOne.y), direction, rayParameterOne.z, 1 << 8);
        raycastHitTwo = Physics2D.Raycast(new Vector2(characterPos.x + rayParameterTwo.x, characterPos.y + rayParameterTwo.y), direction, rayParameterTwo.z, 1 << 8);
        raycastHitThree = Physics2D.Raycast(new Vector2(characterPos.x + rayParameterThree.x, characterPos.y + rayParameterThree.y), direction, rayParameterThree.z, 1 << 8);


        //DrawDebugLine(true, rayParameterOne, rayParameterTwo, rayParameterThree);
        if (!raycastHitOne && !raycastHitTwo && !raycastHitThree)
            return false;
        else
            return true;
    }
    public float GetGroundDistance() 
    {
        Vector3 characterPos = m_BasicData.character.transform.position;
        float colliderY = Mathf.Abs(m_BasicData.characterCollider2D.bounds.extents.y - m_BasicData.characterCollider2D.offset.y);
        RaycastHit2D ray = Physics2D.Raycast(new Vector2(characterPos.x, characterPos.y - colliderY), new Vector2(0, -1), 1000f, 1 << 8); ;
        return ray.distance;        
    }
    public override void DrawDebugLine(bool show, Vector3 rayParameterOne, Vector3 rayParameterTwo, Vector3 rayParameterThree)
    {
        if (show)
        {
            Vector3 characterPos = m_BasicData.character.transform.position;

            Debug.DrawLine(new Vector3(characterPos.x + rayParameterOne.x, characterPos.y + rayParameterOne.y, 0),
                new Vector3(characterPos.x + rayParameterOne.x, (characterPos.y + rayParameterOne.y) + rayParameterOne.z, 0),
                raycastHitOne ? Color.green : Color.red);
            Debug.DrawLine(new Vector3(characterPos.x + rayParameterTwo.x, characterPos.y + rayParameterTwo.y, 0),
                new Vector3(characterPos.x + rayParameterTwo.x, (characterPos.y + rayParameterTwo.y) + rayParameterTwo.z, 0),
                raycastHitTwo ? Color.green : Color.red);
            Debug.DrawLine(new Vector3(characterPos.x + rayParameterThree.x, characterPos.y + rayParameterThree.y, 0),
                new Vector3(characterPos.x + rayParameterThree.x, (characterPos.y + rayParameterThree.y) + rayParameterThree.z, 0),
                raycastHitThree ? Color.green : Color.red);
        }
    }
}
[System.Serializable]
public class RaycastGroup
{
    public string name;
    public Vector3 raycastOne;
    public Vector3 raycastTwo;
    public Vector3 raycastThree;
    public Vector2 direction;
}
