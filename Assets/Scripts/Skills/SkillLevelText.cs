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
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "기본 피해 5 증가\n공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "기본 피해 5 증가\n공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.ShotGun:
                switch (skillLevel.shotGunLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "기본 피해 5 증가\n공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "기본 피해 5 증가\n넉백 10% 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가\n공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.CircleBomb:
                switch (skillLevel.circleBombLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "기본 피해 2 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "기본 피해 1 증가\n공격 범위 20% 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "기본 피해 2 증가\n공격 범위 20% 증가\n공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.FireBall:
                switch (skillLevel.fireBallLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "투사체 1개 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가\n관통 1회 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "투사체 1개 증가, 관통 1회 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가\n투사체 1개 증가, 관통 1회 증가";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.Meteor:
                switch (skillLevel.meteorLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "공격 속도 10% 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "기본 피해 10 증가\n공격 속도 20% 증가";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
        }
    }
}
