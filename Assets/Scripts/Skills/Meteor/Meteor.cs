using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Skills
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
        DMG = 25.0f + accDMG;
        dmgDelay = 2.0f - accCoolTime;
        Range = 1.0f;
        KnockBack = 10.0f;
        Invoke("DelaySound", 0.55f);
    }
    public override void Skill_Lv2()
    {
        DMG = 35.0f + accDMG;
        dmgDelay = 2.0f - accCoolTime;
        Range = 1.0f;
        KnockBack = 10.0f;
        Invoke("DelaySound", 0.55f);
    }
    public override void Skill_Lv3()
    {
        DMG = 35.0f + accDMG;
        dmgDelay = 1.8f - accCoolTime;
        Range = 1.0f;
        KnockBack = 10.0f;
        Invoke("DelaySound", 0.55f);
    }
    public override void Skill_Lv4()
    {
        DMG = 45.0f + accDMG;
        dmgDelay = 1.8f - accCoolTime;
        Range = 1.0f;
        KnockBack = 10.0f;
        Invoke("DelaySound", 0.55f);
    }

    public override void Skill_Lv5()
    {
        DMG = 55.0f + accDMG;
        dmgDelay = 1.4f - accCoolTime;
        Range = 1.0f;
        KnockBack = 10.0f;
        Invoke("DelaySound", 0.55f);
        max_LVup = true;

    }

    Vector3 RandomPosition(Transform tr)
    {
        return new Vector3(
            tr.position.x + Random.Range(-10, 10)
            , 0.6f
            , tr.position.z + Random.Range(-10, 10)
            );
    }

    public void DelaySound()
    {
        SoundManager.instance.SFXPlay("Meteor", audioSource);
    }

    protected override void CheckLevel()
    {
        switch (skillLevel.meteorLevel)
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
            CheckLevel();
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                if (SkillCaster != null)
                {
                    SkillCaster.GetComponent<SubPlayerCtrl>().Cast_Anim();
                }
                GameObject temp = Instantiate(prefab
                    , RandomPosition(tr)
                    , tr.rotation);

                temp.GetComponent<Meteor_Hit>().Damage = DMG;
                temp.transform.localScale *= Range;
                temp.GetComponent<Meteor_Hit>().Knock_back = KnockBack;
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
            else
            {
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
        }
    }
}