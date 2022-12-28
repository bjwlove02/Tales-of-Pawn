using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevelText : MonoBehaviour
{
    private SkillLevel skillLevel;
    private LevelUpBtn levelUpBtn;

    private void Awake()
    {
        skillLevel = FindObjectOfType<SkillLevel>();
        levelUpBtn = GetComponent<LevelUpBtn>();
    }

    private void Update()
    {
        TextUpdate();
    }


    public void TextUpdate()
    {
        switch (levelUpBtn.btn_Skill)
        {
            case Skill.MeleeAttack:
                switch (skillLevel.meleeAttackLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "基本被害 10増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "基本被害 5増加\n攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "基本被害 10増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "基本被害 5増加\n攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.ShotGun:
                switch (skillLevel.shotGunLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "基本被害 10増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "基本被害 5増加\n攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "基本被害 5増加\nノックバック 10%増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "基本被害 10増加\n攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.CircleBomb:
                switch (skillLevel.circleBombLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "基本被害 2増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "基本被害 1増加\n攻撃範囲 20%増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "基本被害 2増加\n攻撃範囲 20%増加\n攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.FireBall:
                switch (skillLevel.fireBallLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "投射体 1個増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "基本被害 10増加\n貫通 1回増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "投射体 1個増加、貫通 1回増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "基本被害 10増加\n投射体 1個増加、貫通1回増加";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.Meteor:
                switch (skillLevel.meteorLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "基本被害　10増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "攻撃速度 10%増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "基本被害　10増加";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "基本被害　10増加\n攻撃速度 20%増加";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
        }
    }
}
