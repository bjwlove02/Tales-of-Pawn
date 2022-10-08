using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Slider HP_Slider;
    [SerializeField] Slider EXP_Slider;
    bool isMove;

    float horizontal;
    float vertical;

    public Transform playerTr;
    private Vector3 moveDir;
    public PlayerAnimCtrl playerAnimCtrl;
    PlayerSkills playerSkills;
    DMGCtrl dmgCtrl;
    LevelUp playerLevel;
    SkillLevel skillLevel;
    GetItem getItem;

    private void Awake()
    {
        playerAnimCtrl = GetComponent<PlayerAnimCtrl>();
        playerTr = GetComponent<Transform>();
        playerSkills = GetComponent<PlayerSkills>();
        playerLevel = GetComponent<LevelUp>();
        skillLevel = GetComponent<SkillLevel>();
        dmgCtrl = GetComponent<DMGCtrl>();
        getItem = GetComponent<GetItem>();
    }

    void Start()
    {
        HP_Slider.maxValue = dmgCtrl.GetHP();
    }

    void FixedUpdate()
    {
        if (EXP_Slider != null && HP_Slider != null)
        {
            SliderCtrl();
        }
        else
        {
            Debug.Log("Slider is Missing! check UI");
        }
        //�޽�¡ Ŭ���� ���� �����ؼ� �÷���, �Ͻ� ���� ó��
        if (Message.Instance().ReceiveMessage() == GameState.Playing)
        {
            PlayerMove();
            playerAnimCtrl.Animation_Move(isMove);
        }
    }

    void SliderCtrl()
    {
        EXP_Slider.maxValue = playerLevel.needExp;      //exp �ִ밪
        EXP_Slider.value = getItem.exp;   //����exp��
        HP_Slider.value = dmgCtrl.GetHP();            //���� �÷��̾� HP
        HP_Slider.maxValue = PlayerPrefs.GetInt("p_HP");
        HP_Slider.transform.position = new Vector3(playerTr.position.x, 0.4f, playerTr.position.z);
    }

    public void PlayerDamaged()
    {
        playerAnimCtrl.Animation_Damaged();
    }

    public void Dead()
    {
        //�÷��̾� ��� ���� �ۼ�
        UIController uIController = FindObjectOfType<UIController>();
        uIController.YouDie();
    }

    private void PlayerMove()
    {
        //onGamePlay(bool) �� true �� �� ����
        moveSpeed = PlayerPrefs.GetFloat("p_Speed");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            moveDir = ((Vector3.forward * vertical) + (Vector3.right * horizontal)).normalized;  //movDir ����ȭ
            playerTr.position += moveDir * moveSpeed * Time.deltaTime;
            MathProblem.Instance().angleCal(playerTr, moveDir);
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }
}