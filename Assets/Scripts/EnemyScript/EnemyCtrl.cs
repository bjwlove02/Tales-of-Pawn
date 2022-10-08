using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{

    [SerializeField] Transform playerTr;
    [SerializeField] float moveSpeed;
    [SerializeField] float distance_Limit;
    public bool Boss;

    GameManager gameManager;

    public GameObject Exp;
    public GameObject Gold;
    public GameObject Food;
    public GameObject RandomBox;
    public float monsterDMG;
    private Transform enemyTr;
    DMGCtrl dmgCtrl;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").transform;
        if (GetComponent<DMGCtrl>())
        {
            dmgCtrl = GetComponent<DMGCtrl>();
        }
    }

    void FixedUpdate()
    {
        if (!dmgCtrl.isDie && Message.Instance().ReceiveMessage() == GameState.Playing)
        {
            Chase(playerTr.position, moveSpeed, distance_Limit);
        }
    }

    public void Chase(Vector3 targetPos, float MaxSpeed, float distance_limit)
    {
        float distance = (targetPos - this.transform.position).magnitude;

        if (distance > distance_limit)
        {
            Vector3 moveDir = (targetPos - enemyTr.position).normalized;
            enemyTr.position += moveDir * moveSpeed * Time.deltaTime;
            MathProblem.Instance().angleCal(enemyTr, moveDir);
        }
    }

    public void collierWithPlayer()
    {
        if (!Boss)
        {
            Dead();
        }
    }

    public void Dead()
    {
        //몬스터 사망 로직 작성
        if (!Boss)
        {
            Destroy(gameObject);
            int temp_rand = Random.Range(0, 100);
            if (temp_rand < 5)
            {
                Instantiate(Gold, transform.position + Vector3.up * 1.4f, Gold.transform.rotation);
            }
            else if (temp_rand >= 5 && temp_rand < 8)
            {
                Instantiate(Food, transform.position + Vector3.up * 1.4f, Food.transform.rotation);
            }
            else
            {
                Instantiate(Exp, transform.position + Vector3.up * 1.4f, Exp.transform.rotation);
            }
            gameManager.monster_killCount++;
        }
        else
        {
            Destroy(gameObject);
            Instantiate(RandomBox, transform.position, RandomBox.transform.rotation);
            Instantiate(Exp, transform.position + Vector3.up * 1.4f, Exp.transform.rotation);
            gameManager.bossmonster_killCount++;
        }
    }
}