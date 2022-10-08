using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUICtrl : MonoBehaviour
{
    GameManager gameManager;

    [Header("Skills")]
    [SerializeField] public List<GameObject> skillBtns;
    [SerializeField] public List<GameObject> skills;

    [Header("Accesory")]
    public List<GameObject> accessory_Btns;
    public List<GameObject> accessories;

    private PlayerSkills playerSkills;
    private SkillLevel skillLevel;
    private AccessoryLevel accessoryLevel;
    private GetItem getItem;
    private LevelUp levelUp;

    [SerializeField] private bool ALL_LV_MAX;
    [Header("Inventory UI")]
    [SerializeField] private Inventory weapon_inventory;
    [SerializeField] private Inventory accessory_inventory;

    [Header("Panels")]
    [SerializeField] private GameObject GridPanel;
    public GameObject LevelUpPanel;
    public GameObject RandomBoxPanel;
    public GameObject GoldPanel;
    public Text GoldText;
    public Text LevelText;

    [Header("Item Scripts")]
    public Item MeleeAttack;
    public Item ShotGun;
    public Item CircleBomb;
    public Item FireBall;
    public Item Meteor;
    public Item Heart;
    public Item Sword;
    public Item Lightning;
    public Item Stopwatch;

    [Header("TestArea")]
    [SerializeField] List<GameObject> btns_list = new List<GameObject>();
    [SerializeField] List<GameObject> activated_skills;
    [SerializeField] List<GameObject> activated_accessories;

    [Header("Sounds")]
    public AudioSource levelUpAudioSource;
    public AudioSource BoxAudioSource;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerSkills = FindObjectOfType<PlayerSkills>();
        skillLevel = FindObjectOfType<SkillLevel>();
        accessoryLevel = FindObjectOfType<AccessoryLevel>();
        getItem = FindObjectOfType<GetItem>();
        levelUp = FindObjectOfType<LevelUp>();
        ALL_LV_MAX = false;
    }

    private void Update()
    {
        GoldText.text = getItem.gold.ToString();
    }

    int GetRandom()
    {
        int temp_num = Random.Range(0, skillBtns.Count);
        return temp_num;
    }

    private void ClearPanel()
    {
        Transform[] childList = GridPanel.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i] != GridPanel.transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }
    }

    private void Start()
    {
        LevelUpPanel.SetActive(false);
        RandomBoxPanel.SetActive(false);

        playerSkills.ActiveSkill(Skill.MeleeAttack);
        skillLevel.MeleeAttackLevelUp();
        weapon_inventory.GetItem(MeleeAttack);
    }

    public void ActiveRandomBox()
    {
        if (!ALL_LV_MAX)
        {
            Message.Instance().SendMessage(GameState.Pause);
            RandomBoxPanel.GetComponent<RootBoxCtrl>().ActivePanel();
        }
    }

    public void LevelUP()
    {
        if (!ALL_LV_MAX)
        {
            Message.Instance().SendMessage(GameState.Pause);
            LevelUpPanel.SetActive(true);
            Sort_Btn();
            SoundManager.instance.SFXPlay("LevelUp", levelUpAudioSource);
            LevelText.text = "Lv " + levelUp.curLevel.ToString();
        }
    }

    private void Sort_Btn()
    {

        btns_list = new List<GameObject>();
        activated_skills = new List<GameObject>();
        activated_accessories = new List<GameObject>();
        //List<GameObject> btns_list = new List<GameObject>();
        List<GameObject> activated_skill_Btns = new List<GameObject>();
        List<GameObject> activated_accessories_Btns = new List<GameObject>();
        //겹치지 않는 난수 생성


        for (int i = 0; i < skills.Count; i++)
        {
            if (skills[i].GetComponent<Skills>().isActive)
            {

                activated_skills.Add(skills[i]);
                activated_skill_Btns.Add(skillBtns[i]);
            }
        }
        for (int i = 0; i < accessories.Count; i++)
        {
            if (accessories[i].GetComponent<Accessories>().isActive)
            {

                activated_accessories.Add(accessories[i]);
                activated_accessories_Btns.Add(accessory_Btns[i]);
            }
        }


        //버튼 리스트에 스킬 추가
        if (activated_skills.Count < 3)
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (!skills[i].GetComponent<Skills>().max_LVup)
                {
                    btns_list.Add(skillBtns[i]);
                }
            }
        }
        else
        {

            for (int i = 0; i < activated_skills.Count; i++)
            {
                if (!activated_skills[i].GetComponent<Skills>().max_LVup)
                {
                    btns_list.Add(activated_skill_Btns[i]);
                }
            }
        }


        //버튼 리스트에 장신구 추가
        if (activated_accessories.Count < 3)
        {
            for (int i = 0; i < accessories.Count; i++)
            {
                if (!accessories[i].GetComponent<Accessories>().max_LVup)
                {
                    btns_list.Add(accessory_Btns[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < activated_accessories.Count; i++)
            {
                if (!activated_accessories[i].GetComponent<Accessories>().max_LVup)
                {
                    btns_list.Add(activated_accessories_Btns[i]);
                }
            }
        }

        int[] ran_num_list = new int[btns_list.Count];
        int temp_rand = 0;
        for (int i = 0; i < ran_num_list.Length; i++)
        {
            ran_num_list[i] = i;    //스킬과 악세사리 리스트의 모든 번호를 할당
        }
        for (int i = 0; i < ran_num_list.Length; i++)
        {
            int temp = ran_num_list[i];
            temp_rand = Random.Range(0, ran_num_list.Length);
            ran_num_list[i] = ran_num_list[temp_rand];
            ran_num_list[temp_rand] = temp;
            //랜덤을 사용해 겹치지 않는 난수 리스트 생성
        }

        //버튼 리스트 랜덤으로 출력
        if (btns_list.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (btns_list[ran_num_list[i]] != null)
                {
                    GameObject tempBtn =
                        Instantiate(btns_list[ran_num_list[i]]);
                    GetType_To_Btn(tempBtn);
                    tempBtn.transform.parent = GridPanel.transform;
                    tempBtn.transform.localScale = Vector3.one;
                }

            }
            Debug.Log(btns_list.Count);
        }
        else
        {
            for (int i = 0; i < btns_list.Count; i++)
            {
                if (btns_list[ran_num_list[i]] != null)
                {
                    GameObject tempBtn =
                        Instantiate(btns_list[ran_num_list[i]]);
                    GetType_To_Btn(tempBtn);
                    tempBtn.transform.parent = GridPanel.transform;
                    tempBtn.transform.localScale = Vector3.one;
                }
            }
            if (btns_list.Count == 0)
            {
                ALL_LV_MAX = true;
                LevelUpPanel.SetActive(false);
                ClearPanel();
                Message.Instance().SendMessage(GameState.Playing);
            }
        }
    }

    private void GetType_To_Btn(GameObject btn)
    {
        if (btn.GetComponent<LevelUpBtn>().btn_Skill != Skill.Null)
        {
            switch (btn.GetComponent<LevelUpBtn>().btn_Skill)
            {
                case Skill.CircleBomb:
                    btn.GetComponent<Button>().onClick.AddListener(GetCircleBomb);
                    return;
                case Skill.MeleeAttack:
                    btn.GetComponent<Button>().onClick.AddListener(GetMeleeAttack);
                    return;
                case Skill.FireBall:
                    btn.GetComponent<Button>().onClick.AddListener(GetFireBall);
                    return;
                case Skill.Meteor:
                    btn.GetComponent<Button>().onClick.AddListener(GetMeteor);
                    return;
                case Skill.ShotGun:
                    btn.GetComponent<Button>().onClick.AddListener(GetShotGun);
                    return;
            }
        }
        else if (btn.GetComponent<LevelUpBtn>().btn_Acc != Accessory.Null)
        {
            switch (btn.GetComponent<LevelUpBtn>().btn_Acc)
            {
                case Accessory.Heart:
                    btn.GetComponent<Button>().onClick.AddListener(GetHeart);
                    return;
                case Accessory.Sword:
                    btn.GetComponent<Button>().onClick.AddListener(GetSword);
                    return;
                case Accessory.Lightning:
                    btn.GetComponent<Button>().onClick.AddListener(GetLightning);
                    return;
                case Accessory.Stopwatch:
                    btn.GetComponent<Button>().onClick.AddListener(GetStopwatch);
                    return;
            }
        }
    }


    public void OnClick_SelectBtn()
    {
        LevelUpPanel.SetActive(false);
        ClearPanel();
        Message.Instance().SendMessage(GameState.Playing);
    }


    #region 무기 획득
    public void GetMeleeAttack()
    {
        OnClick_SelectBtn();
        if (skillLevel.meleeAttackLevel == 0)
        {
            playerSkills.ActiveSkill(Skill.MeleeAttack);
            skillLevel.MeleeAttackLevelUp();
            weapon_inventory.GetItem(MeleeAttack);
        }
        else
        {
            skillLevel.MeleeAttackLevelUp();
        }
    }

    public void GetShotGun()
    {
        OnClick_SelectBtn();
        if (skillLevel.shotGunLevel == 0)
        {
            playerSkills.ActiveSkill(Skill.ShotGun);
            skillLevel.ShotGunLevelUp();
            weapon_inventory.GetItem(ShotGun);
        }
        else
        {
            skillLevel.ShotGunLevelUp();
        }
    }

    public void GetCircleBomb()
    {
        OnClick_SelectBtn();
        if (skillLevel.circleBombLevel == 0)
        {
            playerSkills.ActiveSkill(Skill.CircleBomb);
            skillLevel.CircleBombLevelUp();
            weapon_inventory.GetItem(CircleBomb);
        }
        else
        {
            skillLevel.CircleBombLevelUp();
        }
    }
    public void GetFireBall()
    {
        OnClick_SelectBtn();
        if (skillLevel.fireBallLevel == 0)
        {
            playerSkills.ActiveSkill(Skill.FireBall);
            skillLevel.FireBallLevelUP();
            weapon_inventory.GetItem(FireBall);
        }
        else
        {
            skillLevel.FireBallLevelUP();
        }
    }
    public void GetMeteor()
    {
        OnClick_SelectBtn();
        if (skillLevel.meteorLevel == 0)
        {
            playerSkills.ActiveSkill(Skill.Meteor);
            skillLevel.MeteorLevelUp();
            weapon_inventory.GetItem(Meteor);
        }
        else
        {
            skillLevel.MeteorLevelUp();
        }
    }
    #endregion

    #region 장신구 획득
    public void GetHeart()
    {
        OnClick_SelectBtn();
        if (accessoryLevel.heartLevel == 0)
        {
            accessoryLevel.HeartLevelUp();
            accessory_inventory.GetItem(Heart);
        }
        else
        {
            accessoryLevel.HeartLevelUp();
        }
    }

    public void GetSword()
    {
        OnClick_SelectBtn();
        if (accessoryLevel.swordLevel == 0)
        {
            accessoryLevel.SwordLevelUp();
            accessory_inventory.GetItem(Sword);
        }
        else
        {
            accessoryLevel.SwordLevelUp();
        }
    }

    public void GetLightning()
    {
        OnClick_SelectBtn();
        if (accessoryLevel.lightningLevel == 0)
        {
            accessoryLevel.LightningLevelUp();
            accessory_inventory.GetItem(Lightning);
        }
        else
        {
            accessoryLevel.LightningLevelUp();
        }
    }

    public void GetStopwatch()
    {
        OnClick_SelectBtn();
        if (accessoryLevel.stopwatchLevel == 0)
        {
            accessoryLevel.StopwatchLevelUp();
            accessory_inventory.GetItem(Stopwatch);
        }
        else
        {
            accessoryLevel.StopwatchLevelUp();
        }
    }
    #endregion

    public void ClickBoxButton()
    {
        SoundManager.instance.SFXPlay("Box", BoxAudioSource);
        StartCoroutine(ClosePanel());
    }

    IEnumerator ClosePanel()
    {
        RandomBoxPanel.GetComponent<RootBoxCtrl>().DisableBtn();
        yield return new WaitForSecondsRealtime(3.0f);
        RandomBoxPanel.GetComponent<RootBoxCtrl>().PanelClose();
        gameManager.GameResume();
    }
}
