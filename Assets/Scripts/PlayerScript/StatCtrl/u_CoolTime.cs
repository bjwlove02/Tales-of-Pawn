using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class u_CoolTime : PlayerStatCtrl
{
    public Toggle[] Toggles;
    public Text C_GoldText;
    [HideInInspector] public float C_Toggle;
    [HideInInspector] public int C_Gold;

    private void Start()
    {
        C_Toggle = PlayerPrefs.GetFloat("C_Toggle");
        C_Gold = 1000;
        C_GoldText.text = C_Gold.ToString() + "∞ÒµÂ";
        LoadToggle();
    }

    public void SaveUpgrade()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[2].isOn == true)
            {
                C_Toggle = 3;
                PlayerPrefs.SetFloat("C_Toggle", C_Toggle);
            }
            else if (Toggles[1].isOn == true)
            {
                C_Toggle = 2;
                PlayerPrefs.SetFloat("C_Toggle", C_Toggle);
            }
            else if (Toggles[0].isOn == true)
            {
                C_Toggle = 1;
                PlayerPrefs.SetFloat("C_Toggle", C_Toggle);
            }
        }
    }

    public void LoadToggle()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            switch (C_Toggle)
            {
                case 1:
                    Toggles[0].isOn = true;
                    C_Gold = 2000;
                    break;
                case 2:
                    Toggles[0].isOn = true;
                    Toggles[1].isOn = true;
                    C_Gold = 3000;
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
        C_Gold = 1000;
        C_GoldText.text = C_Gold.ToString() + "∞ÒµÂ";
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
            if (Toggles[i].isOn == false && playerGold.currPlayerGold >= C_Gold)
            {
                upgradeCoolTime -= 0.1f;
                playerGold.currPlayerGold -= C_Gold;
                C_Gold += 1000;
                C_GoldText.text = C_Gold.ToString() + "∞ÒµÂ";
                playerGold.UpdateGold();
                SoundManager.instance.SFXPlay("Upgrade", audioSource);
                if (i == 2)
                {
                    C_GoldText.text = "√÷¥Î ∑π∫ß¿‘¥œ¥Ÿ.";
                }
                base.UpdateStat();
                Toggles[i].isOn = true;
                return;
            }
        }
    }
}
