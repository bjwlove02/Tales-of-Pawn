using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Skills
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public Animator anim;
    public IEnumerator currSkill;
    public void Awake()
    {
        isActive = false;
    }

    public override void ActiveSkill()
    {
        isActive = true;
        currSkill = DoActive(gameObject.transform);
        StartCoroutine(currSkill);
    }
    public override void Skill_Lv1()
    {
        DMG = 10 + accDMG;
        dmgDelay = 1.0f - accCoolTime;
        KnockBack = 25.0f;
        SoundManager.instance.SFXPlay("MeleeAttack", audioSource);
    }
    public override void Skill_Lv2()
    {
        DMG = 20 + accDMG;
        dmgDelay = 1.0f - accCoolTime;
        KnockBack = 25.0f;
        SoundManager.instance.SFXPlay("MeleeAttack", audioSource);
    }
    public override void Skill_Lv3()
    {
        DMG = 25 + accDMG;
        dmgDelay = 0.9f - accCoolTime;
        KnockBack = 25.0f;
        SoundManager.instance.SFXPlay("MeleeAttack", audioSource);
    }
    public override void Skill_Lv4()
    {
        DMG = 35 + accDMG;
        dmgDelay = 0.9f + accCoolTime;
        KnockBack = 25.0f;
        SoundManager.instance.SFXPlay("MeleeAttack", audioSource);
    }
    public override void Skill_Lv5()
    {
        DMG = 40 + accDMG;
        dmgDelay = 0.8f + accCoolTime;
        KnockBack = 25.0f;
        SoundManager.instance.SFXPlay("MeleeAttack", audioSource);

        max_LVup = true;
    }
    protected override void CheckLevel()
    {
        switch (skillLevel.meleeAttackLevel)
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
                GameObject temp = Instantiate(prefab
                , tr.position
                , tr.rotation);

                temp.transform.SetParent(tr);
                temp.GetComponent<ParticleColl_Check>().Damage = DMG;
                temp.GetComponent<ParticleColl_Check>().Knock_back = KnockBack;
                anim.SetTrigger("MeleeAttack");
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
            else
            {
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
        }
    }
}
