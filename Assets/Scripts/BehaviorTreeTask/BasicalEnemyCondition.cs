using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class BasicalEnemyCondition : ConditionTask
{
    private MonsterManager manager;
    private CheckRangeObj rangeObj;
    protected override string OnInit()
    {
        manager = agent.transform.GetComponentInParent<MonsterManager>();
        rangeObj = manager.basicData.characterAttackRange[0].GetComponent<CheckRangeObj>();
        return base.OnInit();
    }
    protected override bool OnCheck()
    {
        if (rangeObj.GetObjects().Count > 0)
        {
            manager.Action_MoveCancel("Walk");
            DebugTool.Instance.ShowLog("���i�H�����ؼ�");
            return true;
        }
        else
        {
            DebugTool.Instance.ShowLog("�S�������ؼ�");
            return false;
        }           
    }
}
