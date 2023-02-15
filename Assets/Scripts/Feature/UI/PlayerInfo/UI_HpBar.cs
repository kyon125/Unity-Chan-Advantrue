using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UI_HpBar : IUIFeature
{
    public Image imHpMain;
    public TMP_Text txtHpValue;
    public UI_HpBar(CharacterAttributeSO characterAttributeSO, Transform parent) : base(characterAttributeSO, parent)
    {
        Transform target = parent.Find("HpInfo").transform.Find("HPBar").transform;
        imHpMain = target.transform.Find("HPMAIN").GetComponent<Image>();
        txtHpValue = target.transform.Find("HPtext").GetComponent<TMP_Text>();
    }

    public override void Show()
    {        
        float precentHP =(float) (m_CharacterData.GetCurrentHP() / m_CharacterData.GetMaxHP());
        DebugTool.Instance.ShowLog("¦©¼g°Êµe" + precentHP); 
        DOTween.To(() => imHpMain.fillAmount, X => imHpMain.fillAmount = X, precentHP, 0.2F); 
    }
}
