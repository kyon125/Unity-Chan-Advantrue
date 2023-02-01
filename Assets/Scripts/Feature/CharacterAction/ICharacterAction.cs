using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAction
{
    protected Rigidbody2D m_rigidbody2D;
    public ICharacterAction(Rigidbody2D rigidbody2D)
    {
        m_rigidbody2D = rigidbody2D;
    }
    public abstract void Move(string type, CharacterStatusFacade.Status status);
    public abstract void Jump();
    public abstract void MoveCancel(string type);
}
public class PlayerAction : ICharacterAction
{
    private ConfigParameter parameter;
    public PlayerAction(Rigidbody2D rigidbody2D) : base(rigidbody2D)
    {
        Initial();
    }
    private void Initial()
    {
        parameter = GameConfig.Instance.gameConfig.parameter;
    }
    public override void Move(string type, CharacterStatusFacade.Status status)
    {
        float limitSpeed = JudgeLimitSpeed(type , status);
        switch (type)
        {
            case "Walk":
                if (Input.GetAxis("Horizontal") < 0)
                {
                    if (m_rigidbody2D.velocity.x >-limitSpeed)
                    {
                        m_rigidbody2D.AddForce(new Vector2(-GameConfig.Instance.ConvertSpeed(parameter.addWalkSpeed), 0));
                    }                   
                    m_rigidbody2D.velocity = new Vector2(-Mathf.Clamp(Mathf.Abs(m_rigidbody2D.velocity.x), 0, limitSpeed), m_rigidbody2D.velocity.y);
                }
                else
                {
                    if (m_rigidbody2D.velocity.x < limitSpeed)
                    {
                        m_rigidbody2D.AddForce(new Vector2(GameConfig.Instance.ConvertSpeed(parameter.addWalkSpeed), 0));
                    }
                    m_rigidbody2D.velocity = new Vector2(Mathf.Clamp(Mathf.Abs(m_rigidbody2D.velocity.x), 0, limitSpeed), m_rigidbody2D.velocity.y);
                }

                break;
            case "Run":
                if (Input.GetAxis("Horizontal") < 0)
                {
                    if (m_rigidbody2D.velocity.x > -limitSpeed)
                    {
                        m_rigidbody2D.AddForce(new Vector2(-GameConfig.Instance.ConvertSpeed(parameter.addRunSpeed), 0));
                    }
                    m_rigidbody2D.velocity = new Vector2(-Mathf.Clamp(Mathf.Abs(m_rigidbody2D.velocity.x), 0, limitSpeed), m_rigidbody2D.velocity.y);
                }
                else
                {
                    if (m_rigidbody2D.velocity.x < limitSpeed)
                    {
                        m_rigidbody2D.AddForce(new Vector2(GameConfig.Instance.ConvertSpeed(parameter.addRunSpeed), 0));
                    }                   
                    m_rigidbody2D.velocity = new Vector2(Mathf.Clamp(Mathf.Abs(m_rigidbody2D.velocity.x), 0, limitSpeed), m_rigidbody2D.velocity.y);
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
        m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, GameConfig.Instance.ConvertSpeed(parameter.addJumpSpeed));
    }

    public override void MoveCancel(string type)
    {
        switch (type)
        {
            case "Move":
                m_rigidbody2D.velocity *= new Vector2(0.5f, 1);
                break;
            case "Jump":
                m_rigidbody2D.velocity *= new Vector2(1, 0.5f);
                break;
        }
    }
    private float JudgeLimitSpeed(string type, CharacterStatusFacade.Status status)
    {
        float limitSpeed = 0;
        switch (type)
        {
            case "Walk":
                if (status.statusGround == StatusGround.onGround)
                    limitSpeed =  parameter.maxWalkSpeed;
                else
                    limitSpeed =  parameter.maxWalkSpeed * 0.8f;
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
}

