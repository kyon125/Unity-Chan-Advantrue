using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICollisionChecker
{
    protected GameObject m_Character;
    protected Collider2D m_CharacterCollider2D;
    protected Rigidbody2D m_CharacterRigidbody2D;
    protected CollisionCheck m_Manager;
    protected RaycastHit2D raycastHitOne;
    protected RaycastHit2D raycastHitTwo;
    protected RaycastHit2D raycastHitThree;
    public ICollisionChecker(GameObject character , Collider2D collider2D , Rigidbody2D rigidbody2D , CollisionCheck Manager) {
        m_Character = character;
        m_CharacterCollider2D = collider2D;
        m_CharacterRigidbody2D = rigidbody2D;
        m_Manager = Manager;
    }
    public abstract bool HitCheck(Vector3 rayParameterOne , Vector3 rayParameterTwo, Vector3 rayParameterThree);
    public  abstract void DrawDebugLine(bool show , Vector3 rayParameterOne, Vector3 rayParameterTwo, Vector3 rayParameterThree);
}
public class CollisionCheckerBasic : ICollisionChecker
{
    public CollisionCheckerBasic(GameObject character, Collider2D collider2D, Rigidbody2D rigidbody2D, CollisionCheck Manager) : base(character, collider2D, rigidbody2D, Manager)
    {
    }
    public override bool HitCheck(Vector3 rayParameterOne, Vector3 rayParameterTwo, Vector3 rayParameterThree)
    {
        raycastHitOne = Physics2D.Raycast(new Vector2(m_Character.transform.position.x + rayParameterOne.x, m_Character.transform.position.y + rayParameterOne.y), Vector2.down, rayParameterOne.z, 1 << 8);
        raycastHitTwo = Physics2D.Raycast(new Vector2(m_Character.transform.position.x + rayParameterTwo.x, m_Character.transform.position.y + rayParameterTwo.y), Vector2.down, rayParameterTwo.z, 1 << 8);
        raycastHitThree = Physics2D.Raycast(new Vector2(m_Character.transform.position.x + rayParameterThree.x, m_Character.transform.position.y + rayParameterThree.y), Vector2.down, rayParameterThree.z, 1 << 8);
        DrawDebugLine(m_Manager.DrawRaycastLine, rayParameterOne, rayParameterTwo, rayParameterThree);
        if (!raycastHitOne && !raycastHitTwo && !raycastHitThree)
            return false;
        else
            return true;
    }
    public override void DrawDebugLine(bool show, Vector3 rayParameterOne, Vector3 rayParameterTwo, Vector3 rayParameterThree)
    {
        if (show)
        {
            Debug.DrawLine(new Vector3(m_Character.transform.position.x + rayParameterOne.x, m_Character.transform.position.y + rayParameterOne.y, 0),
                new Vector3(m_Character.transform.position.x + rayParameterOne.x, (m_Character.transform.position.y + rayParameterOne.y) + rayParameterOne.z, 0),
                raycastHitOne ? Color.green : Color.red);
            Debug.DrawLine(new Vector3(m_Character.transform.position.x + rayParameterTwo.x, m_Character.transform.position.y + rayParameterTwo.y, 0),
                new Vector3(m_Character.transform.position.x + rayParameterTwo.x, (m_Character.transform.position.y + rayParameterTwo.y) + rayParameterTwo.z, 0),
                raycastHitTwo ? Color.green : Color.red);
            Debug.DrawLine(new Vector3(m_Character.transform.position.x + rayParameterThree.x, m_Character.transform.position.y + rayParameterThree.y, 0),
                new Vector3(m_Character.transform.position.x + rayParameterThree.x, (m_Character.transform.position.y + rayParameterThree.y) + rayParameterThree.z, 0),
                raycastHitThree ? Color.green : Color.red);
        }
    }
}
