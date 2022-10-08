using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class u_HP : PlayerStatCtrl
{
    public Toggle[] Toggles;
    public Text H_GoldText;
    [HideInInspector] public int H_Toggle;
    [HideInInspector] public int H_Gold;

    private void Start()
    {
        H_Toggle = PlayerPrefs.GetInt("H_Toggle");
        H_Gold = 500;
        H_GoldText.text = H_Gold.ToString() + "∞ÒµÂ";
        LoadToggle();
    }

    public void SaveUpgrade()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[2].isOn == true)
            {
                H_Toggle = 3;
                PlayerPrefs.SetInt("H_Toggle", H_Toggle);
            }
            else if (Toggles[1].isOn == true)
            {
                H_Toggle = 2;
                PlayerPrefs.SetInt("H_Toggle", H_Toggle);
            }
            else if (Toggles[0].isOn == true)
            {
                H_Toggle = 1;
                PlayerPrefs.SetInt("H_Toggle", H_Toggle);
            }
        }
    }

    public void LoadToggle()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            switch (H_Toggle)
            {
                case 1:
                    Toggles[0].isOn = true;
                    H_Gold = 1000;
                    break;
                case 2:
                    Toggles[0].isOn = true;
                    Toggles[1].isOn = true;
                    H_Gold = 1500;
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
        H_Gold = 500;
        H_GoldText.text = H_Gold.ToString() + "∞ÒµÂ";
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
            if (Toggles[i].isOn == false && playerGold.currPlayerGold >= H_Gold)
            {
                upgradeHP += 10;
                playerGold.currPlayerGold -= H_Gold;
                H_Gold += 500;
                H_GoldText.text = H_Gold.ToString() + "∞ÒµÂ";
                playerGold.UpdateGold();
                SoundManager.instance.SFXPlay("Upgrade", audioSource);
                if (i == 2)
                {
                    H_GoldText.text = "√÷¥Î ∑π∫ß¿‘¥œ¥Ÿ.";
                }
                base.UpdateStat();
                Toggles[i].isOn = true;
                return;
            }
        }
    }
}
