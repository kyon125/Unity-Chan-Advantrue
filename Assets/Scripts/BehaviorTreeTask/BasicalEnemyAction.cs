using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class BasicalEnemyAction : ActionTask
{
    public string targetTag;
    private Transform target;
    private MonsterManager manager;
    protected override string OnInit()
    {
        target = GameObject.FindWithTag(targetTag).transform;
        manager = agent.transform.parent.GetComponent<MonsterManager>();
        return base.OnInit();
    }
    protected override void OnExecute()
    {
        if (agent.transform.position.x - target.position.x < 0)
        {
            agent.transform.parent.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            agent.transform.parent.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
    protected override void OnUpdate()
    {
        manager.Action_Move("'Walk");
        EndAction(true);
    }
}
