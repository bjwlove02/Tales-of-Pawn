using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skills
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float deadT = 1.0f;
    [SerializeField] public int penetration_num = 0;
    [SerializeField] public int shoot_num = 1;
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
        DMG = 10 + accDMG;
        dmgDelay = 1.0f + accCoolTime;
        speed = 30.0f;
        deadT = 4.0f;
        penetration_num = 1;
        shoot_num = 1;
        KnockBack = 10.0f;
        SoundManager.instance.SFXPlay("FireBall", audioSource);
    }
    public override void Skill_Lv2()
    {
        DMG = 10 + accDMG;
        dmgDelay = 1.0f + accCoolTime;
        speed = 30.0f;
        deadT = 4.0f;
        penetration_num = 1;
        shoot_num = 2;
        KnockBack = 10.0f;
        SoundManager.instance.SFXPlay("FireBall", audioSource);
    }
    public override void Skill_Lv3()
    {
        DMG = 20 + accDMG;
        dmgDelay = 1.0f + accCoolTime;
        speed = 30.0f;
        deadT = 4.0f;
        penetration_num = 2;
        shoot_num = 2;
        KnockBack = 10.0f;
        SoundManager.instance.SFXPlay("FireBall", audioSource);
    }
    public override void Skill_Lv4()
    {
        DMG = 20 + accDMG;
        dmgDelay = 1.0f + accCoolTime;
        speed = 30.0f;
        deadT = 4.0f;
        penetration_num = 3;
        shoot_num = 3;
        KnockBack = 10.0f;
        SoundManager.instance.SFXPlay("FireBall", audioSource);
    }
    public override void Skill_Lv5()
    {
        DMG = 30 + accDMG;
        dmgDelay = 1.0f + accCoolTime;
        speed = 30.0f;
        deadT = 4.0f;
        penetration_num = 4;
        shoot_num = 4;
        KnockBack = 10.0f;
        SoundManager.instance.SFXPlay("FireBall", audioSource);

        max_LVup = true;
    }
    protected override void CheckLevel()
    {
        switch (skillLevel.fireBallLevel)
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
                for (int i = 0; i < shoot_num; i++)
                {
                    GameObject temp = Instantiate(prefab
                      , tr.position
                      , tr.rotation);
                    //temp.transform.SetParent(tr);
                    ShootFireBall projectile = temp.GetComponent<ShootFireBall>();
                    projectile.deadT = deadT;
                    projectile.speed = speed;
                    projectile.Damage = DMG;
                    projectile.penetration_num = penetration_num;
                    projectile.Knock_back = KnockBack;
                    yield return new WaitForSecondsRealtime(0.5f);
                }
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
            else
            {
                yield return new WaitForSecondsRealtime(dmgDelay);
            }
        }
    }

}
