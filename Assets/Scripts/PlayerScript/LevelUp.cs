using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public float needExp;
    public float maxExp = 5;
    public int curLevel = 1;
    private InGameUICtrl inGameUICtrl;
    GetItem getItem;

    private void Awake()
    {
        inGameUICtrl = GameObject.Find("InGameUI").GetComponent<InGameUICtrl>();
        getItem = GetComponent<GetItem>();
        needExp = maxExp;
    }

    private void Update()
    {
        LevelUpExp();
    }

    public float GetCurrEXP()
    {
        return getItem.exp;
    }

    public void LevelUpExp()
    {
        if (getItem.exp >= needExp)
        {
            curLevel += 1;
            maxExp *= 1.3f;
            getItem.exp = 0;
            needExp = maxExp;
            inGameUICtrl.LevelUP();
        }
    }
}
