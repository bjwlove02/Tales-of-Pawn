using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Accessories
{
    public int accDMG = 0;

    public void Awake()
    {
        PlayerPrefs.SetInt("accDMG", accDMG);
        accessoryLevel = FindObjectOfType<AccessoryLevel>();
        isActive = false;
    }

    public override void GetAccessory()
    {
        isActive = true;
        CheckLevel();
    }

    public override void Acc_Lv1()
    {
        accDMG = 10;
        PlayerPrefs.SetInt("accDMG", accDMG);
    }

    public override void Acc_Lv2()
    {
        accDMG = 20;
        PlayerPrefs.SetInt("accDMG", accDMG);
    }

    public override void Acc_Lv3()
    {
        accDMG = 30;
        PlayerPrefs.SetInt("accDMG", accDMG);
        max_LVup = true;
    }

    protected override void CheckLevel()
    {
        switch (accessoryLevel.swordLevel)
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
