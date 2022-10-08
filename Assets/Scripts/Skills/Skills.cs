using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills : MonoBehaviour
{
    [SerializeField] protected SkillLevel skillLevel;
    [SerializeField] protected GameObject SkillCaster;
    [SerializeField] protected Transform casterPos;
    [SerializeField] public float DMG = 0.0f;
    [SerializeField] public float Range = 1.0f;
    [SerializeField] public float dmgDelay = 1.0f;
    [SerializeField] public float KnockBack = 20.0f;
    public AudioSource audioSource;

    public bool max_LVup = false;
    public bool isActive = false;
    int upgradeDMG;
    float upgradeCoolTime;
    public int accDMG;
    public float accCoolTime;

    private void Start()
    {
        upgradeDMG = PlayerPrefs.GetInt("upgradeDMG");
        upgradeCoolTime = PlayerPrefs.GetFloat("upgradeCoolTime");
        DMG += upgradeDMG;
        dmgDelay += upgradeCoolTime;
    }

    protected void Update()
    {
        accDMG = PlayerPrefs.GetInt("accDMG");
        accCoolTime = PlayerPrefs.GetFloat("accCoolTime");
    }

    abstract public void ActiveSkill();
    abstract public void Skill_Lv1();
    abstract public void Skill_Lv2();
    abstract public void Skill_Lv3();
    abstract public void Skill_Lv4();
    abstract public void Skill_Lv5();
    abstract protected void CheckLevel();
    abstract public IEnumerator DoActive(Transform tr);
    protected void Instantiate_obj(GameObject caster, Transform tr)
    {
        GameObject temp_obj = Instantiate(caster
            , tr.position
            , Quaternion.identity);
        temp_obj.GetComponent<SubPlayerCtrl>().subChar_Tr = tr;
        temp_obj.transform.parent = GameObject.Find("SubPlayers").GetComponent<Transform>();
        SkillCaster = temp_obj;
    }
}
