using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryLevelText : MonoBehaviour
{
    private AccessoryLevel accessoryLevel;
    private LevelUpBtn levelUpBtn;

    private void Awake()
    {
        accessoryLevel = FindObjectOfType<AccessoryLevel>();
        levelUpBtn = GetComponent<LevelUpBtn>();
    }

    private void Update()
    {
        TextUpdate();
    }

    public void TextUpdate()
    {
        switch(levelUpBtn.btn_Acc)
        {
            case Accessory.Heart:
                switch(accessoryLevel.heartLevel)
                {
                    case 1:
                        levelUpBtn.LevelText.text = "Lv " + (int)(accessoryLevel.heartLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Accessory.Sword:
                switch (accessoryLevel.swordLevel)
                {
                    case 1:
                        levelUpBtn.LevelText.text = "Lv " + (int)(accessoryLevel.swordLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Accessory.Lightning:
                switch (accessoryLevel.lightningLevel)
                {
                    case 1:
                        levelUpBtn.LevelText.text = "Lv " + (int)(accessoryLevel.lightningLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Accessory.Stopwatch:
                switch (accessoryLevel.stopwatchLevel)
                {
                    case 1:
                        levelUpBtn.LevelText.text = "Lv " + (int)(accessoryLevel.stopwatchLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
        }
    }
}
