using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject ResultPanel;
    public Text ResultText;

    public bool isGameStart = false;
    public bool isGamePause = false;

    public AudioSource systemAudioSource;
    public AudioSource resetAudioSource;
    public AudioSource victoryAudioSource;
    public AudioSource loseAudioSource;

    private static UIController instance = null;

    static int static_HP = 100;
    static float static_Speed = 7;
    int currPlayerGold;

    private void Awake()
    {
        //PlayerPrefs.SetInt("CurrPlayerGold", 0);
        //PlayerPrefs.SetInt("AllPlayerGold", 0);
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        currPlayerGold = PlayerPrefs.GetInt("CurrPlayerGold");
        PausePanel.SetActive(false);
        ResultPanel.SetActive(false);
        isGamePause = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePause == false && SceneManager.GetActiveScene().name == "PlayScene")
        {
            isGamePause = true;
            PauseGame();
        }
    }

    // 타이틀 상점 버튼
    public void OnClick_EnterShop()
    {
        Invoke("DelayShopEnter", 0.3f);
    }

    public void DelayShopEnter()
    {
        SceneManager.LoadScene("ShopScene");
    }

    // 프로그램 종료
    public void OnClick_ExitProgram()
    {
        Invoke("DelayExit", 0.3f);
    }

    public void DelayExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 캐릭터 선택 후 시작 버튼
    public void OnClick_GameStart()
    {
        UpgradeStat();
        SceneManager.LoadScene("CutScene");
        isGameStart = true;
    }

    // 상점 업그레이드 적용
    public void UpgradeStat()
    {
        int p_HP = PlayerPrefs.GetInt("p_HP");
        int upgradeHP = PlayerPrefs.GetInt("upgradeHP");
        static_HP += upgradeHP;
        p_HP = static_HP;
        PlayerPrefs.SetInt("p_HP", p_HP);

        float p_Speed = PlayerPrefs.GetFloat("p_Speed");
        float upgradeSpeed = PlayerPrefs.GetFloat("upgradeSpeed");
        static_Speed += upgradeSpeed;
        p_Speed = static_Speed;
        PlayerPrefs.SetFloat("p_Speed", p_Speed);
    }

    // 상점 나가기
    public void OnClick_ExitShop()
    {
        Invoke("DelayShopExit", 0.3f);
    }

    public void DelayShopExit()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // 일시정지 버튼
    public void PauseGame()                     // 처음으로 pause 패널을 띄운 이후 Title로 돌아갔다 재시작하면 panel 활성화 안됨
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GamePause();
        PausePanel.SetActive(true);
    }

    // 일시정지 해제
    public void OnClick_ResumeGame()            // 동작하지 않는다. update 펑션에서 PausePanel에 매번 새로운 오브젝트를 할당하면서 발생하는 문제로 예상됨.
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameResume();
        PausePanel.SetActive(false);
        isGamePause = false;
    }

    // 타이틀로 돌아가기
    public void OnClick_ToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameResume();
        PausePanel.SetActive(false);
        ResultPanel.SetActive(false);
        static_HP = 100;
        static_Speed = 7;
        isGamePause = false;
    }

    public void OnClick_GameOver()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GoldUpdate();
        gameManager.GameResume();
        SceneManager.LoadScene("TitleScene");
        PausePanel.SetActive(false);
        ResultPanel.SetActive(false);
        static_HP = 100;
        static_Speed = 7;
        isGamePause = false;
    }

    // 플레이어 사망시
    public void YouDie()
    {
        ResultPanel.SetActive(true);
        ResultPanel.GetComponent<GameOverPanel>().ShowResult();
        SoundManager.instance.SFXPlay("Lose", loseAudioSource);
        string str = "<color=#ff0000>" + "훈련 실패..." + "</color>";
        ResultText.text = str;
    }

    // 게임 클리어 시
    public void GameClear()
    {
        ResultPanel.SetActive(true);
        ResultPanel.GetComponent<GameOverPanel>().ShowResult();
        SoundManager.instance.SFXPlay("Victory", victoryAudioSource);
        string str = "<color=#00ff00>" + "훈련 완료!" + "</color>";
        ResultText.text = str;
    }

    public void SFXPlay()
    {
        SoundManager.instance.SFXPlay("System", systemAudioSource);
    }

    public void ResetUpgrade()
    {
        SoundManager.instance.SFXPlay("Reset", resetAudioSource);
        PlayerPrefs.SetInt("H_Toggle", 0);
        PlayerPrefs.SetInt("D_Toggle", 0);
        PlayerPrefs.SetFloat("S_Toggle", 0);
        PlayerPrefs.SetFloat("C_Toggle", 0);
        PlayerPrefs.SetInt("upgradeHP", 0);
        PlayerPrefs.SetInt("upgradeDMG", 0);
        PlayerPrefs.SetFloat("upgradeSpeed", 0);
        PlayerPrefs.SetFloat("upgradeCoolTime", 0);
    }

    public void RichCheat()
    {
        PlayerGold playerGold = FindObjectOfType<PlayerGold>();
        PlayerPrefs.SetInt("CurrPlayerGold", 15000);
        PlayerPrefs.SetInt("AllPlayerGold", 15000);
        playerGold.GoldText.text = PlayerPrefs.GetInt("CurrPlayerGold").ToString();
    }
}
