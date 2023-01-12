using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ICharacterManager
{ 

    #region ¨t²Î²Õ
    private CharacterSystemMediator characterSystem;
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        Initial();
    }
    private void Start(){

    }

    // Update is called once per frame
    private void Update()
    {
        SystemUpdate();
    }
    public void Initial() {
        characterSystem = new CharacterSystemMediator(this);
    }
    public void SystemUpdate()
    {
        DebugTool.Instance.Show(characterSystem.ReturnRayCastResult(0).ToString(), Color.blue);
    }
}
