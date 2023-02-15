using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class ICharacterAction
{
    protected CharacterBasicData m_basicData;
    public ICharacterAction(CharacterBasicData basicData)
    {
        m_basicData = basicData;
    }
    public abstract void Initial();
    public abstract void Move(string type, CharacterStatus status);
    public abstract void Jump();
    public abstract void MoveCancel(string type);

    public abstract void Attack(string type);
    public abstract void GetDamage(float value);
}
public class PlayerAction : ICharacterAction
{
    private ConfigParameter parameter;
    public PlayerAction(CharacterBasicData basicData) : base(basicData)
    {
        Initial();
    }
    public override void Initial()
    {
        parameter = GameConfig.Instance.gameConfig.parameter;
    }
    public override void Move(string type, CharacterStatus status)
    {
        float limitSpeed = JudgeLimitSpeed(type , status);
        switch (type)
        {
            case "Walk":
                if (Input.GetAxis("Horizontal") < 0)
                {
                    if (m_basicData.characterRigibody2D.velocity.x >-limitSpeed)
                    {
                        m_basicData.characterRigibody2D.AddForce(new Vector2(-GameConfig.Instance.ConvertSpeed(parameter.addWalkSpeed), 0));
                    }                   
                    m_basicData.characterRigibody2D.velocity = new Vector2(-Mathf.Clamp(Mathf.Abs(m_basicData.characterRigibody2D.velocity.x), 0, limitSpeed), m_basicData.characterRigibody2D.velocity.y);
                }
                else
                {
                    if (m_basicData.characterRigibody2D.velocity.x < limitSpeed)
                    {
                        m_basicData.characterRigibody2D.AddForce(new Vector2(GameConfig.Instance.ConvertSpeed(parameter.addWalkSpeed), 0));
                    }
                    m_basicData.characterRigibody2D.velocity = new Vector2(Mathf.Clamp(Mathf.Abs(m_basicData.characterRigibody2D.velocity.x), 0, limitSpeed), m_basicData.characterRigibody2D.velocity.y);
                }

                break;
            case "Run":
                if (Input.GetAxis("Horizontal") < 0)
                {
                    if (m_basicData.characterRigibody2D.velocity.x > -limitSpeed)
                    {
                        m_basicData.characterRigibody2D.AddForce(new Vector2(-GameConfig.Instance.ConvertSpeed(parameter.addRunSpeed), 0));
                    }
                    m_basicData.characterRigibody2D.velocity = new Vector2(-Mathf.Clamp(Mathf.Abs(m_basicData.characterRigibody2D.velocity.x), 0, limitSpeed), m_basicData.characterRigibody2D.velocity.y);
                }
                else
                {
                    if (m_basicData.characterRigibody2D.velocity.x < limitSpeed)
                    {
                        m_basicData.characterRigibody2D.AddForce(new Vector2(GameConfig.Instance.ConvertSpeed(parameter.addRunSpeed), 0));
                    }                   
                    m_basicData.characterRigibody2D.velocity = new Vector2(Mathf.Clamp(Mathf.Abs(m_basicData.characterRigibody2D.velocity.x), 0, limitSpeed), m_basicData.characterRigibody2D.velocity.y);
                }       
                break;
            case "Jump":
                if(status.statusGround == StatusGround.onGround)
                    Jump();
                break;
        }       
    }
    public override void Jump()
    {
        m_basicData.characterRigibody2D.velocity = new Vector2(m_basicData.characterRigibody2D.velocity.x, GameConfig.Instance.ConvertSpeed(parameter.addJumpSpeed));
    }

    public override void MoveCancel(string type)
    {
        switch (type)
        {
            case "Move":
                m_basicData.characterRigibody2D.velocity *= new Vector2(0.5f, 1);
                break;
            case "Jump":
                m_basicData.characterRigibody2D.velocity *= new Vector2(1, 0.5f);
                break;
        }
    }
   
    public override async void Attack(string type)
    {
        switch (type)
        {
            case "Fire1":
                DebugTool.Instance.ShowLogWithColor("Fire1 Attack", Color.red);
                float damage = m_basicData.characterAttributeSO.GetValueATK();
                await UniTask.Delay(200);
                foreach (var item in m_basicData.characterAttackRange[0].GetComponent<CheckRangeObj>().GetObjects())
                {
                    item.GetComponent<ICharacterManager>().Action_GetDamage(damage);
                }
                break;
        }
    }
    private float JudgeLimitSpeed(string type, CharacterStatus status)
    {
        float limitSpeed = 0;
        switch (type)
        {
            case "Walk":
                if (status.statusGround == StatusGround.onGround)
                    limitSpeed = parameter.maxWalkSpeed;
                else
                    limitSpeed = parameter.maxWalkSpeed * 0.8f;
                break;
            case "Run":
                if (status.statusGround == StatusGround.onGround)
                    limitSpeed = parameter.maxRunSpeed;
                else
                    limitSpeed = parameter.maxRunSpeed * 0.8f;
                break;
        }
        limitSpeed = GameConfig.Instance.ConvertSpeed(limitSpeed);
        return limitSpeed;
    }

    public override void GetDamage(float value)
    {
        m_basicData.characterAttributeSO.HpAlter(-value);
    }
}
#region monsterAction
public class MonsterAction : ICharacterAction
{
    public MonsterAction(CharacterBasicData basicData) : base(basicData)
    {     

    }

    public override void Attack(string type)
    {
        throw new System.NotImplementedException();
    }

    public override void GetDamage(float value)
    {
        m_basicData.characterAttributeSO.HpAlter(-value);
    }

    public override void Initial()
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(string type, CharacterStatus status)
    {
        if (Mathf.Abs(m_basicData.character.transform.localEulerAngles.y) == 180)
        {
            if (m_basicData.characterRigibody2D.velocity.x > -2)
            {
                m_basicData.characterRigibody2D.AddForce(new Vector2(-GameConfig.Instance.ConvertSpeed(1), 0));
            }
            m_basicData.characterRigibody2D.velocity = new Vector2(-Mathf.Clamp(Mathf.Abs(m_basicData.characterRigibody2D.velocity.x), 0, 2), m_basicData.characterRigibody2D.velocity.y);
        }
        else
        {
            if (m_basicData.characterRigibody2D.velocity.x < 2)
            {
                m_basicData.characterRigibody2D.AddForce(new Vector2(GameConfig.Instance.ConvertSpeed(1), 0));
            }
            m_basicData.characterRigibody2D.velocity = new Vector2(Mathf.Clamp(Mathf.Abs(m_basicData.characterRigibody2D.velocity.x), 0, 2), m_basicData.characterRigibody2D.velocity.y);
        }
    }

    public override void MoveCancel(string type)
    {
        m_basicData.characterRigibody2D.velocity *= new Vector2(0.5f, 1);
    }
}
#endregion


