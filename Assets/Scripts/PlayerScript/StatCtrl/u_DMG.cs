using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class u_DMG : PlayerStatCtrl
{
    public Toggle[] Toggles;
    public Text D_GoldText;
    [HideInInspector] public int D_Toggle;
    [HideInInspector] public int D_Gold;

    private void Start()
    {
        D_Toggle = PlayerPrefs.GetInt("D_Toggle");
        D_Gold = 500;
        D_GoldText.text = D_Gold.ToString() + "∞ÒµÂ";
        LoadToggle();
    }

    public void SaveUpgrade()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[2].isOn == true)
            {
                D_Toggle = 3;
                PlayerPrefs.SetInt("D_Toggle", D_Toggle);
            }
            else if (Toggles[1].isOn == true)
            {
                D_Toggle = 2;
                PlayerPrefs.SetInt("D_Toggle", D_Toggle);
            }
            else if (Toggles[0].isOn == true)
            {
                D_Toggle = 1;
                PlayerPrefs.SetInt("D_Toggle", D_Toggle);
            }
        }
    }

    public void LoadToggle()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            switch (D_Toggle)
            {
                case 1:
                    Toggles[0].isOn = true;
                    D_Gold = 1000;
                    break;
                case 2:
                    Toggles[0].isOn = true;
                    Toggles[1].isOn = true;
                    D_Gold = 1500;
                    break;
                case 3:
                    Toggles[0].isOn = true;
                    Toggles[1].isOn = true;
                    Toggles[2].isOn = true;
                    break;
            }
        }
        playerGold.GoldText.text = PlayerPrefs.GetInt("CurrPlayerGold").ToString();
    }

    public void ResetToggle()
    {
        D_Gold = 500;
        D_GoldText.text = D_Gold.ToString() + "∞ÒµÂ";
        playerGold.currPlayerGold = PlayerPrefs.GetInt("AllPlayerGold");
        playerGold.UpdateGold();
        for (int i = 0; i < Toggles.Length; i++)
        {
            Toggles[i].isOn = false;
        }
    }

    public void OnClickUpgrade()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[i].isOn == false && playerGold.currPlayerGold >= D_Gold)
            {
                upgradeDMG += 5;
                playerGold.currPlayerGold -= D_Gold;
                D_Gold += 500;
                D_GoldText.text = D_Gold.ToString() + "∞ÒµÂ";
                playerGold.UpdateGold();
                SoundManager.instance.SFXPlay("Upgrade", audioSource);
                if (i == 2)
                {
                    D_GoldText.text = "√÷¥Î ∑π∫ß¿‘¥œ¥Ÿ.";
                }
                base.UpdateStat();
                Toggles[i].isOn = true;
                return;
            }
        }
    }
}
