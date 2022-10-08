using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMGCtrl : DMGCtrl
{
    private Material mat;
    private Rigidbody rgd;

    Color enemyColor;

    private void Awake()
    {
        mat = GetComponent<SkinnedMeshRenderer>().material;
        rgd = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        enemyColor = mat.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyCtrl tempEnemyCtrl = GetComponent<EnemyCtrl>();
        if (other.tag == "Skill" && !isDie)
        {
            Vector3 knockBack = transform.position - other.transform.position;
            StartCoroutine(OnDamage(knockBack, other.GetComponent<SkillHitCheck>().Knock_back));
            StartCoroutine(ChangeColor());
            float dmg_temp = other.gameObject.GetComponent<SkillHitCheck>().Damage;
            ReceiveDamage(dmg_temp);
            if (isDie)
            {
                tempEnemyCtrl.Dead();
            }
        }
    }

    IEnumerator OnDamage(Vector3 knockBack, float knockBack_value)
    {
        knockBack = knockBack.normalized;
        rgd.AddForce(knockBack * knockBack_value, ForceMode.VelocityChange);
        yield return new WaitForSeconds(0.1f);

        if (!isDie)
        {
            rgd.velocity = Vector3.zero;
        }
    }

    IEnumerator ChangeColor()
    {
        EnemyCtrl tempEnemyCtrl = GetComponent<EnemyCtrl>();
        mat.color = Color.red;
        yield return new WaitForSeconds(0.2f);

        if (!isDie)
        {
            mat.color = enemyColor;
        }
    }
}
