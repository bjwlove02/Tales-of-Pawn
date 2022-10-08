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

        survive_time.text = "���� �ð� : " + gameManager.timeProcess.ToString() + " ��";

        monster_killed.text = "óġ�� ���� : " + gameManager.monster_killCount.ToString() + " ����";

        bossMonster_killed.text = "óġ�� ���� ���� : " + gameManager.bossmonster_killCount.ToString() + " ����";

        gold_Achieve.text = "ȹ�� ��� : " + (gameManager.getGold + gameManager.monster_killCount).ToString() + " ���";
    }
}
