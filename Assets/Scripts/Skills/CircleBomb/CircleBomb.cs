using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBomb : Skills
{
    [SerializeField] public GameObject prefab;
    public IEnumerator currSkill;

    public void Awake()
    {
        isActive = false;
    }
    public override void ActiveSkill()
    {
        isActive = true;
        Instantiate_obj(SkillCaster, casterPos);
        currSkill = DoActive(gameObject.transform);
        StartCoroutine(currSkill);
    }
    override public void Skill_Lv1()
    {
        DMG = 2.0f + accDMG;
        dmgDelay = 1.0f - accCoolTime;
        Range = 1.0f;
        KnockBack = 15.0f;
        SoundManager.instance.SFXPlay("CircleBomb", audioSource);
    }
    public override void Skill_Lv2()
    {
        DMG = 4.0f + accDMG;
        dmgDelay = 1.0f - accCoolTime;
        Range = 1.0f;
        KnockBack = 15.0f;
        SoundManager.instance.SFXPlay("CircleBomb", audioSource);
    }
    public override void Skill_Lv3()
    {
        DMG = 5.0f + accDMG;
        dmgDelay = 1.0f - accCoolTime;
        Range = 1.2f;
        KnockBack = 15.0f;
        SoundManager.instance.SFXPlay("CircleBomb", audioSource);
    }
    public override void Skill_Lv4()
    {
        DMG = 5.0f + accDMG;
        dmgDelay = 0.9f - accCoolTime;
        Range = 1.2f;
        KnockBack = 15.0f;
        SoundManager.instance.SFXPlay("CircleBomb", audioSource);
    }
    public override void Skill_Lv5()
    {
        DMG = 7.0f + accDMG;
        dmgDelay = 0.8f - accCoolTime;
        Range = 1.4f;
        KnockBack = 15.0f;
        SoundManager.instance.SFXPlay("CircleBomb", audioSource);

        max_LVup = true;
    }
    protected override void CheckLevel()
    {
        switch (skillLevel.circleBombLevel)
        {
            case 1:
                Skill_Lv1();
                break;
            case 2:
                Skill_Lv2();
                break;
            case 3:
                Skill_Lv3();
                break;
            case 4:
                Skill_Lv4();
                break;
            case 5:
                Skill_Lv5();
                break;
        }
    }

    public override IEnumerator DoActive(Transform tr)
    {
        while (true)
        {
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                CheckLevel();
                if (SkillCaster != null)
                {
                    SkillCaster.GetComponent<SubPlayerCtrl>().Cast_Anim();
                }
                GameObject temp = Instantiate(prefab
                    , tr.position
                    , tr.rotation);

                temp.transform.SetParent(tr);
                temp.GetComponent<ParticleColl_Check>().Damage = DMG;
                temp.transform.localScale *= Range;
                temp.GetComponent<ParticleColl_Check>().Knock_back = KnockBack;
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
            else
            {
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
        }
    }
}
