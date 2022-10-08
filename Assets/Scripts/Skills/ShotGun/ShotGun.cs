using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Skills
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
        DMG = 7.0f + accDMG;
        dmgDelay = 1.5f - accCoolTime;
        KnockBack = 70.0f;
        Invoke("DelaySound", 0.5f);
    }
    public override void Skill_Lv2()
    {
        DMG = 17.0f + accDMG;
        dmgDelay = 1.5f - accCoolTime;
        KnockBack = 70.0f;
        Invoke("DelaySound", 0.5f);
    }
    public override void Skill_Lv3()
    {
        DMG = 22.0f + accDMG;
        dmgDelay = 1.35f - accCoolTime;
        KnockBack = 70.0f;
        Invoke("DelaySound", 0.5f);
    }
    public override void Skill_Lv4()
    {
        DMG = 27.0f + accDMG;
        dmgDelay = 1.35f - accCoolTime;
        KnockBack = 77.0f;
        Invoke("DelaySound", 0.5f);
    }
    public override void Skill_Lv5()
    {
        DMG = 37.0f + accDMG;
        dmgDelay = 1.2f - accCoolTime;
        KnockBack = 77.0f;
        Invoke("DelaySound", 0.5f);
        max_LVup = true;
    }

    public void DelaySound()
    {
        SoundManager.instance.SFXPlay("ShotGun", audioSource);
    }

    protected override void CheckLevel()
    {
        switch (skillLevel.shotGunLevel)
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
                yield return new WaitForSecondsRealtime(0.5f);
                GameObject temp = Instantiate(prefab
                    , tr.position
                    , Quaternion.Euler(new Vector3(
                        90, tr.rotation.eulerAngles.y, 0)));
                temp.GetComponent<ParticleColl_Check>().Damage = DMG;
                temp.GetComponent<ParticleColl_Check>().Knock_back = KnockBack;
                yield return new WaitForSecondsRealtime(dmgDelay);
                Destroy(temp, 2.0f);
            }
            else
            {
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
        }
    }
}
