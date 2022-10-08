using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private int enemyNum = 100;
    public float enemySpawnTime = 1.0f;
    public Transform[] enemySpawners;
    public GameObject[] enemies;
    public List<int> Wave_time;
    [HideInInspector] public List<int> enemyList;
    private GameObject curr_Enemy_prefab;



    public GameObject[] boss;
    [SerializeField] private int boss1SpawnTime;
    [SerializeField] private int boss2SpawnTime;
    [SerializeField] private int boss3SpawnTime;
    [SerializeField] private int boss4SpawnTime;
    [SerializeField] private int finalBossSpanwTime;
    public void EnemyTimeCheck(int timeProcess)
    {
        if (Wave_time.Count > 0)
        {
            if (timeProcess < Wave_time[1])
            {
                curr_Enemy_prefab = enemies[0];
            }
            else
            {
                for (int i = 1; i < Wave_time.Count; i++)
                {
                    if (timeProcess / Wave_time[i] == 1)
                    {
                        curr_Enemy_prefab = enemies[i];
                    }
                }
            }
        }
    }
    public void BossTimeCheck(int timeProcess)
    {
        if (timeProcess == boss1SpawnTime)
        {
            BossMonsterSpawn(0);
        }
        else if (timeProcess == boss2SpawnTime)
        {
            BossMonsterSpawn(1);
        }
        else if (timeProcess == boss3SpawnTime)
        {
            BossMonsterSpawn(2);
        }
        else if (timeProcess == boss4SpawnTime)
        {
            BossMonsterSpawn(3);
        }
        else if (timeProcess == finalBossSpanwTime)
        {
            BossMonsterSpawn(4);
        }
    }
    public void BossMonsterSpawn(int bossNum)
    {
        int ranZone = Random.Range(0, 3);
        Instantiate(boss[bossNum]
        , enemySpawners[ranZone].position
        , enemySpawners[ranZone].rotation);
    }
    public IEnumerator MonsterSpawn()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        while (true)
        {
            yield return new WaitForSecondsRealtime(enemySpawnTime);
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                int ranZone = Random.Range(0, 4);
                GameObject instantEnemy =
                    Instantiate(curr_Enemy_prefab
                    , enemySpawners[ranZone].position
                    , enemySpawners[ranZone].rotation);
            }
        }
    }
}

