using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Accessories : MonoBehaviour
{
    [SerializeField] protected AccessoryLevel accessoryLevel;
    [SerializeField] protected Skills skills;

    public bool max_LVup = false;
    public bool isActive = false;

    protected void Start()
    {
        skills = FindObjectOfType<Skills>();
    }

    abstract public void GetAccessory();
    abstract public void Acc_Lv1();
    abstract public void Acc_Lv2();
    abstract public void Acc_Lv3();
    abstract protected void CheckLevel();
}