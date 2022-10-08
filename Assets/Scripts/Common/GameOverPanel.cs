using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Text survive_time;
    public Text monster_killed;
    public Text bossMonster_killed;
    public Text gold_Achieve;

    public void ShowResult()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GamePause();

        survive_time.text = "생존 시간 : " + gameManager.timeProcess.ToString() + " 초";

        monster_killed.text = "처치한 몬스터 : " + gameManager.monster_killCount.ToString() + " 마리";

        bossMonster_killed.text = "처치한 보스 몬스터 : " + gameManager.bossmonster_killCount.ToString() + " 마리";

        gold_Achieve.text = "획득 골드 : " + (gameManager.getGold + gameManager.monster_killCount).ToString() + " 골드";
    }
}
