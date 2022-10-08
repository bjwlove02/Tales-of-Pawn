using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class u_Speed : PlayerStatCtrl
{
    public Toggle[] Toggles;
    public Text S_GoldText;
    [HideInInspector] public float S_Toggle;
    [HideInInspector] public int S_Gold;

    private void Start()
    {
        S_Toggle = PlayerPrefs.GetFloat("S_Toggle");
        S_Gold = 500;
        S_GoldText.text = S_Gold.ToString() + "∞ÒµÂ";
        LoadToggle();
    }

    public void SaveUpgrade()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[2].isOn == true)
            {
                S_Toggle = 3;
                PlayerPrefs.SetFloat("S_Toggle", S_Toggle);
            }
            else if (Toggles[1].isOn == true)
            {
                S_Toggle = 2;
                PlayerPrefs.SetFloat("S_Toggle", S_Toggle);
            }
            else if (Toggles[0].isOn == true)
            {
                S_Toggle = 1;
                PlayerPrefs.SetFloat("S_Toggle", S_Toggle);
            }
        }
    }

    public void LoadToggle()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            switch (S_Toggle)
            {
                case 1:
                    Toggles[0].isOn = true;
                    S_Gold = 1000;
                    break;
                case 2:
                    Toggles[0].isOn = true;
                    Toggles[1].isOn = true;
                    S_Gold = 1500;
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
        S_Gold = 500;
        S_GoldText.text = S_Gold.ToString() + "∞ÒµÂ";
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
            if (Toggles[i].isOn == false && playerGold.currPlayerGold >= S_Gold)
            {
                upgradeSpeed += 1.0f;
                playerGold.currPlayerGold -= S_Gold;
                S_Gold += 500;
                S_GoldText.text = S_Gold.ToString() + "∞ÒµÂ";
                playerGold.UpdateGold();
                SoundManager.instance.SFXPlay("Upgrade", audioSource);
                if (i == 2)
                {
                    S_GoldText.text = "√÷¥Î ∑π∫ß¿‘¥œ¥Ÿ.";
                }
                base.UpdateStat();
                Toggles[i].isOn = true;
                return;
            }
        }
    }
}
