using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Hit : SkillHitCheck
{
    // Start is called before the first frame update
    [SerializeField]GameObject projectile;
    [SerializeField] Transform spawnTr;
    Collider collider_col;
    void Awake()
    {
        collider_col = GetComponent<Collider>();
    }
    void Start()
    {
        collider_col.enabled = false;
        // rb.AddForce(transform.up * -speed);
        StartCoroutine(Particle_Col_Cast());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Particle_Col_Cast()
    {
        if (Message.Instance().ReceiveMessage() == GameState.Playing)
        {
            GameObject temp_projectile = Instantiate(projectile, spawnTr.position, spawnTr.rotation);
            temp_projectile.GetComponent<ProjectileCtrl>().force_to_target = transform.position - temp_projectile.transform.position;
            yield return new WaitForSecondsRealtime(0.75f);
            Destroy(temp_projectile);
            collider_col.enabled = true;
            yield return new WaitForSecondsRealtime(0.5f);  //collider 0.2초 동안 지속
            collider_col.enabled = false;
        }
        Destroy(gameObject, 2.0f);
    }
}
