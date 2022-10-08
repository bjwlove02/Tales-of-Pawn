using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : Accessories
{
    public float accCoolTime = 0;
    public void Awake()
    {
        PlayerPrefs.SetFloat("accCoolTime", accCoolTime);
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
        accCoolTime += 0.1f;
        PlayerPrefs.SetFloat("accCoolTime", accCoolTime);
    }

    public override void Acc_Lv2()
    {
        accCoolTime += 0.1f;
        PlayerPrefs.SetFloat("accCoolTime", accCoolTime);
    }

    public override void Acc_Lv3()
    {
        accCoolTime += 0.1f;
        PlayerPrefs.SetFloat("accCoolTime", accCoolTime);
        max_LVup = true;
    }

    protected override void CheckLevel()
    {
        switch (accessoryLevel.stopwatchLevel)
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
