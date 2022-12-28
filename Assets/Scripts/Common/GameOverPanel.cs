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

        survive_time.text = "生存時間 : " + gameManager.timeProcess.ToString() + " 秒";

        monster_killed.text = "処置したモンスター : " + gameManager.monster_killCount.ToString() + " 匹";

        bossMonster_killed.text = "処置したボスモンスター : " + gameManager.bossmonster_killCount.ToString() + " 匹";

        gold_Achieve.text = "獲得ゴールド : " + (gameManager.getGold + gameManager.monster_killCount).ToString() + " ゴールド";
    }
}
