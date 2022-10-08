using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GameObject player_obj;
    [SerializeField] private Text TimeRemain;
    [SerializeField] public int PlayTime_sec;
    [HideInInspector] public bool isGamePlaying = false;
    [HideInInspector] public bool isGamePause = false;
    [HideInInspector] public bool isGameStart = false;
    [HideInInspector] public int timeProcess = 0;
    [HideInInspector] public int monster_killCount = 0;
    [HideInInspector] public int bossmonster_killCount = 0;
    [HideInInspector] public int getGold = 0;
    private int remainTime_min;
    private int remainTime_sec;
    private IEnumerator gameProcessor = null;
    private IEnumerator monsterSpawn = null;
    private EnemySpawner enemySpawner;

    int currPlayerGold;
    int allPlayerGold;
    void Start()
    {
        InitData();
        Message.Instance().SendMessage(GameState.Pause);
        GamePause();
        //GameStart();
        currPlayerGold = PlayerPrefs.GetInt("CurrPlayerGold");
        allPlayerGold = PlayerPrefs.GetInt("AllPlayerGold");
    }
    private void InitData()
    {
        monster_killCount = 0;
        bossmonster_killCount = 0;
        timeProcess = 0;
        getGold = 0;
        isGamePlaying = true;
    }

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
       
        if (instance == null)                 //싱글턴 패턴 적용
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        enemySpawner.enemyList = new List<int>();

        if (gameProcessor == null)
        {
            gameProcessor = GameProcessor();
        }
        if (monsterSpawn == null)
        {
            monsterSpawn = enemySpawner.MonsterSpawn();
        } 
        GamePause();
    }

   
    
    public void GameStart()
    {
        if (isGamePlaying == false)
        {
            GameResume();
            if (enemySpawner.enemies.Length > 0)
            {
                StartCoroutine(monsterSpawn);
            }
        }
    }

    public void GamePause()
    {
            isGamePlaying = false;
            StopCoroutine(gameProcessor);
            Message.Instance().SendMessage(GameState.Pause);
    }
    
    public void GoldUpdate()
    {
        currPlayerGold = currPlayerGold + getGold + monster_killCount;
        allPlayerGold = allPlayerGold + getGold + monster_killCount;
        PlayerPrefs.SetInt("CurrPlayerGold", currPlayerGold);
        PlayerPrefs.SetInt("AllPlayerGold", allPlayerGold);
    }

    public void GameOver()
    {
        if (isGamePlaying == true)
        {
            isGamePlaying = false;
            StopCoroutine(gameProcessor);
            Message.Instance().SendMessage(GameState.GameOver);
        }
    }

    public void GameResume()
    {
        if (isGamePlaying == false)
        {
            isGamePlaying = true;
            StartCoroutine(gameProcessor);
            Message.Instance().SendMessage(GameState.Playing);
        }
    }

    public void QuitGame()
    {
        UIController uIController = FindObjectOfType<UIController>();
        if (isGamePlaying)
        {
            GameOver();
            uIController.GameClear();
            StopCoroutine(monsterSpawn);
        }
    }

    IEnumerator GameProcessor()
    {
        while (isGamePlaying)
        {
            int temp_countDown = PlayTime_sec - timeProcess;

            if (temp_countDown <= 0)
            {
                QuitGame();
            }
            remainTime_min = temp_countDown / 60;
            remainTime_sec = temp_countDown % 60;
            TimeRemain.text = remainTime_min.ToString() + ":" + remainTime_sec.ToString();
            yield return new WaitForSeconds(1.0f);
            enemySpawner.BossTimeCheck(timeProcess);
            enemySpawner.EnemyTimeCheck(timeProcess);
            timeProcess++;
        }
    }
    
    public GameObject GetPlayer()
    {
        return player_obj;
    }
}
