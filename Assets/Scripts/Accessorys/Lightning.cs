using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Accessories
{
    public float p_Speed;
    public float lightningSpeed;
    public void Awake()
    {
        accessoryLevel = FindObjectOfType<AccessoryLevel>();
        isActive = false;
        p_Speed = PlayerPrefs.GetFloat("p_Speed");
        lightningSpeed = p_Speed / 10;
    }

    public override void GetAccessory()
    {
        isActive = true;
        CheckLevel();
    }

    public override void Acc_Lv1()
    {
        p_Speed += lightningSpeed;
        PlayerPrefs.SetFloat("p_Speed", p_Speed);
    }

    public override void Acc_Lv2()
    {
        p_Speed += lightningSpeed;
        PlayerPrefs.SetFloat("p_Speed", p_Speed);
    }

    public override void Acc_Lv3()
    {
        p_Speed += lightningSpeed;
        PlayerPrefs.SetFloat("p_Speed", p_Speed);
        max_LVup = true;
    }

    protected override void CheckLevel()
    {
        switch (accessoryLevel.lightningLevel)
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
