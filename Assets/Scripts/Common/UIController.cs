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

    // Ÿ��Ʋ ���� ��ư
    public void OnClick_EnterShop()
    {
        Invoke("DelayShopEnter", 0.3f);
    }

    public void DelayShopEnter()
    {
        SceneManager.LoadScene("ShopScene");
    }

    // ���α׷� ����
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

    // ĳ���� ���� �� ���� ��ư
    public void OnClick_GameStart()
    {
        UpgradeStat();
        SceneManager.LoadScene("CutScene");
        isGameStart = true;
    }

    // ���� ���׷��̵� ����
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

    // ���� ������
    public void OnClick_ExitShop()
    {
        Invoke("DelayShopExit", 0.3f);
    }

    public void DelayShopExit()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // �Ͻ����� ��ư
    public void PauseGame()                     // ó������ pause �г��� ��� ���� Title�� ���ư��� ������ϸ� panel Ȱ��ȭ �ȵ�
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GamePause();
        PausePanel.SetActive(true);
    }

    // �Ͻ����� ����
    public void OnClick_ResumeGame()            // �������� �ʴ´�. update ��ǿ��� PausePanel�� �Ź� ���ο� ������Ʈ�� �Ҵ��ϸ鼭 �߻��ϴ� ������ �����.
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameResume();
        PausePanel.SetActive(false);
        isGamePause = false;
    }

    // Ÿ��Ʋ�� ���ư���
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

    // �÷��̾� �����
    public void YouDie()
    {
        ResultPanel.SetActive(true);
        ResultPanel.GetComponent<GameOverPanel>().ShowResult();
        SoundManager.instance.SFXPlay("Lose", loseAudioSource);
        string str = "<color=#ff0000>" + "�Ʒ� ����..." + "</color>";
        ResultText.text = str;
    }

    // ���� Ŭ���� ��
    public void GameClear()
    {
        ResultPanel.SetActive(true);
        ResultPanel.GetComponent<GameOverPanel>().ShowResult();
        SoundManager.instance.SFXPlay("Victory", victoryAudioSource);
        string str = "<color=#00ff00>" + "�Ʒ� �Ϸ�!" + "</color>";
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
