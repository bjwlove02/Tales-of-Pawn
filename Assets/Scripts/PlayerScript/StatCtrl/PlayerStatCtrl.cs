using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatCtrl : MonoBehaviour
{
    [HideInInspector] public int p_HP = 100;
    [HideInInspector] public int p_DMG = 0;
    [HideInInspector] public float p_Speed = 7;
    [HideInInspector] public float p_CoolTime = 7;

    public AudioSource audioSource;

    protected PlayerGold playerGold;

    #region 상점 업그레이드 추가 스탯
    [HideInInspector] public int upgradeHP = 0;
    [HideInInspector] public int upgradeDMG = 0;
    [HideInInspector] public float upgradeSpeed = 0;
    [HideInInspector] public float upgradeCoolTime = 0;
    #endregion

    protected void Awake()
    {
        playerGold = FindObjectOfType<PlayerGold>();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("p_HP", p_HP);
        PlayerPrefs.SetInt("p_DMG", p_DMG);
        PlayerPrefs.SetFloat("p_Speed", p_Speed);
        PlayerPrefs.SetFloat("p_CoolTime", p_CoolTime);
    }

    public void UpdateStat()
    {
        PlayerPrefs.SetInt("upgradeHP", upgradeHP);
        PlayerPrefs.SetInt("upgradeDMG", upgradeDMG);
        PlayerPrefs.SetFloat("upgradeSpeed", upgradeSpeed);
        PlayerPrefs.SetFloat("upgradeCoolTime", upgradeCoolTime);
    }
}
