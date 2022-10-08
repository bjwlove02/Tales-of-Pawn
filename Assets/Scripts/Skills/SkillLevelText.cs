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
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 5 ����\n���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meleeAttackLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 5 ����\n���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.ShotGun:
                switch (skillLevel.shotGunLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 5 ����\n���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 5 ����\n�˹� 10% ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.shotGunLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����\n���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.CircleBomb:
                switch (skillLevel.circleBombLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 2 ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 1 ����\n���� ���� 20% ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.circleBombLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 2 ����\n���� ���� 20% ����\n���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.FireBall:
                switch (skillLevel.fireBallLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "����ü 1�� ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����\n���� 1ȸ ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "����ü 1�� ����, ���� 1ȸ ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.fireBallLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����\n����ü 1�� ����, ���� 1ȸ ����";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
            case Skill.Meteor:
                switch (skillLevel.meteorLevel)
                {
                    case 1:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 2:
                        levelUpBtn.btn_Text.text = "���� �ӵ� 10% ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 3:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����";
                        levelUpBtn.LevelText.text = "Lv " + (int)(skillLevel.meteorLevel + 1);
                        break;
                    case 4:
                        levelUpBtn.btn_Text.text = "�⺻ ���� 10 ����\n���� �ӵ� 20% ����";
                        levelUpBtn.LevelText.text = "Lv Max";
                        break;
                }
                break;
        }
    }
}
