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
        //메시징 클래스 변수 참조해서 플레이, 일시 정지 처리
        if (Message.Instance().ReceiveMessage() == GameState.Playing)
        {
            PlayerMove();
            playerAnimCtrl.Animation_Move(isMove);
        }
    }

    void SliderCtrl()
    {
        EXP_Slider.maxValue = playerLevel.needExp;      //exp 최대값
        EXP_Slider.value = getItem.exp;   //현재exp값
        HP_Slider.value = dmgCtrl.GetHP();            //현재 플레이어 HP
        HP_Slider.maxValue = PlayerPrefs.GetInt("p_HP");
        HP_Slider.transform.position = new Vector3(playerTr.position.x, 0.4f, playerTr.position.z);
    }

    public void PlayerDamaged()
    {
        playerAnimCtrl.Animation_Damaged();
    }

    public void Dead()
    {
        //플레이어 사망 로직 작성
        UIController uIController = FindObjectOfType<UIController>();
        uIController.YouDie();
    }

    private void PlayerMove()
    {
        //onGamePlay(bool) 이 true 일 때 실행
        moveSpeed = PlayerPrefs.GetFloat("p_Speed");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            moveDir = ((Vector3.forward * vertical) + (Vector3.right * horizontal)).normalized;  //movDir 정규화
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