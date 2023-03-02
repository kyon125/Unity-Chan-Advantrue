using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class BasicalEnemyConditionTask_Death : ConditionTask
{
    private MonsterManager manager;
    protected override string OnInit()
    {
        manager = blackboard.GetVariableValue<MonoBehaviour>("dataManager").GetComponent<MonsterManager>();
        return base.OnInit();
    }
    protected override bool OnCheck()
    {
        if (manager.basicData.characterAttributeSO.GetCurrentHP()>0)
        {
            DebugTool.Instance.ShowLog("Alive");
            return false;
        }
        else
        {
            manager.Action_Dead();
            DebugTool.Instance.ShowLog("Dead");
            return true;
        }

    }

}
