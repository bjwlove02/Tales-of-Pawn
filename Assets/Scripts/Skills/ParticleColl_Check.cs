using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColl_Check : SkillHitCheck
{
    Collider collider_col;
    // Start is called before the first frame update
     void Awake()
    {
        collider_col = GetComponent<Collider>();
    }
    void Start()
    {
        collider_col.enabled = true;
        // rb.AddForce(transform.up * -speed);
        StartCoroutine(Particle_Col_Cast());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Particle_Col_Cast()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        collider_col.enabled = true;
        ps.Play();
        yield return new WaitForSecondsRealtime(0.2f);  //collider 0.2초 동안 지속
        collider_col.enabled = false;
        Destroy(gameObject, 2.0f);
    }
}
