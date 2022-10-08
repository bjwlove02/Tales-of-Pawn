using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skill
{
    CircleBomb,
    ShotGun,
    MeleeAttack,
    FireBall,
    Meteor,
    Null
}

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private Skills[] skills;
    PlayerCtrl playerCtrl;

    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
    }

    public void ActiveSkill(Skill skillName)
    {
        if (skillName == Skill.CircleBomb)
        {
            skills[(int)Skill.CircleBomb].ActiveSkill();
        }
        else if (skillName == Skill.MeleeAttack)
        {
            skills[(int)Skill.MeleeAttack].ActiveSkill();
        }
        else if (skillName == Skill.ShotGun)
        {
            skills[(int)Skill.ShotGun].ActiveSkill();
        }
        else if (skillName == Skill.FireBall)
        {
            skills[(int)Skill.FireBall].ActiveSkill();
        }
        else if (skillName == Skill.Meteor)
        {
            skills[(int)Skill.Meteor].ActiveSkill();
        }
    }
}
