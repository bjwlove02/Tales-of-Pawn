using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDMGCtrl : DMGCtrl
{
    GetItem getItem;

    private void Awake()
    {
        getItem = GetComponent<GetItem>();
    }

    private void Start()
    {
        characterHP = PlayerPrefs.GetInt("p_HP");
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCtrl tempPlayerCtrl = GetComponent<PlayerCtrl>();
        if (other.tag == "Monster")
        {
            EnemyCtrl enemyCtrl = other.gameObject.GetComponent<EnemyCtrl>();
            ReceiveDamage(enemyCtrl.monsterDMG);
            gameObject.GetComponent<PlayerCtrl>().PlayerDamaged();
            other.gameObject.GetComponent<EnemyCtrl>().collierWithPlayer();
            if (isDie)
            {
                tempPlayerCtrl.Dead();
            }
        }
    }
}
