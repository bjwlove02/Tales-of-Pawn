using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Accessories
{
    public int p_HP;
    public int heartHP;

    public void Awake()
    {
        accessoryLevel = FindObjectOfType<AccessoryLevel>();
        isActive = false;
        p_HP = PlayerPrefs.GetInt("p_HP");
        heartHP = 10;
    }

    public override void GetAccessory()
    {
        isActive = true;
        CheckLevel();
    }

    public override void Acc_Lv1()
    {
        p_HP += heartHP;
        PlayerPrefs.SetInt("p_HP", p_HP);
    }

    public override void Acc_Lv2()
    {
        p_HP += heartHP;
        PlayerPrefs.SetInt("p_HP", p_HP);
    }

    public override void Acc_Lv3()
    {
        p_HP += heartHP;
        PlayerPrefs.SetInt("p_HP", p_HP);
        max_LVup = true;
    }

    protected override void CheckLevel()
    {
        switch (accessoryLevel.heartLevel)
        {
            case 1:
                Acc_Lv1();
                break;
            case 2:
                Acc_Lv2();
                break;
            case 3:
                Acc_Lv3();
                break;
        }
    }
}
